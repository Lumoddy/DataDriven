using System.Data;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<byte[]> StartSurveySession(
        SqlConnection connection,
        int surveyId);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<byte[]> StartSurveySession(
        SqlConnection connection,
        int surveyId)
    {
        await using SqlCommand command = new(
            "start_survey_session",
            connection) { CommandType = CommandType.StoredProcedure };

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;

        return (byte[])(await command.ExecuteScalarAsync())!;
    }
}