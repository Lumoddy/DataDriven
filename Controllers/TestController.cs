using DataDriven.Data;
using Microsoft.AspNetCore.Mvc;

namespace DataDriven.Controllers;

[Route("test")]
public class TestController(
    IConfiguration configuration,
    IDatabaseEnumService enumService) : Controller
{
    public IConfiguration Configuration => configuration;
    public IDatabaseEnumService EnumService => enumService;

    public IActionResult Index() => View(this);
}