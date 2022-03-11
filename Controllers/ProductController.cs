using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;

namespace generic_market_csharp.Controllers
{
    public class ProductController: Controller
    {
        private readonly ApplicationDbContext database;

        public ProductController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(ProductDTO productDTO) {
            if (ModelState.IsValid) {
                Product product = new Product();
                product.Name = productDTO.Name;
                product.Category = database.Categories.First(category => category.Id == productDTO.CategoryID);
                product.Supplier = database.Suppliers.First(supplier => supplier.Id == productDTO.SupplierID);
                product.PurchasePrice = productDTO.PurchasePrice;
                product.SalePrice = productDTO.SalePrice;
                product.MeasurementType = productDTO.MeasurementType;
                product.Status = true;

                database.Products.Add(product);
                database.SaveChanges();

                return RedirectToAction("Products", "Management");
            } else {
                ViewBag.Categories = database.Categories.ToList();
                ViewBag.Suppliers = database.Suppliers.ToList();

                return View("../Management/NewProduct");
            }
        }
    }
}