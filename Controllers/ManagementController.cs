using generic_market_csharp.Data;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;

namespace generic_market_csharp.Controllers
{
    public class ManagementController: Controller
    {
        private readonly ApplicationDbContext database;

        public ManagementController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Categories(){
            List<Category> categories = database.Categories.ToList();

            return View(categories);
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

        public IActionResult Products(){
            return View();
        }

        public IActionResult NewProduct() {
            ViewBag.Categories = database.Categories.ToList();
            ViewBag.Suppliers = database.Suppliers.ToList();

            return View();
        }
    }
}