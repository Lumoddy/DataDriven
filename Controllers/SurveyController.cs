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

    [NonAction]
    public async Task<(SurveyModel, SubmissionModel?)?> QuerySurveyPageModel(
        SqlConnection connection,
        int surveyId,
        byte[] surveySessionToken)
    {
        const string SURVEY_ID = "@surveyId";
        const string SURVEY_SESSION_TOKEN = "@survey_session_token";

        await using SqlCommand command = new(
            $"""
            SELECT
                {SqlSurvey.TABLE_TITLE},
                {SqlSurvey.TABLE_AUTHOR},
                {SqlSurvey.TABLE_DESCRIPTION}
            FROM
                {SqlSurvey.TABLE}
            WHERE
                {SqlSurvey.TABLE_ID} = {SURVEY_ID};

            SELECT
                {SqlSurveyPage.TABLE_INDEX},
                {SqlSurveyPage.TABLE_TITLE},
                {SqlSurveyPage.TABLE_DESCRIPTION}
            FROM
                {SqlSurveyPage.TABLE}
            WHERE
                {SqlSurveyPage.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyPage.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestion.TABLE_PAGE_INDEX},
                {SqlSurveyQuestion.TABLE_INDEX},
                {SqlSurveyQuestion.TABLE_TITLE},
                {SqlSurveyQuestion.TABLE_TYPE}
            FROM
                {SqlSurveyQuestion.TABLE}
            WHERE
                {SqlSurveyQuestion.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestion.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestion.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionAnswerOption.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionAnswerOption.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionAnswerOption.TABLE_INDEX},
                {SqlSurveyQuestionAnswerOption.TABLE_TEXT}
            FROM
                {SqlSurveyQuestionAnswerOption.TABLE}
            WHERE
                {SqlSurveyQuestionAnswerOption.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionAnswerOption.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionAnswerOption.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionAnswerOption.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionShowCondition.TABLE_INDEX},
                {SqlSurveyQuestionShowCondition.TABLE_TYPE},
                {SqlSurveyQuestionShowCondition.TABLE_IS_OR_OPERATOR}
            FROM
                {SqlSurveyQuestionShowCondition.TABLE}
            WHERE
                {SqlSurveyQuestionShowCondition.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionShowCondition.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionShowCondition.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionShowCondition.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_REFERENCED_PAGE_INDEX},
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_REFERENCED_QUESTION_INDEX}
            FROM
                {SqlSurveyQuestionShowConditionsRefArg.TABLE}
            WHERE
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsRefArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_INDEX},
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_ARG_VALUE}
            FROM
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE}
            WHERE
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsIntegerArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_INDEX},
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_ARG_VALUE}
            FROM
                {SqlSurveyQuestionShowConditionsTextArg.TABLE}
            WHERE
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionShowConditionsTextArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionValidationCondition.TABLE_INDEX},
                {SqlSurveyQuestionValidationCondition.TABLE_TYPE},
                {SqlSurveyQuestionValidationCondition.TABLE_IS_OR_OPERATOR}
            FROM
                {SqlSurveyQuestionValidationCondition.TABLE}
            WHERE
                {SqlSurveyQuestionValidationCondition.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionValidationCondition.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionValidationCondition.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionValidationCondition.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_REFERENCED_PAGE_INDEX},
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_REFERENCED_QUESTION_INDEX}
            FROM
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE}
            WHERE
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsRefArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_INDEX},
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_ARG_VALUE}
            FROM
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE}
            WHERE
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsIntegerArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_PAGE_INDEX},
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_QUESTION_INDEX},
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_CONDITION_INDEX},
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_INDEX},
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_ARG_VALUE}
            FROM
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE}
            WHERE
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_SURVEY_ID} = {SURVEY_ID}
            ORDER BY
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_PAGE_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_QUESTION_INDEX} ASC,
                {SqlSurveyQuestionValidationConditionsTextArg.TABLE_INDEX} ASC;

            SELECT
                {SqlSurveySession.TABLE_TOKEN},
                {SqlSurveySession.TABLE_EXPIRY},
                {SqlSurveySession.TABLE_SURVEY_ID}
            FROM
                {SqlSurveySession.TABLE}
            WHERE
                {SqlSurveySession.TABLE_TOKEN} = {SURVEY_SESSION_TOKEN},
                {SqlSurveySession.TABLE_SURVEY_ID} = {SURVEY_ID};
            """,
            connection);

        command.Parameters.Add(SURVEY_ID, SqlDbType.Int).Value
            = surveyId;
        command.Parameters.Add(SURVEY_SESSION_TOKEN, SqlDbType.Binary, 32).Value
            = surveySessionToken;

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