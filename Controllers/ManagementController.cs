using generic_market_csharp.Data;
using generic_market_csharp.Models;
using generic_market_csharp.Models.DTO;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace generic_market_csharp.Controllers
{
    [Authorize]
    public class ManagementController: Controller
    {
        private readonly ApplicationDbContext database;

        public ManagementController(ApplicationDbContext database) {
            this.database = database;
        }

        public IActionResult Index() {
            return View();
        }

        public IActionResult Categories(){
            List<Category> categories = database.Categories
                .Where(category => category.Status)
                .ToList();

            return View(categories);
        }

        public IActionResult NewCategory() {
            return View();
        }

        public IActionResult EditCategory(int id) {
            Category category = database.Categories.First(category => category.Id == id);

            CategoryDTO categoryDTO = new CategoryDTO();
            categoryDTO.Id = category.Id;
            categoryDTO.Name = category.Name;

            return View(categoryDTO);
        }

        public IActionResult Suppliers(){
            List<Supplier> suppliers = database.Suppliers
                .Where(supplier => supplier.Status)
                .ToList();

            return View(suppliers);
        }

        public IActionResult NewSupplier() {
            return View();
        }

        public IActionResult EditSupplier(int id) {
            Supplier supplier = database.Suppliers.First(supplier => supplier.Id == id);

            SupplierDTO supplierDTO = new SupplierDTO();
            supplierDTO.Id = supplier.Id;
            supplierDTO.Name = supplier.Name;
            supplierDTO.Email = supplier.Email;
            supplierDTO.Phone = supplier.Phone;

            return View(supplierDTO);
        }

        public IActionResult Products() {
            List<Product> products = database.Products
                .Include(products => products.Category)
                .Include(products => products.Supplier)
                .Where(product => product.Status)
                .ToList();

            return View(products);
        }

        public IActionResult NewProduct() {
            ViewBag.Categories = database.Categories.ToList();
            ViewBag.Suppliers = database.Suppliers.ToList();

            return View();
        }

        public IActionResult EditProduct(int id) {
            ViewBag.Categories = database.Categories.ToList();
            ViewBag.Suppliers = database.Suppliers.ToList();

            Product product = database.Products
                .Include(products => products.Category)
                .Include(products => products.Supplier)
                .First(product => product.Id == id);

            ProductDTO productDTO = new ProductDTO();
            productDTO.Id = product.Id;
            productDTO.Name = product.Name;
            productDTO.CategoryID = product.Category.Id;
            productDTO.SupplierID = product.Supplier.Id;
            productDTO.PurchasePrice = product.PurchasePrice;
            productDTO.SalePrice = product.SalePrice;
            productDTO.MeasurementType = product.MeasurementType;

            return View(productDTO);
        }

        public IActionResult DiscountedSales() {
            List<DiscountedSale> discountedSales =
                database.DiscountedSales
                .Include(discountedSales => discountedSales.Product)
                .Where(discountedSales => discountedSales.Status)
                .ToList();

            return View(discountedSales);
        }

        public IActionResult NewDiscountedSale() {
            ViewBag.Products = database.Products.ToList();

            return View();
        }

        public IActionResult EditDiscountedSale(int id) {
            ViewBag.Products = database.Products.ToList();

            DiscountedSale discountedSale = database.DiscountedSales
                .Include(discountedSale => discountedSale.Product)
                .First(product => product.Id == id);

            DiscountedSaleDTO discountedSaleDTO = new DiscountedSaleDTO();
            discountedSaleDTO.Id = discountedSale.Id;
            discountedSaleDTO.Name = discountedSale.Name;
            discountedSaleDTO.ProductId = discountedSale.Product.Id;
            discountedSaleDTO.Percentage = discountedSale.Percentage;

            return View(discountedSaleDTO);
        }

        public IActionResult Stocks(){
            List<Stock> stocks = database.Stocks.Include(stock => stock.Product).ToList();

            return View(stocks);
        }

        public IActionResult NewStock() {
            ViewBag.Products = database.Products.ToList();
            
            return View();
        }

        public IActionResult Sales() {
            List<Sale> sales = database.Sales.ToList();

            return View(sales);
        }

        [HttpPost]
        public IActionResult SalesReport() {
            List<Sale> sales = database.Sales.ToList();

            return Ok(sales);
        }
    }
}