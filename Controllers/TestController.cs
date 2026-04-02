using System.Data;
using System.Text;
using DataDriven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataDriven.Controllers;

[Route("test")]
public class TestController(
    IConfiguration configuration,
    IDatabaseEnumService enumService) : Controller
{
    public string Index()
    {
        StringBuilder builder = new();
        foreach (var pair in enumService.SurveyQuestionAnswerTypeMap)
        {
            builder.Append(pair.Key);
            builder.Append(" = ");
            builder.Append(pair.Value);
            builder.Append(",<br>");
        }

        return builder.ToString();
    }
}