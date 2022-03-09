using Microsoft.AspNetCore.Mvc;

namespace generic_market_csharp.Controllers
{
    public class ManagementController: Controller
    {
        public IActionResult Index() {
            return View();
        }

        public IActionResult Categories(){
            return View();
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult Suppliers(){
            return View();
        }

        public IActionResult NewSupplier() {
            return View();
        }
    }
}