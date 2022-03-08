using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;

namespace generic_market_csharp.Controllers
{
    public class CategoryController: Controller
    {
        private readonly ApplicationDbContext database;

        public CategoryController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(CategoryDTO categoryDTO) {
            if (ModelState.IsValid) {
                Category category = new Category();
                category.Name = categoryDTO.Name;
                category.Status = true;

                database.Categories.Add(category);
                database.SaveChanges();

                return RedirectToAction("Categories", "Management");
            } else {
                return View("../Management/NewCategory");
            }
        }
    }
}