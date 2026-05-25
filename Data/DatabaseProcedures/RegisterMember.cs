using System.Data;
using System.Data.SqlTypes;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<int?> RegisterMember(
        SqlConnection connection,
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime birthDate,
        string passwordHash);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<int?> RegisterMember(
        SqlConnection connection,
        string firstName,
        string lastName,
        string phoneNumber,
        DateTime birthDate,
        string passwordHash)
    {
        await using SqlCommand command = new("register_member", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@first_name", SqlDbType.NVarChar, 255).Value = firstName;
        command.Parameters.Add("@last_name", SqlDbType.NVarChar, 255).Value = lastName;
        command.Parameters.Add("@phone_number", SqlDbType.VarChar, 13).Value = phoneNumber;
        command.Parameters.Add("@birth_date", SqlDbType.DateTime).Value = birthDate;
        command.Parameters.Add("@password_hash", SqlDbType.VarChar, 255).Value = passwordHash;

        return await command.ExecuteScalarAsync() as int?;
    }
}
