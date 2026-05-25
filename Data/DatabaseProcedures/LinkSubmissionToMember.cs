using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<bool> LinkSubmissionToMember(
        SqlConnection connection,
        int surveyId,
        int submissionIndex,
        int registeredMemberId);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<bool> LinkSubmissionToMember(
        SqlConnection connection,
        int surveyId,
        int submissionIndex,
        int registeredMemberId)
    {
        await using SqlCommand command = new("link_submission_to_member", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value = surveyId;
        command.Parameters.Add("@submission_index", SqlDbType.Int).Value = submissionIndex;
        command.Parameters.Add("@registered_member_id", SqlDbType.Int).Value = registeredMemberId;

        int rowsAffected = await command.ExecuteScalarAsync() as int? ?? 0;
        return rowsAffected > 0;
    }
}
