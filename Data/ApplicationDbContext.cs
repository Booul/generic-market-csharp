using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

using generic_market_csharp.Models;

namespace generic_market_csharp.Data;

public class ApplicationDbContext : IdentityDbContext
{
    public DbSet<Category> Categories {get; set;}
    public DbSet<Supplier> Suppliers {get; set;}
    public DbSet<Product> Products {get; set;}
    public DbSet<DiscountedSale> DiscountedSales {get; set;}
    public DbSet<Stock> Stocks {get; set;}
    public DbSet<Output> Outputs {get; set;}
    public DbSet<Sale> Sales {get; set;}

    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }
}
