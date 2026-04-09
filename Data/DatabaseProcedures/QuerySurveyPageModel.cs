using System.Data;
using System.Diagnostics;
using System.Text.RegularExpressions;
using DataDriven.Models;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<SurveyPageModel?> QuerySurveyPageModel(
        SqlConnection connection,
        int surveyId,
        int surveyPageIndex,
        byte[] surveySessionToken);
}

public partial class DatabaseProcedureService(
    IDatabaseEnumService enumService) : IDatabaseProcedureService
{
    public async Task<SurveyPageModel?> QuerySurveyPageModel(
        SqlConnection connection,
        int surveyId,
        int surveyPageIndex,
        byte[] surveySessionToken)
    {
        await using SqlCommand command = new("query_survey_page_model", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;
        command.Parameters.Add("@survey_page_index", SqlDbType.Int).Value
            = surveyPageIndex;
        command.Parameters.Add("@survey_session_token", SqlDbType.Binary, 32).Value
            = surveySessionToken;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        SurveyModel survey = new(
            Title: reader.GetSqlString(0).StrictValue(),
            Author: reader.GetSqlString(1).StrictValue(),
            Description: reader.GetSqlString(2).StrictValue(),
            PageCount: reader.GetSqlInt32(3).StrictValue());

        List<ISurveyQuestionModel> questions = [];

        SurveyPageModel page = new(
            Title: reader.GetSqlString(4).StrictValue(),
            Description: reader.GetSqlString(5).StrictValue(),
            Questions: questions,
            Parent: survey);

        await reader.NextResultAsync();

        List<(
            string title,
            List<string> options,
            AnswerType answerType,
            List<(
                ConditionOperator op,
                ShowConditionType type,
                Dictionary<int, object?> args)> showConditions,
            List<(
                ConditionOperator op,
                ValidationConditionType type,
                Dictionary<int, object?> args)> validationConditions)> questionSetup = [];

        while (await reader.ReadAsync())
        {
            if (reader.GetSqlInt32(0).StrictValue() is var i && i != questionSetup.Count)
                throw new InvalidDataException(
                    $"Sparse array of questions found in survey id '" +
                    $"{surveyId}' page '{surveyPageIndex}' question '{i}'.");

            questionSetup.Add((
                title: reader.GetSqlString(2).StrictValue(),
                options: [],
                answerType: enumService.AnswerTypeMap[reader.GetSqlByte(1).StrictValue()],
                showConditions: [],
                validationConditions: []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            int optionIndex = reader.GetSqlInt32(1).StrictValue();
            List<string> options = questionSetup[questionIndex].options;

            if (optionIndex != options.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id '" +
                    $"{surveyId}' page '{surveyPageIndex}' question '" +
                    $"{questionIndex}' option '{optionIndex}'.");

            options.Add(reader.GetSqlString(2).StrictValue());
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            int conditionIndex = reader.GetSqlInt32(1).StrictValue();
            List<(
                ConditionOperator op,
                ShowConditionType type,
                Dictionary<int, object?> args)> showConditions = questionSetup[questionIndex].showConditions;

            if (conditionIndex != showConditions.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id " +
                    $"'{surveyId}' page '{surveyPageIndex}' question '" +
                    $"{questionIndex}' show condition '{conditionIndex}'.");

            showConditions.Add((
                op: enumService.ConditionOperatorMap[reader.GetSqlByte(2).StrictValue()],
                type: enumService.ShowConditionTypeMap[reader.GetSqlByte(3).StrictValue()],
                []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            int conditionIndex = reader.GetSqlInt32(1).StrictValue();
            int argumentIndex = reader.GetSqlInt32(2).StrictValue();
            Dictionary<int, object?> args = questionSetup[questionIndex].showConditions[conditionIndex].args;

            (int pageIndex, int questionIndex)? refArg
                = reader.GetSqlInt32(3).CheckedValue() is var x && x is not null
                    ? (x.Value, reader.GetSqlInt32(4).StrictValue())
                    : null;

            int? integerArg = reader.GetSqlInt32(5).CheckedValue();

            string? textArg = reader.GetSqlString(6).CheckedValue();

            args.Add(
                argumentIndex,
                (refArg, integerArg, textArg) switch
                {
                    ((int p, int q), null, null) when p > surveyPageIndex => throw new InvalidDataException(
                        $"Show condition argument references future page in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) when q >= questionIndex => throw new InvalidDataException(
                        $"Show condition argument references current or future question in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) => (p, q),
                    (null, int i, null) => i,
                    (null, null, string s) => s,
                    (null, null, null) => null,
                    _ => throw new InvalidDataException(
                        $"Show condition argument has mixed type in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                });
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            int conditionIndex = reader.GetSqlInt32(1).StrictValue();
            List<(
                ConditionOperator op,
                ValidationConditionType type,
                Dictionary<int, object?> args)> validationConditions = questionSetup[questionIndex].validationConditions;

            if (conditionIndex != validationConditions.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id " +
                    $"'{surveyId}' page '{surveyPageIndex}' question '" +
                    $"{questionIndex}' show condition '{conditionIndex}'.");

            validationConditions.Add((
                op: enumService.ConditionOperatorMap[reader.GetSqlByte(2).StrictValue()],
                type: enumService.ValidationConditionTypeMap[reader.GetSqlByte(3).StrictValue()],
                []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            int conditionIndex = reader.GetSqlInt32(1).StrictValue();
            int argumentIndex = reader.GetSqlInt32(2).StrictValue();
            Dictionary<int, object?> args = questionSetup[questionIndex].validationConditions[conditionIndex].args;

            (int pageIndex, int questionIndex)? refArg
                = reader.GetSqlInt32(3).CheckedValue() is var x && x is not null
                    ? (x.Value, reader.GetSqlInt32(4).StrictValue())
                    : null;

            int? integerArg = reader.GetSqlInt32(5).CheckedValue();

            string? textArg = reader.GetSqlString(6).CheckedValue();

            args.Add(
                argumentIndex,
                (refArg, integerArg, textArg) switch
                {
                    ((int p, int q), null, null) when p > surveyPageIndex => throw new InvalidDataException(
                        $"Show condition argument references future page in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) when q >= questionIndex => throw new InvalidDataException(
                        $"Show condition argument references current or future question in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) => (p, q),
                    (null, int i, null) => i,
                    (null, null, string s) => s,
                    (null, null, null) => null,
                    _ => throw new InvalidDataException(
                        $"Show condition argument has mixed type in survey id " +
                        $"'{surveyId}' page '{surveyPageIndex}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                });
        }

        foreach (
            var (
                id,
                (
                    title,
                    setupOptions,
                    answerType,
                    setupShowConditions,
                    setupValidationConditions))
            in questionSetup.Index())
        {
            List<ISurveyQuestionShowConditionModel> showConditions = [];
            List<ISurveyQuestionValidationConditionModel> validationConditions = [];

            ISurveyQuestionModel question = answerType switch
            {
                AnswerType.SmallText => new SurveyQuestionSmallTextModel(
                    Id: id,
                    Title: title,
                    Label: setupOptions.Count == 0 ? null : setupOptions[0],
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                AnswerType.Checkbox => new SurveyQuestionCheckboxModel(
                    Id: id,
                    Title: title,
                    Label: setupOptions.Count == 0 ? null : setupOptions[0],
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                AnswerType.Radio => new SurveyQuestionRadioModel(
                    Id: id,
                    Title: title,
                    Options: setupOptions,
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                AnswerType.RadioOrOther => new SurveyQuestionRadioOrOtherModel(
                    Id: id,
                    Title: title,
                    Options: setupOptions,
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                AnswerType.MultiSelect => new SurveyQuestionMultiSelectModel(
                    Id: id,
                    Title: title,
                    Options: setupOptions,
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                AnswerType.MultiSelectAndOther => new SurveyQuestionMultiSelectAndOtherModel(
                    Id: id,
                    Title: title,
                    Options: setupOptions,
                    ShowConditions: showConditions,
                    ValidationConditions: validationConditions,
                    page),
                _ => throw new UnreachableException(),
            };

            showConditions.AddRange(
                setupShowConditions.Select<
                    (
                        ConditionOperator op,
                        ShowConditionType type,
                        Dictionary<int, object?> args),
                    ISurveyQuestionShowConditionModel>((condition) =>
                {
                    switch (condition.type)
                    {
                        case ShowConditionType.HasAnswered
                            or ShowConditionType.HasNotAnswered:
                        {
                            (int pageIndex, int questionIndex)
                                = condition.args[0] as (int, int)?
                                    ?? throw new InvalidDataException(
                                        $"Show condition 'Has(Not)Answered' argument has" +
                                        $" wrong type for question id '{id}' in " +
                                        $"survey id '{surveyId}' page '{surveyPageIndex}'.");

                            if (pageIndex < surveyPageIndex)
                            {
                                return new SurveyQuestionShowConditionPreviouslyPassed(
                                    Operator: condition.op,
                                    Parent: question);
                            }

                            switch (page.Questions[questionIndex])
                            {
                                case SurveyQuestionSmallTextModel smallText:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredSmallTextModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: smallText,
                                        Match: new Regex(condition.args[1] as string ?? "^[^]"),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionCheckboxModel checkbox:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredCheckboxModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: checkbox,
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioModel radio:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredRadioModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Mask: new HashSet<int>(from k in condition.args.Keys where k > 0 select k - 1),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioOrOtherModel radio when condition.args[0] is string s:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredOtherOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Match: new Regex(s),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioOrOtherModel radio:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredOptionOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Mask: new HashSet<int>(from k in condition.args.Keys where k > 0 select k - 1),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio when condition.args[1] is string s:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredOtherOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Match: new Regex(s),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio:
                                {
                                    return new SurveyQuestionShowConditionHasAnsweredOptionOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Mask: new HashSet<int>(from k in condition.args.Keys where k > 0 select k - 1),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                default:
                                {
                                    throw new UnreachableException();
                                }
                            }
                        }
                        default:
                        {
                            throw new UnreachableException();
                        }
                    }
                }));

            validationConditions.AddRange(
                setupValidationConditions.Select<
                    (
                        ConditionOperator op,
                        ValidationConditionType type,
                        Dictionary<int, object?> args),
                    ISurveyQuestionValidationConditionModel>((condition) =>
                {
                    switch (condition.type)
                    {
                        case ValidationConditionType.Min
                            or ValidationConditionType.Max:
                        {
                            switch (question)
                            {
                                case SurveyQuestionSmallTextModel smallText:
                                {
                                    return new SurveyQuestionValidationConditionBoundSmallTextModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[0]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: smallText);
                                }
                                case SurveyQuestionCheckboxModel checkbox:
                                {
                                    return new SurveyQuestionValidationConditionBoundCheckboxModel(
                                        Operator: condition.op,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: checkbox);
                                }
                                case SurveyQuestionRadioModel radio:
                                {
                                    return new SurveyQuestionValidationConditionBoundRadioModel(
                                        Operator: condition.op,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionRadioOrOtherModel radio when condition.args.ContainsKey(2):
                                {
                                    return new SurveyQuestionValidationConditionBoundOtherOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[0]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionRadioOrOtherModel radio:
                                {
                                    return new SurveyQuestionValidationConditionBoundOptionOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionMultiSelectModel multiSelect:
                                {
                                    return new SurveyQuestionValidationConditionBoundMultiSelectModel(
                                        Operator: condition.op,
                                        CountBound: (int)condition.args[0]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: multiSelect);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel multiSelect when condition.args.ContainsKey(2):
                                {
                                    return new SurveyQuestionValidationConditionBoundOtherOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[0]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: multiSelect);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                                {
                                    return new SurveyQuestionValidationConditionBoundOptionOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        CountBound: (int)condition.args[0]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: multiSelect);
                                }
                                default:
                                {
                                    throw new UnreachableException(
                                        $"Found unexpected {question.GetType().Name}");
                                }
                            }
                        }
                        default:
                        {
                            throw new UnreachableException();
                        }
                    }
                }));

            questions.Add(question);
        }

        return page;
    }
}