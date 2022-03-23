using generic_market_csharp.Models.DTO;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Authorization;

namespace generic_market_csharp.Controllers
{
    [Authorize]
    public class OutputController: Controller
    {
        private readonly ApplicationDbContext database;

        public OutputController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult SaveRange([FromBody] OutputDTO[] outputsDTO) {
            List<Output> outputs = new List<Output>();

            foreach (var outputDTO in outputsDTO)
            {
                Output output = new Output();
                output.Amount = outputDTO.Amount;
                output.SalePrice = outputDTO.SalePrice;
                output.Sale = database.Sales.Single(sale => sale.Id == outputDTO.SaleId);
                output.Product = database.Products.Single(product => product.Id == outputDTO.ProductId);
                output.Date = DateTime.Now.ToUniversalTime();

                outputs.Add(output);
            }

            database.Outputs.AddRange(outputs);
            database.SaveChanges();

            return Created("Output/SaveAll", outputs);
        }
    }
}