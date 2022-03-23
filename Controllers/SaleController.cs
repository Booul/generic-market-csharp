using generic_market_csharp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;
using generic_market_csharp.Models;

namespace generic_market_csharp.Controllers
{
    public class SaleController: Controller
    {
        private readonly ApplicationDbContext database;

        public SaleController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save([FromBody] SaleDTO saleDTO) {
            Sale sale = new Sale();
            sale.Total = saleDTO.Total;
            sale.AmountPaid = saleDTO.AmountPaid;
            sale.Change = saleDTO.Change;
            sale.Date = DateTime.Now.ToUniversalTime();

            database.Sales.Add(sale);
            database.SaveChanges();

            return CreatedAtAction(nameof(Save), new { id = sale.Id }, sale);
        }
    }
}