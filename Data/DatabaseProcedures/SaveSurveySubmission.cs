using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<int?> SaveSurveySubmission(
        SqlConnection connection,
        int surveyId,
        byte[] surveySessionToken,
        ulong surveySessionIp,
        int? registeredMemberId = null);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<int?> SaveSurveySubmission(
        SqlConnection connection,
        int surveyId,
        byte[] surveySessionToken,
        ulong surveySessionIp,
        int? registeredMemberId = null)
    {
        await using SqlCommand command = new("save_survey_submission", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;
        command.Parameters.Add("@survey_session_token", SqlDbType.Binary, 32).Value
            = surveySessionToken;
        command.Parameters.Add("@survey_session_ip", SqlDbType.BigInt).Value
            = surveySessionIp;
        command.Parameters.Add("@registered_member_id", SqlDbType.Int).Value
            = registeredMemberId ?? (object)DBNull.Value;

        return await command.ExecuteScalarAsync() as int?;
    }
}