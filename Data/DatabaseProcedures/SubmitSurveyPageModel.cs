using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<IEnumerable<(
        int questionIndex,
        int failedConditionIndex)>?> SubmitSurveyPageModel(
        SqlConnection connection,
        int surveyId,
        int surveyPageIndex,
        byte[] surveySessionToken,
        IEnumerable<IReadOnlyList<object?>?> answers);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<IEnumerable<(
        int questionIndex,
        int failedConditionIndex)>?> SubmitSurveyPageModel(
        SqlConnection connection,
        int surveyId,
        int surveyPageIndex,
        byte[] surveySessionToken,
        IEnumerable<IReadOnlyList<object?>?> answers)
    {
        await using SqlCommand command = new("submit_survey_page_model", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;
        command.Parameters.Add("@survey_page_index", SqlDbType.Int).Value
            = surveyPageIndex;
        command.Parameters.Add("@survey_session_token", SqlDbType.Binary, 32).Value
            = surveySessionToken;

        DataTable answerDataTable = new("submit_session_page_answers");

        answerDataTable.Columns.Add("survey_question_index", typeof(SqlInt32));
        answerDataTable.Columns.Add("submission_answer_index", typeof(SqlInt32));
        answerDataTable.Columns.Add("submission_answer_integer", typeof(SqlInt32));
        answerDataTable.Columns.Add("submission_answer_text", typeof(SqlString));

        foreach ((int questionIndex, IReadOnlyList<object?>? questionAnswers) in answers.Index())
        {
            if (questionAnswers == null)
                continue;

            foreach ((int answerIndex, object? answer) in questionAnswers.Index())
            {
                if (answer == null)
                {
                    answerDataTable.Rows.Add(
                        new SqlInt32(questionIndex),
                        new SqlInt32(answerIndex),
                        SqlInt32.Null,
                        SqlString.Null);
                }
                else if (answer as bool? is bool answerBool)
                {
                    if (answerBool)
                    {
                        answerDataTable.Rows.Add(
                            new SqlInt32(questionIndex),
                            new SqlInt32(answerIndex),
                            SqlInt32.Null,
                            SqlString.Null);
                    }
                }
                else if (answer as string is string answerText)
                {
                    answerDataTable.Rows.Add(
                        new SqlInt32(questionIndex),
                        new SqlInt32(answerIndex),
                        SqlInt32.Null,
                        new SqlString(answerText));
                }
                else if (answer as int? is int answerInteger)
                {
                    answerDataTable.Rows.Add(
                        new SqlInt32(questionIndex),
                        new SqlInt32(answerIndex),
                        new SqlInt32(answerInteger),
                        SqlString.Null);
                }
                else
                {
                    throw new InvalidDataException(
                        $"Answer has invalid type for survey id '{surveyId}' page " +
                        $"'{surveyPageIndex}' question '{questionIndex}' answer " +
                        $"'{answerIndex}'.");
                }
            }
        }

        command.Parameters.Add(new()
        {
            ParameterName = "@session_page_answers",
            SqlDbType = SqlDbType.Structured,
            TypeName = "submit_session_page_answers_table",
            Value = answerDataTable,
        });

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!reader.HasRows)
            return null;

        List<(
            int questionIndex,
            int failedConditionIndex)>? errors = null;

        while (await reader.ReadAsync())
        {
            (errors ??= []).Add((
                questionIndex: reader.GetInt32(0),
                failedConditionIndex: reader.GetInt32(1)));
        }

        return errors;
    }
}