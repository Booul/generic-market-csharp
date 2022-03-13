using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;

namespace generic_market_csharp.Controllers
{
    public class DiscountedSaleController: Controller
    {
        private readonly ApplicationDbContext database;

        public DiscountedSaleController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(DiscountedSaleDTO discountedSaleDTO) {
            if (ModelState.IsValid) {
                DiscountedSale discountedSale = new DiscountedSale ();
                discountedSale.Name = discountedSaleDTO.Name;
                discountedSale.Product = database.Products.First(product => product.Id == discountedSaleDTO.ProductId);
                discountedSale.Percentage = discountedSaleDTO.Percentage;
                discountedSale.Status = true;

                database.DiscountedSales.Add(discountedSale);
                database.SaveChanges();

                return RedirectToAction("DiscountedSales", "Management");
            } else {
                ViewBag.Products = database.Products.ToList();

                return View("../Management/NewDiscountedSale");
            }
        }

        [HttpPost]
        public IActionResult Update(DiscountedSaleDTO discountedSaleDTO) {
            if (ModelState.IsValid) {
                DiscountedSale discountedSale = database.DiscountedSales.First(discountedSale => discountedSale.Id == discountedSaleDTO.Id);
                discountedSale.Name = discountedSaleDTO.Name;
                discountedSale.Product = database.Products.First(discountedSale => discountedSale.Id == discountedSaleDTO.ProductId);
                discountedSale.Percentage = discountedSaleDTO.Percentage;

                database.SaveChanges();

                return RedirectToAction("DiscountedSales", "Management");
            } else {
                return View("../Management/EditDiscountedSale");
            }
        }

        [HttpPost]
        public IActionResult Delete(int id) {
            if (id > 0) {
                DiscountedSale discountedSale = database.DiscountedSales.First(discountedSale => discountedSale.Id == id);
                discountedSale.Status = false;

                database.SaveChanges();
            }

            return RedirectToAction("DiscountedSales", "Management");
        }
    }
}