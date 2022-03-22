namespace generic_market_csharp.Models
{
    public class Output
    {
        public int Id {get; set;}
        public Product Product {get; set;}
        public float Amount {get; set;}
        public float SalePrice {get; set;}
        public DateTime Date {get; set;}
        public Sale Sale {get; set;}
    }
}