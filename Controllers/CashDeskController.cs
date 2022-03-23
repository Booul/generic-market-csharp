using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Authorization;

namespace generic_market_csharp.Controllers;

[Authorize]
[Route("")]
public class CashDeskController : Controller
{
    private readonly ILogger<CashDeskController> _logger;

    public CashDeskController(ILogger<CashDeskController> logger)
    {
        _logger = logger;
    }

    [Route("")]
    public IActionResult Index()
    {
        return View();
    }

    [Route("Error")]
    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
