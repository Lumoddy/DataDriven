using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Text.RegularExpressions;
using DataDriven.Models;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<SurveyModel?> QuerySurveyModel(
        SqlConnection connection,
        int surveyId);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<SurveyModel?> QuerySurveyModel(
        SqlConnection connection,
        int surveyId)
    {
        await using SqlCommand command = new("query_survey_model", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        Dictionary<
            int,
            (
                ISurveyPageModel page,
                Dictionary<
                    int,
                    (
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
                            Dictionary<int, object?> args)> validationConditions)> questionSetup)> pageSetup = [];

        SurveyModel survey = new(
            Id: surveyId,
            Title: reader.GetSqlString(0).StrictValue(),
            Author: reader.GetSqlString(1).StrictValue(),
            Description: reader.GetSqlString(2).StrictValue(),
            Pages: new List<ISurveyPageModel>());

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            SurveyPageModel page = new(
                Id: reader.GetSqlInt32(0).StrictValue(),
                Title: reader.GetSqlString(1).StrictValue(),
                Description: reader.GetSqlString(2).StrictValue(),
                Questions: new Dictionary<int, ISurveyQuestionModel>(),
                Parent: survey);

            pageSetup.Add(page.Id, (page, []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            pageSetup[reader.GetSqlInt32(0).StrictValue()].questionSetup.Add(
                reader.GetSqlInt32(1).StrictValue(),
                (
                    title: reader.GetSqlString(3).StrictValue(),
                    options: [],
                    answerType: enumService.AnswerTypeMap[reader.GetSqlByte(2).StrictValue()],
                    showConditions: [],
                    validationConditions: []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(1).StrictValue();
            int optionIndex = reader.GetSqlInt32(2).StrictValue();
            var (page, questionSetup) = pageSetup[reader.GetSqlInt32(0).StrictValue()];
            List<string> options = questionSetup[questionIndex].options;

            if (optionIndex != options.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id '" +
                    $"{surveyId}' page '{page.Id}' question '" +
                    $"{questionIndex}' option '{optionIndex}'.");

            options.Add(reader.GetSqlString(3).StrictValue());
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(1).StrictValue();
            int conditionIndex = reader.GetSqlInt32(2).StrictValue();
            var (page, questionSetup) = pageSetup[reader.GetSqlInt32(0).StrictValue()];
            var showConditions = questionSetup[questionIndex].showConditions;

            if (conditionIndex != showConditions.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id " +
                    $"'{surveyId}' page '{page.Id}' question '" +
                    $"{questionIndex}' show condition '{conditionIndex}'.");

            showConditions.Add((
                op: enumService.ConditionOperatorMap[reader.GetSqlByte(3).StrictValue()],
                type: enumService.ShowConditionTypeMap[reader.GetSqlByte(4).StrictValue()],
                []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(1).StrictValue();
            int conditionIndex = reader.GetSqlInt32(2).StrictValue();
            int argumentIndex = reader.GetSqlInt32(3).StrictValue();
            var (page, questionSetup) = pageSetup[reader.GetSqlInt32(0).StrictValue()];
            Dictionary<int, object?> args = questionSetup[questionIndex].showConditions[conditionIndex].args;

            (int pageIndex, int questionIndex)? refArg
                = reader.GetSqlInt32(4).CheckedValue() is var x && x != null
                    ? (x.Value, reader.GetSqlInt32(5).StrictValue())
                    : null;

            int? integerArg = reader.GetSqlInt32(6).CheckedValue();

            string? textArg = reader.GetSqlString(7).CheckedValue();

            args.Add(
                argumentIndex,
                (refArg, integerArg, textArg) switch
                {
                    ((int p, int q), null, null) when p > page.Id => throw new InvalidDataException(
                        $"Show condition argument references future page in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) when q >= questionIndex => throw new InvalidDataException(
                        $"Show condition argument references current or future question in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) => (p, q),
                    (null, int i, null) => i,
                    (null, null, string s) => s,
                    (null, null, null) => null,
                    _ => throw new InvalidDataException(
                        $"Show condition argument has mixed type in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                });
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(1).StrictValue();
            int conditionIndex = reader.GetSqlInt32(2).StrictValue();
            var (page, questionSetup) = pageSetup[reader.GetSqlInt32(0).StrictValue()];
            var validationConditions = questionSetup[questionIndex].validationConditions;

            if (conditionIndex != validationConditions.Count)
                throw new InvalidDataException(
                    $"Sparse array of question options found in survey id " +
                    $"'{surveyId}' page '{page.Id}' question '" +
                    $"{questionIndex}' show condition '{conditionIndex}'.");

            validationConditions.Add((
                op: enumService.ConditionOperatorMap[reader.GetSqlByte(3).StrictValue()],
                type: enumService.ValidationConditionTypeMap[reader.GetSqlByte(4).StrictValue()],
                []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(1).StrictValue();
            int conditionIndex = reader.GetSqlInt32(2).StrictValue();
            int argumentIndex = reader.GetSqlInt32(3).StrictValue();
            var (page, questionSetup) = pageSetup[reader.GetSqlInt32(0).StrictValue()];
            Dictionary<int, object?> args = questionSetup[questionIndex].validationConditions[conditionIndex].args;

            (int pageIndex, int questionIndex)? refArg
                = reader.GetSqlInt32(4).CheckedValue() is var x && x != null
                    ? (x.Value, reader.GetSqlInt32(5).StrictValue())
                    : null;

            int? integerArg = reader.GetSqlInt32(6).CheckedValue();

            string? textArg = reader.GetSqlString(7).CheckedValue();

            args.Add(
                argumentIndex,
                (refArg, integerArg, textArg) switch
                {
                    ((int p, int q), null, null) when p > page.Id => throw new InvalidDataException(
                        $"Show condition argument references future page in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) when q >= questionIndex => throw new InvalidDataException(
                        $"Show condition argument references current or future question in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                    ((int p, int q), null, null) => (p, q),
                    (null, int i, null) => i,
                    (null, null, string s) => s,
                    (null, null, null) => null,
                    _ => throw new InvalidDataException(
                        $"Show condition argument has mixed type in survey id " +
                        $"'{surveyId}' page '{page.Id}' question '" +
                        $"{questionIndex}' show condition '{conditionIndex}' " +
                        $"argument '{argumentIndex}'."),
                });
        }

        foreach (
            (
                int _,
                (
                    ISurveyPageModel page,
                    Dictionary<
                        int,
                        (
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
                                Dictionary<int, object?> args)> validationConditions)> questionSetup)
            )
            in pageSetup
        )
        {
            List<ISurveyPageModel> pages
                = (List<ISurveyPageModel>)survey.Pages!;

            pages.Add(page);

            Dictionary<int, ISurveyQuestionModel> questions
                = (Dictionary<int, ISurveyQuestionModel>)page.Questions;

            foreach (
                (
                    int id,
                    (
                        string? title,
                        List<string>? setupOptions,
                        AnswerType answerType,
                        List<(
                            ConditionOperator op,
                            ShowConditionType type,
                            Dictionary<int, object?> args)>? setupShowConditions,
                        List<(
                            ConditionOperator op,
                            ValidationConditionType type,
                            Dictionary<int, object?> args)>? setupValidationConditions))
                in questionSetup)
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
                    _ => throw new UnreachableException(
                        $"Unknown answer type '{answerType}'"),
                };

                questions.Add(id, question);

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
                                        ?? throw new UnreachableException(
                                            $"Show condition 'Has(Not)Answered' argument has" +
                                            $" wrong type for question id '{id}' in " +
                                            $"survey id '{surveyId}' page '{page.Id}'.");

                                if (pageIndex < page.Id)
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
                                            Match: new Regex((
                                                condition.args.TryGetValue(1, out object? matchArg)
                                                    ? matchArg as string
                                                    : null) ?? "^[^]"),
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionCheckboxModel checkbox:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredCheckboxModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: checkbox,
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionRadioModel radio:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredRadioModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: radio,
                                            OptionIndex: condition.args.TryGetValue(1, out object? indexArg)
                                                ? indexArg as int?
                                                : null,
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionRadioOrOtherModel radio
                                    when condition.args.TryGetValue(2, out object? markerArg)
                                        && markerArg != null:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredOtherOfRadioOrOtherModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: radio,
                                            Match: new Regex((
                                                condition.args.TryGetValue(1, out object? matchArg)
                                                    ? matchArg as string
                                                    : null) ?? "^[^]"),
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionRadioOrOtherModel radio:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredOptionOfRadioOrOtherModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: radio,
                                            OptionIndex: condition.args.TryGetValue(1, out object? indexArg)
                                                ? indexArg as int?
                                                : null,
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionMultiSelectModel multiSelect:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredMultiSelectModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: multiSelect,
                                            OptionIndex: condition.args.TryGetValue(1, out object? indexArg)
                                                ? indexArg as int?
                                                : null,
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionMultiSelectAndOtherModel multiSelect
                                    when condition.args.ContainsKey(2):
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredOtherOfMultiSelectAndOtherModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: multiSelect,
                                            Match: new Regex((
                                                condition.args.TryGetValue(1, out object? matchArg)
                                                    ? matchArg as string
                                                    : null) ?? "^[^]"),
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                                    {
                                        return new SurveyQuestionShowConditionHasAnsweredOptionOfMultiSelectAndOtherModel(
                                            Operator: condition.op,
                                            ReferencedQuestion: multiSelect,
                                            OptionIndex: condition.args.TryGetValue(1, out object? indexArg)
                                                ? indexArg as int?
                                                : null,
                                            Invert: condition.type == ShowConditionType.HasNotAnswered,
                                            Parent: question);
                                    }
                                    case object question:
                                    {
                                        throw new UnreachableException(
                                            $"Unknown question type '{question.GetType().Name} [{condition.args.Aggregate(new StringBuilder(), (a, x) => (a.Length == 0 ? a : a.Append(", ")).Append(x))}]'");
                                    }
                                    default: throw null!;
                                }
                            }
                            default:
                            {
                                throw new UnreachableException(
                                    $"Unknown show condition type '{condition.type}'");
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
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: smallText);
                                    }
                                    case SurveyQuestionCheckboxModel checkbox:
                                    {
                                        return new SurveyQuestionValidationConditionBoundCheckboxModel(
                                            Operator: condition.op,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: checkbox);
                                    }
                                    case SurveyQuestionRadioModel radio:
                                    {
                                        return new SurveyQuestionValidationConditionBoundRadioModel(
                                            Operator: condition.op,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: radio);
                                    }
                                    case SurveyQuestionRadioOrOtherModel radio when condition.args.ContainsKey(2):
                                    {
                                        return new SurveyQuestionValidationConditionBoundOtherOfRadioOrOtherModel(
                                            Operator: condition.op,
                                            LengthBound: (int)condition.args[0]!,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: radio);
                                    }
                                    case SurveyQuestionRadioOrOtherModel radio:
                                    {
                                        return new SurveyQuestionValidationConditionBoundOptionOfRadioOrOtherModel(
                                            Operator: condition.op,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: radio);
                                    }
                                    case SurveyQuestionMultiSelectModel multiSelect:
                                    {
                                        return new SurveyQuestionValidationConditionBoundMultiSelectModel(
                                            Operator: condition.op,
                                            CountBound: (int)condition.args[0]!,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: multiSelect);
                                    }
                                    case SurveyQuestionMultiSelectAndOtherModel multiSelect when condition.args.ContainsKey(2):
                                    {
                                        return new SurveyQuestionValidationConditionBoundOtherOfMultiSelectAndOtherModel(
                                            Operator: condition.op,
                                            LengthBound: (int)condition.args[0]!,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: multiSelect);
                                    }
                                    case SurveyQuestionMultiSelectAndOtherModel multiSelect:
                                    {
                                        return new SurveyQuestionValidationConditionBoundOptionOfMultiSelectAndOtherModel(
                                            Operator: condition.op,
                                            CountBound: (int)condition.args[0]!,
                                            IsMax: condition.type == ValidationConditionType.Max,
                                            Parent: multiSelect);
                                    }
                                    default:
                                    {
                                        throw new UnreachableException(
                                            $"Found unexpected '{question.GetType().Name}'");
                                    }
                                }
                            }
                            default:
                            {
                                throw new UnreachableException(
                                    $"Unknown validation condition type '{condition.type}'");
                            }
                        }
                    }));
            }
        }

        return survey;
    }
}