using System.Buffers.Text;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using DataDriven.Data;
using DataDriven.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.ObjectPool;
using Microsoft.Extensions.Primitives;

namespace DataDriven.Controllers;

[Route("survey")]
public class SurveyController(
    IConfiguration configuration,
    IDatabaseEnumService enumService) : Controller
{
    [NonAction]
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
            List<ISurveyQuestionShowConstraintModel> showConditions = [];
            List<ISurveyQuestionValidationConstraintModel> validationConditions = [];

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
                    ISurveyQuestionShowConstraintModel>((condition) =>
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
                                return new SurveyQuestionShowConstraintPreviouslyPassed(
                                    Operator: condition.op,
                                    Parent: question);
                            }

                            switch (page.Questions[questionIndex])
                            {
                                case SurveyQuestionSmallTextModel smallText:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredSmallTextModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: smallText,
                                        Match: new Regex(condition.args[1] as string ?? "^[^]"),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionCheckboxModel checkbox:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredCheckboxModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: checkbox,
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioModel radio:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredRadioModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Mask: new HashSet<int>(from k in condition.args.Keys where k > 0 select k - 1),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioOrOtherModel radio when condition.args[0] is string s:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredOtherOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Match: new Regex(s),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionRadioOrOtherModel radio:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredOptionOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Mask: new HashSet<int>(from k in condition.args.Keys where k > 0 select k - 1),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio when condition.args[1] is string s:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredOtherOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        ReferencedQuestion: radio,
                                        Match: new Regex(s),
                                        Invert: condition.type is ShowConditionType.HasNotAnswered,
                                        Parent: question);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio:
                                {
                                    return new SurveyQuestionShowConstraintHasAnsweredOptionOfMultiSelectAndOtherModel(
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
                    ISurveyQuestionValidationConstraintModel>((condition) =>
                {
                    switch (condition.type)
                    {
                        case ValidationConditionType.Min
                            or ValidationConditionType.Max:
                        {
                            (int pageIndex, int questionIndex)
                                = condition.args[0] as (int, int)?
                                    ?? throw new InvalidDataException(
                                        $"Validation condition 'Has(Not)Answered' argument has" +
                                        $" wrong type for question id '{id}' in " +
                                        $"survey id '{surveyId}' page '{surveyPageIndex}'.");

                            if (pageIndex < surveyPageIndex)
                            {
                                return new SurveyQuestionValidationConstraintPreviouslyPassed(
                                    Operator: condition.op,
                                    Parent: question);
                            }

                            switch (question)
                            {
                                case SurveyQuestionSmallTextModel smallText:
                                {
                                    return new SurveyQuestionValidationConstraintBoundSmallTextModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: smallText);
                                }
                                case SurveyQuestionCheckboxModel checkbox:
                                {
                                    return new SurveyQuestionValidationConstraintBoundCheckboxModel(
                                        Operator: condition.op,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: checkbox);
                                }
                                case SurveyQuestionRadioModel radio:
                                {
                                    return new SurveyQuestionValidationConstraintBoundRadioModel(
                                        Operator: condition.op,
                                        Bound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionRadioOrOtherModel radio when condition.args.ContainsKey(2):
                                {
                                    return new SurveyQuestionValidationConstraintBoundOtherOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionRadioOrOtherModel radio:
                                {
                                    return new SurveyQuestionValidationConstraintBoundOptionOfRadioOrOtherModel(
                                        Operator: condition.op,
                                        Bound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio when condition.args.ContainsKey(2):
                                {
                                    return new SurveyQuestionValidationConstraintBoundOtherOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        LengthBound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
                                }
                                case SurveyQuestionMultiSelectAndOtherModel radio:
                                {
                                    return new SurveyQuestionValidationConstraintBoundOptionOfMultiSelectAndOtherModel(
                                        Operator: condition.op,
                                        Bound: (int)condition.args[1]!,
                                        IsMax: condition.type is ValidationConditionType.Max,
                                        Parent: radio);
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

            questions.Add(question);
        }

        return page;
    }

    [Route("{surveyId}/{surveyPageIndex}")]
    public async Task<IActionResult> Page(
        [FromRoute] string surveyId,
        [FromRoute] string surveyPageIndex)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || surveyIdValue < 0
            || !int.TryParse(surveyPageIndex, out int surveyPageIndexValue)
            || surveyPageIndexValue < 0)
            return NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        byte[] surveySessionToken = new byte[32];

        if (!Request.Cookies.TryGetValue("session", out string? sessionToken)
            || Convert.TryFromBase64String(sessionToken, surveySessionToken, out int bytesWritten)
            || bytesWritten != 32)
        {
            if (surveyPageIndexValue > 0)
                return BadRequest();

            const string SURVEY_ID = "@surveyId";

            await using SqlCommand command = new(
                $"""
                INSERT INTO {SqlSurveySession.TABLE} (
                    {SqlSurveySession.TABLE_SURVEY_ID})
                OUTPUT
                    INSERTED.{SqlSurveySession.TOKEN}
                VALUES
                    ({SURVEY_ID});
                """,
                connection);

            command.Parameters.Add(SURVEY_ID, SqlDbType.Int).Value
                = surveyIdValue;

            Response.Cookies.Append(
                "session",
                sessionToken = Convert.ToBase64String(surveySessionToken = (byte[])command.ExecuteScalar()));
        }

        SurveyPageModel? page = await QuerySurveyPageModel(
            connection,
            surveyIdValue,
            surveyPageIndexValue,
            surveySessionToken);

        if (page is null)
            return NotFound();

        return View(page);
    }
}