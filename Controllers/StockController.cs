using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;
using Microsoft.EntityFrameworkCore;

namespace generic_market_csharp.Controllers
{
    public class StockController: Controller
    {
        private readonly ApplicationDbContext database;

        public StockController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(Stock stock) {
            database.Stocks.Add(stock);
            database.SaveChanges();

            return RedirectToAction("Stocks", "Management");
        }

        [HttpPost]
        public IActionResult Update(ProductDTO productDTO) {
            if (ModelState.IsValid) {
                Product product = database.Products.First(product => product.Id == productDTO.Id);
                product.Name = productDTO.Name;
                product.Category = database.Categories.First(category => category.Id == productDTO.CategoryID);
                product.Supplier = database.Suppliers.First(supplier => supplier.Id == productDTO.SupplierID);
                product.PurchasePrice = productDTO.PurchasePrice;
                product.SalePrice = productDTO.SalePrice;
                product.MeasurementType = productDTO.MeasurementType;

                database.SaveChanges();

                return RedirectToAction("Products", "Management");
            } else {
                return View("../Management/EditProduct");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                Product product = database.Products.First(product => product.Id == id);
                product.Status = false;

                database.SaveChanges();
            }

            return RedirectToAction("Products", "Management");
        }
    }
}