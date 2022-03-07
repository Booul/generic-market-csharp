using Microsoft.AspNetCore.Mvc;

namespace generic_market_csharp.Controllers
{
    public class ManagementController: Controller
    {
        public IActionResult Index() {
            return View();
        }
    }
}