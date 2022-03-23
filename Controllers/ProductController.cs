using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;

namespace generic_market_csharp.Controllers
{
    [Authorize]
    public class ProductController: Controller
    {
        private readonly ApplicationDbContext database;

        public ProductController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Retrieve(int id) {
            if (id > 0) {
                Product? product =
                    database.Products.
                        Include(product => product.Category).
                        Include(product => product.Supplier).
                        Where(product => product.Status).
                        SingleOrDefault(product => product.Id == id);

                if (product != null) {
                    Response.StatusCode = 200;

                    DiscountedSale? discountedSale = database.DiscountedSales.
                        Where(discountedSale => discountedSale.Status).
                        FirstOrDefault(discountedSale => discountedSale.Product.Id == product.Id);

                    if (discountedSale != null)
                        product.SalePrice -= (product.SalePrice * discountedSale.Percentage);

                    Stock? stock = database.Stocks.SingleOrDefault(stock => stock.Product.Id == product.Id);
                    if (stock == null) {
                        Response.StatusCode = 404;
                        product = null;
                    }

                    return Json(product);
                }
                else {
                    Response.StatusCode = 404;
                    return Json(null);
                }
            }

            Response.StatusCode = 500;
            return Json(null);
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