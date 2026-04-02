using System.Data;
using DataDriven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataDriven.Controllers;

public record SurveyQuestionShowConditionViewFields(
    SurveyQuestionShowConditionType Type,
    SurveyQuestionConditionOperator Operator,
    (int PageIndex, int Index)? ReferencedQuestion,
    int? IntegerValue,
    string? TextValue);

public record SurveyQuestionValidationConditionViewFields(
    SurveyQuestionValidationConditionType Type,
    SurveyQuestionConditionOperator Operator,
    (int PageIndex, int Index)? ReferencedQuestion,
    int? IntegerValue,
    string? TextValue);

public record SurveyQuestionViewFields(
    string Title,
    SurveyQuestionAnswerType Type,
    List<SurveyQuestionShowConditionViewFields> ShowConditions,
    List<SurveyQuestionValidationConditionViewFields> ValidationConditions);

[Route("survey")]
public class SurveyController(
    IConfiguration configuration,
    IDatabaseEnumService enumService) : Controller
{
    [Route("{surveyId}")]
    public async Task<IActionResult> StartPage(string surveyId)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue))
            return base.NotFound();

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        await using SqlCommand command = new(
            $"""
            SELECT
                {SqlSurvey.TITLE},
                {SqlSurvey.AUTHOR},
                {SqlSurvey.DESCRIPTION},
                MAX({SqlSurveyPage.INDEX}) + 1
            FROM
                {SqlSurvey.TABLE}
            LEFT JOIN
                {SqlSurveyPage.TABLE} ON
                {SqlSurveyPage.SURVEY_ID} = {SqlSurvey.ID}
            WHERE
                {SqlSurvey.ID} = @surveyId
            GROUP BY
                {SqlSurvey.ID},
                {SqlSurvey.TITLE},
                {SqlSurvey.AUTHOR},
                {SqlSurvey.DESCRIPTION};
            """,
            connection);

        command.Parameters.Add("@surveyId", SqlDbType.Int).Value = surveyIdValue;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return NotFound();

        string surveyTitle = reader.GetSqlString(0).StrictValue();
        string surveyAuthor = reader.GetSqlString(1).StrictValue();
        string surveyDescription = reader.GetSqlString(2).StrictValue();
        int surveyPageCount = reader.GetSqlInt32(3).StrictValue();

        ViewData["surveyId"] = surveyIdValue;
        ViewData["surveyTitle"] = surveyTitle;
        ViewData["surveyAuthor"] = surveyAuthor;
        ViewData["surveyDescription"] = surveyDescription;
        ViewData["surveyPageCount"] = surveyPageCount;

        return View();
    }

    [Route("{surveyId}/{surveyPageIndex}")]
    public async Task<IActionResult> Page(string surveyId, string surveyPageIndex)
    {
        if (!int.TryParse(surveyId, out int surveyIdValue)
            || !int.TryParse(surveyPageIndex, out int surveyPageIndexValue))
            return base.NotFound();

        ViewData["surveyId"] = surveyIdValue;
        ViewData["surveyPageIndex"] = surveyPageIndexValue;

        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        await using SqlCommand command = new(
            $"""
            SELECT
                {SqlSurveyPage.TITLE},
                {SqlSurveyPage.DESCRIPTION},
                MAX({SqlSurveyQuestion.INDEX}) + 1
            FROM
                {SqlSurveyPage.TABLE}
            LEFT JOIN
                {SqlSurveyQuestion.TABLE} ON
                {SqlSurveyQuestion.SURVEY_ID} = {SqlSurveyPage.SURVEY_ID}
                AND {SqlSurveyQuestion.PAGE_INDEX} = {SqlSurveyPage.INDEX}
            WHERE
                {SqlSurveyPage.SURVEY_ID} = @surveyId
                AND {SqlSurveyPage.INDEX} = @surveyPageIndex
            GROUP BY
                {SqlSurveyPage.SURVEY_ID},
                {SqlSurveyPage.INDEX},
                {SqlSurveyPage.TITLE},
                {SqlSurveyPage.DESCRIPTION};

            IF (@@ROWCOUNT = 0)
                RETURN;

            SELECT
                {SqlSurveyQuestion.INDEX},
                {SqlSurveyQuestion.TITLE},
                {SqlSurveyQuestion.TYPE}
            FROM
                {SqlSurveyQuestion.TABLE}
            WHERE
                {SqlSurveyQuestion.SURVEY_ID} = @surveyId
                AND {SqlSurveyQuestion.PAGE_INDEX} = @surveyPageIndex
            ORDER BY
                {SqlSurveyQuestion.INDEX};

            SELECT
                {SqlSurveyQuestionShowCondition.QUESTION_INDEX},
                {SqlSurveyQuestionShowCondition.INDEX},
                {SqlSurveyQuestionShowCondition.TYPE},
                {SqlSurveyQuestionShowCondition.IS_OR_OPERATOR},
                COALESCE(
                    {SqlSurveyQuestionShowConditionsRefArg.ARG_INDEX},
                    {SqlSurveyQuestionShowConditionsIntegerArg.ARG_INDEX},
                    {SqlSurveyQuestionShowConditionsTextArg.ARG_INDEX}),
                {SqlSurveyQuestionShowConditionsRefArg.REFERENCED_PAGE_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.REFERENCED_QUESTION_INDEX},
                {SqlSurveyQuestionShowConditionsIntegerArg.ARG_VALUE},
                {SqlSurveyQuestionShowConditionsTextArg.ARG_VALUE}
            FROM
                {SqlSurveyQuestionShowCondition.TABLE}
            LEFT JOIN
                {SqlSurveyQuestionShowConditionsRefArg.TABLE} ON
                {SqlSurveyQuestionShowConditionsRefArg.SURVEY_ID}
                    = {SqlSurveyQuestionShowCondition.SURVEY_ID}
                AND {SqlSurveyQuestionShowConditionsRefArg.PAGE_INDEX}
                    = {SqlSurveyQuestionShowCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionShowConditionsRefArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionShowCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionShowConditionsRefArg.INDEX}
                    = {SqlSurveyQuestionShowCondition.INDEX}
            LEFT JOIN
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE} ON
                {SqlSurveyQuestionShowConditionsIntegerArg.SURVEY_ID}
                    = {SqlSurveyQuestionShowCondition.SURVEY_ID}
                AND {SqlSurveyQuestionShowConditionsIntegerArg.PAGE_INDEX}
                    = {SqlSurveyQuestionShowCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionShowConditionsIntegerArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionShowCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionShowConditionsIntegerArg.INDEX}
                    = {SqlSurveyQuestionShowCondition.INDEX}
            LEFT JOIN
                {SqlSurveyQuestionShowConditionsTextArg.TABLE} ON
                {SqlSurveyQuestionShowConditionsTextArg.SURVEY_ID}
                    = {SqlSurveyQuestionShowCondition.SURVEY_ID}
                AND {SqlSurveyQuestionShowConditionsTextArg.PAGE_INDEX}
                    = {SqlSurveyQuestionShowCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionShowConditionsTextArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionShowCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionShowConditionsTextArg.INDEX}
                    = {SqlSurveyQuestionShowCondition.INDEX}
            WHERE
                {SqlSurveyQuestionShowCondition.SURVEY_ID} = @surveyId
                AND {SqlSurveyQuestionShowCondition.PAGE_INDEX} = @surveyPageIndex
            ORDER BY
                {SqlSurveyQuestionShowCondition.QUESTION_INDEX},
                COALESCE(
                    {SqlSurveyQuestionShowConditionsRefArg.ARG_INDEX},
                    {SqlSurveyQuestionShowConditionsIntegerArg.ARG_INDEX},
                    {SqlSurveyQuestionShowConditionsTextArg.ARG_INDEX});

            SELECT
                {SqlSurveyQuestionValidationCondition.QUESTION_INDEX},
                {SqlSurveyQuestionValidationCondition.INDEX},
                {SqlSurveyQuestionValidationCondition.TYPE},
                {SqlSurveyQuestionValidationCondition.IS_OR_OPERATOR},
                COALESCE(
                    {SqlSurveyQuestionValidationConditionsRefArg.ARG_INDEX},
                    {SqlSurveyQuestionValidationConditionsIntegerArg.ARG_INDEX},
                    {SqlSurveyQuestionValidationConditionsTextArg.ARG_INDEX}),
                {SqlSurveyQuestionValidationConditionsRefArg.REFERENCED_PAGE_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.REFERENCED_QUESTION_INDEX},
                {SqlSurveyQuestionValidationConditionsIntegerArg.ARG_VALUE},
                {SqlSurveyQuestionValidationConditionsTextArg.ARG_VALUE}
            FROM
                {SqlSurveyQuestionValidationCondition.TABLE}
            LEFT JOIN
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE} ON
                {SqlSurveyQuestionValidationConditionsRefArg.SURVEY_ID}
                    = {SqlSurveyQuestionValidationCondition.SURVEY_ID}
                AND {SqlSurveyQuestionValidationConditionsRefArg.PAGE_INDEX}
                    = {SqlSurveyQuestionValidationCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionValidationConditionsRefArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionValidationCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionValidationConditionsRefArg.INDEX}
                    = {SqlSurveyQuestionValidationCondition.INDEX}
            LEFT JOIN
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE} ON
                {SqlSurveyQuestionValidationConditionsIntegerArg.SURVEY_ID}
                    = {SqlSurveyQuestionValidationCondition.SURVEY_ID}
                AND {SqlSurveyQuestionValidationConditionsIntegerArg.PAGE_INDEX}
                    = {SqlSurveyQuestionValidationCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionValidationConditionsIntegerArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionValidationCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionValidationConditionsIntegerArg.INDEX}
                    = {SqlSurveyQuestionValidationCondition.INDEX}
            LEFT JOIN
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE} ON
                {SqlSurveyQuestionValidationConditionsTextArg.SURVEY_ID}
                    = {SqlSurveyQuestionValidationCondition.SURVEY_ID}
                AND {SqlSurveyQuestionValidationConditionsTextArg.PAGE_INDEX}
                    = {SqlSurveyQuestionValidationCondition.PAGE_INDEX}
                AND {SqlSurveyQuestionValidationConditionsTextArg.QUESTION_INDEX}
                    = {SqlSurveyQuestionValidationCondition.QUESTION_INDEX}
                AND {SqlSurveyQuestionValidationConditionsTextArg.INDEX}
                    = {SqlSurveyQuestionValidationCondition.INDEX}
            WHERE
                {SqlSurveyQuestionValidationCondition.SURVEY_ID} = @surveyId
                AND {SqlSurveyQuestionValidationCondition.PAGE_INDEX} = @surveyPageIndex
            ORDER BY
                {SqlSurveyQuestionValidationCondition.QUESTION_INDEX},
                COALESCE(
                    {SqlSurveyQuestionValidationConditionsRefArg.ARG_INDEX},
                    {SqlSurveyQuestionValidationConditionsIntegerArg.ARG_INDEX},
                    {SqlSurveyQuestionValidationConditionsTextArg.ARG_INDEX});
            """,
            connection);

        command.Parameters.Add("@surveyId", SqlDbType.Int).Value = surveyIdValue;
        command.Parameters.Add("@surveyPageIndex", SqlDbType.Int).Value = surveyPageIndexValue;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return NotFound();

        string pageTitle = reader.GetSqlString(0).StrictValue();
        string pageDescription = reader.GetSqlString(1).StrictValue();
        int questionCount = reader.GetSqlInt32(2).StrictValue();

        await reader.NextResultAsync();

        List<SurveyQuestionViewFields> questions = [];

        while (await reader.ReadAsync())
        {
            if (reader.GetSqlInt32(0).StrictValue() != questions.Count)
                throw new InvalidDataException(
                    "Question indexes must be sequential starting from 0.");

            questions.Add(new SurveyQuestionViewFields(
                reader.GetSqlString(1).StrictValue(),
                enumService.SurveyQuestionAnswerTypeMap[reader.GetSqlByte(2).StrictValue()],
                [],
                []));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            if (questionIndex < 0 || questionIndex >= questions.Count)
                throw new InvalidDataException(
                    "Show condition question index out of range.");

            SurveyQuestionViewFields question = questions[questionIndex];

            if (reader.GetSqlInt32(1).StrictValue() != question.ShowConditions.Count)
                throw new InvalidDataException(
                    "Show condition indexes must be sequential starting from 0 for each question.");

            questions[questionIndex].ShowConditions.Add(new SurveyQuestionShowConditionViewFields(
                enumService.SurveyQuestionShowConditionTypeMap[reader.GetSqlByte(2).StrictValue()],
                reader.GetSqlBoolean(3).StrictValue()
                    ? SurveyQuestionConditionOperator.Or
                    : SurveyQuestionConditionOperator.And,
                reader.IsDBNull(5)
                    ? null
                    : (reader.GetSqlInt32(5).StrictValue(), reader.GetSqlInt32(6).StrictValue()),
                reader.GetSqlInt32(7).CheckedValue(),
                reader.GetSqlString(8).CheckedValue()));
        }

        await reader.NextResultAsync();

        while (await reader.ReadAsync())
        {
            int questionIndex = reader.GetSqlInt32(0).StrictValue();
            if (questionIndex < 0 || questionIndex >= questions.Count)
                throw new InvalidDataException(
                    "Validation condition question index out of range.");

            SurveyQuestionViewFields question = questions[questionIndex];

            if (reader.GetSqlInt32(1).StrictValue() != question.ValidationConditions.Count)
                throw new InvalidDataException(
                    "Validation condition indexes must be sequential starting from 0 for each question.");

            questions[questionIndex].ValidationConditions.Add(new SurveyQuestionValidationConditionViewFields(
                enumService.SurveyQuestionValidationConditionTypeMap[reader.GetSqlByte(2).StrictValue()],
                reader.GetSqlBoolean(3).StrictValue()
                    ? SurveyQuestionConditionOperator.Or
                    : SurveyQuestionConditionOperator.And,
                reader.IsDBNull(5)
                    ? null
                    : (reader.GetSqlInt32(5).StrictValue(), reader.GetSqlInt32(6).StrictValue()),
                reader.GetSqlInt32(7).CheckedValue(),
                reader.GetSqlString(8).CheckedValue()));
        }

        ViewData["questions"] = questions;

        return View();
    }
}