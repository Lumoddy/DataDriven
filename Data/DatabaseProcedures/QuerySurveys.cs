using System.Data;
using DataDriven.Models;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<List<SurveyModel>> QuerySurveys(
        SqlConnection connection);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<List<SurveyModel>> QuerySurveys(
        SqlConnection connection)
    {
        await using SqlCommand command = new("query_surveys", connection);
        command.CommandType = CommandType.StoredProcedure;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        List<SurveyModel> surveys = [];

        while (await reader.ReadAsync())
        {
            surveys.Add(new(
                Id: reader.GetSqlInt32(0).StrictValue(),
                Title: reader.GetSqlString(1).StrictValue(),
                Author: reader.GetSqlString(2).StrictValue(),
                Description: reader.GetSqlString(3).StrictValue(),
                PageCount: reader.GetSqlInt32(4).StrictValue()));
        }

        return surveys;
    }
}