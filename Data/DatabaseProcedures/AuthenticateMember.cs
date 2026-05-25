using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

/// <summary>
/// Result of member authentication lookup.
/// </summary>
public record AuthenticationResult(int? MemberId, string? PasswordHash);

public partial interface IDatabaseProcedureService
{
    public Task<AuthenticationResult?> AuthenticateMember(
        SqlConnection connection,
        string phoneNumber);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<AuthenticationResult?> AuthenticateMember(
        SqlConnection connection,
        string phoneNumber)
    {
        await using SqlCommand command = new("authenticate_member", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@phone_number", SqlDbType.VarChar, 13).Value = phoneNumber;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();
        
        if (await reader.ReadAsync())
        {
            int memberId = reader.GetInt32(0);
            string passwordHash = reader.GetString(1);
            return new AuthenticationResult(memberId, passwordHash);
        }

        return null;
    }
}
