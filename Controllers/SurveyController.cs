using System.Buffers.Text;
using System.Data;
using System.Text;
using DataDriven.Data;
using DataDriven.Models;
using Microsoft.AspNetCore.Antiforgery;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Primitives;

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
    [NonAction]
    public SqlConnection DefaultSqlConnection()
        => new(configuration.GetConnectionString("Default"));

    private static class SqlNextVisibleQuestions
    {
        public const string TEMP = "[#next_visible_questions]";

        public const string INDEX = "[next_visible_question_index]";

        public const string TEMP_INDEX = "[#next_visible_questions].[next_visible_question_index]";
    }

    private static class SqlGrouped
    {
        public const string TABLE = "[grouped]";

        public const string INDEX = "[group_index]";

        public const string TABLE_INDEX = "[grouped].[group_index]";

        public const string VALUE = "[group_value]";

        public const string TABLE_VALUE = "[grouped].[group_value]";
    }

    [NonAction]
    public async Task<object?> QuerySurveyPageModel(
        SqlConnection connection,
        int surveyId,
        int surveyPageIndex,
        byte[] surveySessionToken)
    {
        const string SURVEY_ID = "@survey_id";
        const string SURVEY_PAGE_INDEX = "@survey_page_index";
        const string SURVEY_SESSION_TOKEN = "@survey_session_token";

        const string ANSWER_TYPE_SMALL_TEXT = "@answer_text_small_text";
        const string ANSWER_TYPE_CHECKBOX = "@answer_text_checkbox";
        const string ANSWER_TYPE_RADIO = "@answer_text_radio";
        const string ANSWER_TYPE_RADIO_OR_OTHER = "@answer_text_radio_or_other";
        const string ANSWER_TYPE_MULTISELECT = "@answer_text_multiselect";
        const string ANSWER_TYPE_MULTISELECT_AND_OTHER = "@answer_text_multiselect_and_other";

        const string SHOW_CONDITION_HAS_ANSWERED = "@show_condition_has_answered";
        const string SHOW_CONDITION_HAS_NOT_ANSWERED = "@show_condition_has_not_answered";

        const string OPERATOR_AND = "CAST(0 AS BIT)";
        const string OPERATOR_OR = "CAST(1 AS BIT)";

        const string QUESTION = "[question]";
        const string GROUPED = "[grouped]";
        const string GROUPED_INDEX = "[grouped].[index]";

        Console.WriteLine();

        await using SqlCommand command = new(
            $"""
            SELECT
                {SqlSurvey.TABLE_TITLE},
                {SqlSurvey.TABLE_AUTHOR},
                {SqlSurvey.TABLE_DESCRIPTION},
                {SqlSurveyPage.TABLE_TITLE},
                {SqlSurveyPage.TABLE_DESCRIPTION}
            FROM
                {SqlSurveyPage.TABLE}
            LEFT JOIN
                {SqlSurvey.TABLE}
                ON {SqlSurvey.TABLE_ID}
                    = {SqlSurveyPage.TABLE_SURVEY_ID}
            LEFT JOIN
                {SqlSurveySession.TABLE}
                ON {SqlSurveySession.TABLE_SURVEY_ID}
                    = {SqlSurveyPage.TABLE_SURVEY_ID}
            WHERE
                {SqlSurvey.TABLE_ID} = {SURVEY_ID}
                AND {SqlSurveyPage.TABLE_INDEX} = {SURVEY_PAGE_INDEX}
                AND {SqlSurveySession.TABLE_TOKEN} = {SURVEY_SESSION_TOKEN};

            IF (@@ROWCOUNT = 0)
                RETURN;

            SELECT
                {SqlSurveyQuestion.TABLE_INDEX}
            INTO
                {SqlNextVisibleQuestions.TEMP}
            FROM
                {SqlSurveyQuestion.TABLE} AS {QUESTION}
            WHERE
                {SqlSurveyQuestion.TABLE_SURVEY_ID} = {SURVEY_ID}
                AND {SqlSurveyQuestion.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                AND EXISTS(
                    WITH {SqlGrouped.TABLE} AS (
                        SELECT
                            *,
                            SUM(CASE
                                WHEN
                                    {SqlSurveyQuestionShowCondition.TABLE_IS_OR_OPERATOR} = {OPERATOR_OR}
                                    AND {SqlSurveyQuestionShowCondition.TABLE_INDEX} > 0
                                THEN 1
                                ELSE 0
                            END)
                            OVER (
                                ORDER BY {SqlSurveyQuestionShowCondition.TABLE_INDEX}
                                ROWS UNBOUNDED PRECEDING) AS {SqlGrouped.INDEX},
                            CASE
                                WHEN
                                    {SqlSurveyQuestionShowCondition.TABLE_TYPE} = {SHOW_CONDITION_HAS_ANSWERED}
                                THEN EXISTS(
                                    SELECT 1 FROM
                                        {SqlSurveyQuestionShowConditionsRefArg.TABLE}
                                    INNER JOIN
                                        {SqlSurveyQuestion.TABLE}
                                        ON
                                            {SqlSurveyQuestion.TABLE_SURVEY_ID} = {SURVEY_ID}
                                            AND {SqlSurveyQuestion.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                                            AND {SqlSurveyQuestion.TABLE_INDEX} = {QUESTION}.{SqlSurveyQuestion.INDEX}
                                    LEFT JOIN
                                        {SqlSurveyQuestionShowConditionsTextArg.TABLE}
                                        ON
                                            {SqlSurveyQuestionShowConditionsTextArg.TABLE_SURVEY_ID} = {SURVEY_ID}
                                            AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                                            AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_QUESTION_INDEX} = {QUESTION}.{SqlSurveyQuestion.INDEX}
                                            AND {SqlSurveyQuestionShowConditionsTextArg.TABLE_CONDITION_INDEX} = {SqlSurveyQuestionShowConditionsRefArg.TABLE_CONDITION_INDEX}
                                    WHERE
                                        {SqlSurveyQuestionShowConditionsRefArg.TABLE_SURVEY_ID} = {SURVEY_ID}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_QUESTION_INDEX} = {QUESTION}.{SqlSurveyQuestion.INDEX}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_CONDITION_INDEX} = {SqlSurveyQuestionShowCondition.TABLE_INDEX}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_INDEX} = 0
                                    )
                            END
                        FROM {SqlSurveyQuestionShowCondition.TABLE}
                        WHERE
                            {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID} = {SURVEY_ID}
                            AND {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                            AND {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX} = {QUESTION}.{SqlSurveyQuestion.INDEX})
                    SELECT 1 FROM
                        {SqlGrouped.TABLE}
                    GROUP BY
                        {SqlGrouped.TABLE_INDEX}
                    HAVING
                        MIN(CASE
                            WHEN
                                {SqlGrouped.TABLE}.{SqlSurveyQuestionShowCondition.TYPE} = {SHOW_CONDITION_HAS_ANSWERED}
                            THEN CASE
                                WHEN EXISTS(
                                    SELECT 1 FROM
                                        {SqlSurveyQuestionShowConditionsRefArg.TABLE}
                                    WHERE
                                        {SqlSurveyQuestionShowConditionsRefArg.TABLE_SURVEY_ID} = {SURVEY_ID}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_PAGE_INDEX} = {SURVEY_PAGE_INDEX}
                                        AND {SqlSurveyQuestionShowConditionsRefArg.TABLE_QUESTION_INDEX} = {QUESTION}.{SqlSurveyQuestion.INDEX}
                                )
                            END
                        END) = CAST(1 AS BIT)
                )
            """,
            connection);

        command.Parameters.Add(SURVEY_ID, SqlDbType.Int).Value
            = surveyId;
        command.Parameters.Add(SURVEY_PAGE_INDEX, SqlDbType.Int).Value
            = surveyPageIndex;
        command.Parameters.Add(SURVEY_SESSION_TOKEN, SqlDbType.Binary, 32).Value
            = surveySessionToken;

        command.Parameters.Add(ANSWER_TYPE_SMALL_TEXT, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.SmallText];
        command.Parameters.Add(ANSWER_TYPE_CHECKBOX, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.Checkbox];
        command.Parameters.Add(ANSWER_TYPE_RADIO, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.Radio];
        command.Parameters.Add(ANSWER_TYPE_RADIO_OR_OTHER, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.RadioOrOther];
        command.Parameters.Add(ANSWER_TYPE_MULTISELECT, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.MultiSelect];
        command.Parameters.Add(ANSWER_TYPE_MULTISELECT_AND_OTHER, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionAnswerTypeMap[SurveyQuestionAnswerType.MultiSelectAndOther];

        command.Parameters.Add(SHOW_CONDITION_HAS_ANSWERED, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionShowConditionTypeMap[SurveyQuestionShowConditionType.HasAnswered];
        command.Parameters.Add(SHOW_CONDITION_HAS_NOT_ANSWERED, SqlDbType.TinyInt).Value
            = enumService.SurveyQuestionShowConditionTypeMap[SurveyQuestionShowConditionType.HasNotAnswered];

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (reader.HasRows)
            return null;

        await reader.ReadAsync();

        string surveyTitle = reader.GetSqlString(1).StrictValue();
        string surveyAuthor = reader.GetSqlString(2).StrictValue();
        string surveyDescription = reader.GetSqlString(3).StrictValue();
        int pageCount = reader.GetSqlInt32(4).StrictValue();

        await reader.ReadAsync();

        string pageTitle = reader.GetSqlString(0).StrictValue();
        string pageDescription = reader.GetSqlString(1).StrictValue();

        List<ISurveyQuestionModel> questions = [];

        await reader.ReadAsync();

        do
        {
            questions.Add(new SurveyQuestionModel(
                reader.GetSqlString(1).StrictValue()));
        }
        while (reader.Read());

        return new SurveyPageModel(
            surveyId,
            surveyTitle,
            surveyAuthor,
            surveyDescription,
            pageCount,
            surveyPageIndex,
            pageTitle,
            pageDescription,
            questions);
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

        await using SqlConnection connection = DefaultSqlConnection();

        await connection.OpenAsync();

        byte[] surveySessionToken = new byte[24];

        if (!Request.Cookies.TryGetValue("session", out string? sessionToken)
            || Convert.TryFromBase64String(sessionToken, surveySessionToken, out int bytesWritten)
            || bytesWritten != 24)
        {
            if (surveyPageIndexValue > 0)
                throw new Exception();

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
                sessionToken = Convert.ToBase64String((byte[])command.ExecuteScalar()));
        }

        SurveyPageModel? page = await QuerySurveyPageModel(
            connection,
            surveyIdValue,
            surveyPageIndexValue,
            surveySessionToken);

        if (page is null)
            throw new Exception();

        return View(page);
    }
}