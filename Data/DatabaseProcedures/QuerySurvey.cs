using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.RegularExpressions;
using DataDriven.Models;
using Microsoft.Data.SqlClient;

namespace DataDriven.Data;

public partial interface IDatabaseProcedureService
{
    public Task<SurveyModel?> QuerySurvey(
        SqlConnection connection,
        int surveyId);
}

public partial class DatabaseProcedureService : IDatabaseProcedureService
{
    public async Task<SurveyModel?> QuerySurvey(
        SqlConnection connection,
        int surveyId)
    {
        await using SqlCommand command = new("query_survey", connection);
        command.CommandType = CommandType.StoredProcedure;

        command.Parameters.Add("@survey_id", SqlDbType.Int).Value
            = surveyId;

        await using SqlDataReader reader = await command.ExecuteReaderAsync();

        if (!await reader.ReadAsync())
            return null;

        SurveyModel survey = new(
            Id: surveyId,
            Title: reader.GetSqlString(0).StrictValue(),
            Author: reader.GetSqlString(1).StrictValue(),
            Description: reader.GetSqlString(2).StrictValue(),
            PageCount: reader.GetSqlInt32(3).StrictValue());

        return survey;
    }
}