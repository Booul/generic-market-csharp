using generic_market_csharp.Models.DTO;
using generic_market_csharp.Models;
using Microsoft.AspNetCore.Mvc;
using generic_market_csharp.Data;

namespace generic_market_csharp.Controllers
{
    public class SupplierController: Controller
    {
        private readonly ApplicationDbContext database;

        public SupplierController(ApplicationDbContext database) {
            this.database = database;
        }

        [HttpPost]
        public IActionResult Save(SupplierDTO supplierDTO) {
            if (ModelState.IsValid) {
                Supplier supplier = new Supplier();
                supplier.Name = supplierDTO.Name;
                supplier.Email = supplierDTO.Email;
                supplier.Phone = supplierDTO.Phone;
                supplier.Status = true;

                database.Suppliers.Add(supplier);
                database.SaveChanges();

                return RedirectToAction("Suppliers", "Management");
            } else {
                return View("../Management/NewSupplier");
            }
        }

        [HttpPost]
        public IActionResult Update(SupplierDTO supplierDTO) {
            if (ModelState.IsValid) {
                Supplier supplier = database.Suppliers.First(supplier => supplier.Id == supplierDTO.Id);
                supplier.Name = supplierDTO.Name;
                supplier.Email = supplierDTO.Email;
                supplier.Phone = supplierDTO.Phone;

                database.SaveChanges();

                return RedirectToAction("Suppliers", "Management");
            } else {
                return View("../Management/EditSupplier");
            }
        }
    }
}