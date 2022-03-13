using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;

namespace generic_market_csharp.Controllers
{
    public class PromotionController: Controller
    {
        private readonly ApplicationDbContext database;

        public PromotionController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(PromotionDTO promotionDTO) {
            if (ModelState.IsValid) {
                Promotion promotion = new Promotion();
                promotion.Name = promotionDTO.Name;
                promotion.Product = database.Products.First(product => product.Id == promotionDTO.ProductId);
                promotion.Percentage = promotionDTO.Percentage;
                promotion.Status = true;

                database.Promotions.Add(promotion);
                database.SaveChanges();

                return RedirectToAction("Promotion", "Management");
            } else {
                ViewBag.Products = database.Products.ToList();

                return View("../Management/NewPromotion");
            }
        }
    }
}