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

        [HttpPost]
        public IActionResult Update(CategoryDTO categoryDTO) {
            if (ModelState.IsValid) {
                Category category = database.Categories.First(category => category.Id == categoryDTO.Id);
                category.Name = categoryDTO.Name;

                database.SaveChanges();

                return RedirectToAction("Categories", "Management");
            } else {
                return View("../Management/EditCategory");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                Category category = database.Categories.First(category => category.Id == id);
                category.Status = false;

                database.SaveChanges();
            }

            return RedirectToAction("Categories", "Management");
        }
    }
}