using System.Data;
using System.Data.SqlTypes;
using DataDriven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataDriven.Controllers;

public enum SurveyQuestionAnswerType
{
    SmallText,
    Checkbox,
    Radio,
    RadioAndOther,
    MultiSelect,
}

public record SurveyQuestionViewFields(
    string Title,
    SurveyQuestionAnswerType Type);

[Route("survey")]
public class SurveyController(IConfiguration configuration) : Controller
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
                {SqlSurvey.TABLE_TITLE},
                {SqlSurvey.TABLE_AUTHOR},
                {SqlSurvey.TABLE_DESCRIPTION},
                MAX({SqlSurveyPage.TABLE_INDEX}) + 1
            FROM
                {SqlSurvey.TABLE}
            LEFT JOIN
                {SqlSurveyPage.TABLE} ON
                {SqlSurveyPage.TABLE_SURVEY_ID} = {SqlSurvey.TABLE_ID}
            WHERE
                {SqlSurvey.TABLE_ID} = @surveyId
            GROUP BY
                {SqlSurvey.TABLE_ID},
                {SqlSurvey.TABLE_TITLE},
                {SqlSurvey.TABLE_AUTHOR},
                {SqlSurvey.TABLE_DESCRIPTION};
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
                {SqlSurveyPage.TABLE_TITLE},
                {SqlSurveyPage.TABLE_DESCRIPTION},
                MAX({SqlSurveyQuestion.TABLE_INDEX}) + 1
            FROM
                {SqlSurveyPage.TABLE}
            LEFT JOIN
                {SqlSurveyQuestion.TABLE} ON
                {SqlSurveyQuestion.TABLE_SURVEY_ID} = {SqlSurveyPage.TABLE_SURVEY_ID}
                AND {SqlSurveyQuestion.TABLE_PAGE_INDEX} = {SqlSurveyPage.TABLE_INDEX}
            WHERE
                {SqlSurveyPage.TABLE_SURVEY_ID} = @surveyId
                AND {SqlSurveyPage.TABLE_INDEX} = @surveyPageIndex
            GROUP BY
                {SqlSurveyPage.TABLE_SURVEY_ID},
                {SqlSurveyPage.TABLE_INDEX},
                {SqlSurveyPage.TABLE_TITLE},
                {SqlSurveyPage.TABLE_DESCRIPTION};

            IF @@ROWCOUNT > 0
            BEGIN
                SELECT {SqlAnswerType.TABLE_ID}
                FROM {SqlAnswerType.TABLE}
                WHERE {SqlAnswerType.TABLE_NAME} = 'SmallText';

                SELECT {SqlAnswerType.TABLE_ID}
                FROM {SqlAnswerType.TABLE}
                WHERE {SqlAnswerType.TABLE_NAME} = 'Checkbox';

                SELECT {SqlAnswerType.TABLE_ID}
                FROM {SqlAnswerType.TABLE}
                WHERE {SqlAnswerType.TABLE_NAME} = 'Radio';

                SELECT {SqlAnswerType.TABLE_ID}
                FROM {SqlAnswerType.TABLE}
                WHERE {SqlAnswerType.TABLE_NAME} = 'RadioAndOther';

                SELECT {SqlAnswerType.TABLE_ID}
                FROM {SqlAnswerType.TABLE}
                WHERE {SqlAnswerType.TABLE_NAME} = 'MultiSelect';

                SELECT {SqlSurveyQuestionShowConditionType.TABLE_ID}
                FROM {SqlSurveyQuestionShowConditionType.TABLE}
                WHERE {SqlSurveyQuestionShowConditionType.TABLE_NAME} = 'IsAnswered';

                SELECT {SqlSurveyQuestionShowConditionType.TABLE_ID}
                FROM {SqlSurveyQuestionShowConditionType.TABLE}
                WHERE {SqlSurveyQuestionShowConditionType.TABLE_NAME} = 'IsNotAnswered';

                SELECT {SqlSurveyQuestionValidationConditionType.TABLE_ID}
                FROM {SqlSurveyQuestionValidationConditionType.TABLE}
                WHERE {SqlSurveyQuestionValidationConditionType.TABLE_NAME} = 'Min';

                SELECT {SqlSurveyQuestionValidationConditionType.TABLE_ID}
                FROM {SqlSurveyQuestionValidationConditionType.TABLE}
                WHERE {SqlSurveyQuestionValidationConditionType.TABLE_NAME} = 'Max';

                SELECT
                    {SqlSurveyQuestion.TABLE_INDEX},
                    {SqlSurveyQuestion.TABLE_TITLE},
                    {SqlSurveyQuestion.TABLE_TYPE}
                FROM
                    {SqlSurveyQuestion.TABLE}
                WHERE
                    {SqlSurveyQuestion.TABLE_SURVEY_ID} = @surveyId
                    AND {SqlSurveyQuestion.TABLE_PAGE_INDEX} = @surveyPageIndex
                ORDER BY
                    {SqlSurveyQuestion.TABLE_INDEX};

                SELECT
                    {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX},
                    {SqlSurveyQuestionShowCondition.TABLE_INDEX},
                    {SqlSurveyQuestionShowCondition.TABLE_TYPE},
                    COALESCE(
                        {SqlSurveyQuestionShowConditionsRefArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionShowConditionsTextArg.TABLE_ARG_INDEX}),
                    {SqlSurveyQuestionShowConditionsRefArg.TABLE_REFERENCED_PAGE_INDEX},
                    {SqlSurveyQuestionShowConditionsRefArg.TABLE_REFERENCED_QUESTION_INDEX},
                    {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_ARG_VALUE},
                    {SqlSurveyQuestionShowConditionsTextArg.TABLE_ARG_VALUE}
                FROM
                    {SqlSurveyQuestionShowCondition.TABLE}
                LEFT JOIN
                    {SqlSurveyQuestionShowConditionsRefArg.TABLE} ON
                    {SqlSurveyQuestionShowConditionsRefArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_INDEX}
                LEFT JOIN
                    {SqlSurveyQuestionShowConditionsIntegerArg.TABLE} ON
                    {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_INDEX}
                LEFT JOIN
                    {SqlSurveyQuestionShowConditionsTextArg.TABLE} ON
                    {SqlSurveyQuestionShowConditionsTextArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_INDEX}
                WHERE
                    {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID} = @surveyId
                    AND {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX} = @surveyPageIndex
                ORDER BY
                    {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX},
                    COALESCE(
                        {SqlSurveyQuestionShowConditionsRefArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionShowConditionsTextArg.TABLE_ARG_INDEX});

                SELECT
                    {SqlSurveyQuestion.TABLE_INDEX},
                    {SqlSurveyQuestion.TABLE_TITLE},
                    {SqlSurveyQuestion.TABLE_TYPE}
                FROM
                    {SqlSurveyQuestion.TABLE}
                WHERE
                    {SqlSurveyQuestion.TABLE_SURVEY_ID} = @surveyId
                    AND {SqlSurveyQuestion.TABLE_PAGE_INDEX} = @surveyPageIndex
                ORDER BY
                    {SqlSurveyQuestion.TABLE_INDEX};

                SELECT
                    {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX},
                    {SqlSurveyQuestionValidationCondition.TABLE_INDEX},
                    {SqlSurveyQuestionValidationCondition.TABLE_TYPE},
                    COALESCE(
                        {SqlSurveyQuestionValidationConditionsRefArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionValidationConditionsTextArg.TABLE_ARG_INDEX}),
                    {SqlSurveyQuestionValidationConditionsRefArg.TABLE_REFERENCED_PAGE_INDEX},
                    {SqlSurveyQuestionValidationConditionsRefArg.TABLE_REFERENCED_QUESTION_INDEX},
                    {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_ARG_VALUE},
                    {SqlSurveyQuestionValidationConditionsTextArg.TABLE_ARG_VALUE}
                FROM
                    {SqlSurveyQuestionValidationCondition.TABLE}
                LEFT JOIN
                    {SqlSurveyQuestionValidationConditionsRefArg.TABLE} ON
                    {SqlSurveyQuestionValidationConditionsRefArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionValidationCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionValidationConditionsRefArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsRefArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsRefArg.TABLE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_INDEX}
                LEFT JOIN
                    {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE} ON
                    {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionValidationCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_INDEX}
                LEFT JOIN
                    {SqlSurveyQuestionValidationConditionsTextArg.TABLE} ON
                    {SqlSurveyQuestionValidationConditionsTextArg.TABLE_SURVEY_ID} = {SqlSurveyQuestionValidationCondition.TABLE_SURVEY_ID}
                    AND {SqlSurveyQuestionValidationConditionsTextArg.TABLE_PAGE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsTextArg.TABLE_QUESTION_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX}
                    AND {SqlSurveyQuestionValidationConditionsTextArg.TABLE_INDEX} = {SqlSurveyQuestionValidationCondition.TABLE_INDEX}
                WHERE
                    {SqlSurveyQuestionValidationCondition.TABLE_SURVEY_ID} = @surveyId
                    AND {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX} = @surveyPageIndex
                ORDER BY
                    {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX},
                    COALESCE(
                        {SqlSurveyQuestionValidationConditionsRefArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_ARG_INDEX},
                        {SqlSurveyQuestionValidationConditionsTextArg.TABLE_ARG_INDEX});
            END
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
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing answer type 'SmallText' in database.");

        byte answerTypeSmallText = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing answer type 'Checkbox' in database.");

        byte answerTypeCheckbox = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing answer type 'Radio' in database.");

        byte answerTypeRadio = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing answer type 'RadioAndOther' in database.");

        byte answerTypeRadioAndOther = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing answer type 'MultiSelect' in database.");

        byte answerTypeMultiSelect = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing show condition type 'IsAnswered' in database.");

        byte showConditionIsAnsweredId = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing show condition type 'IsNotAnswered' in database.");

        byte showConditionIsNotAnsweredId = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing validation condition type 'Min' in database.");

        byte validationConditionMinId = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();
        if (!await reader.ReadAsync())
            throw new MissingFieldException(
                "Missing validation condition type 'Max' in database.");

        byte validationConditionMaxId = reader.GetSqlByte(0).StrictValue();

        await reader.NextResultAsync();

        List<SurveyQuestionViewFields> questions = [];

        while (await reader.ReadAsync())
        {
            if (reader.GetSqlInt32(0).StrictValue() != questions.Count)
                throw new InvalidDataException(
                    "Question indexes must be sequential starting from 0.");

            questions.Add(new SurveyQuestionViewFields(
                reader.GetSqlString(1).StrictValue(),
                reader.GetSqlByte(2).StrictValue() is var type &&
                type == answerTypeSmallText ? SurveyQuestionAnswerType.SmallText :
                type == answerTypeCheckbox ? SurveyQuestionAnswerType.Checkbox :
                type == answerTypeRadio ? SurveyQuestionAnswerType.Radio :
                type == answerTypeRadioAndOther ? SurveyQuestionAnswerType.RadioAndOther :
                type == answerTypeMultiSelect ? SurveyQuestionAnswerType.MultiSelect :
                throw new InvalidDataException($"Unknown answer type '{type}'.")));
        }

        await reader.NextResultAsync();

        // TODO: Show conditions.

        await reader.NextResultAsync();

        // TODO: Validation conditions.

        ViewData["questions"] = questions;

        return View();
    }
}
