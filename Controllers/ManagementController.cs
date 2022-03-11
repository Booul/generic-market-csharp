using generic_market_csharp.Data;
using generic_market_csharp.Models;
using generic_market_csharp.Models.DTO;
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
            List<Category> categories = database.Categories
                .Where(category => category.Status)
                .ToList();

            return View(categories);
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult EditCategory(int id) {
            Category category = database.Categories.First(category => category.Id == id);

            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = category.Id;
            categoryDTO.Name = category.Name;

            return View(categoryDTO);
        }

        public IActionResult Suppliers(){
            List<Supplier> suppliers = database.Suppliers.ToList();

            return View(suppliers);
        }

        public IActionResult NewSupplier() {
            return View();
        }

        public IActionResult EditSupplier(int id) {
            Supplier supplier = database.Suppliers.First(supplier => supplier.Id == id);

            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.Id = supplier.Id;
            supplierDTO.Name = supplier.Name;
            supplierDTO.Email = supplier.Email;
            supplierDTO.Phone = supplier.Phone;

            return View(supplierDTO);
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