using DataDriven.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;

namespace DataDriven.Controllers;

[Route("")]
public class IndexController(
    IConfiguration configuration,
    IDatabaseProcedureService procedureService,
    ILogger<IndexController> logger) : Controller
{
    [Route("")]
    public async Task<IActionResult> Index()
    {
        await using SqlConnection connection = new(configuration.GetConnectionString("Default"));

        await connection.OpenAsync();

        return View(await procedureService.QuerySurveys(connection));
    }
}