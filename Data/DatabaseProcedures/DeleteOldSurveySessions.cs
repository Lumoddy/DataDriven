using System.Data;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task DeleteOldSurveySessions(SqlConnection connection);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task DeleteOldSurveySessions(SqlConnection connection)
    {
        await using SqlCommand command = new(
            "delete_old_survey_sessions",
            connection) { CommandType = CommandType.StoredProcedure };

        await command.ExecuteNonQueryAsync();
    }
}