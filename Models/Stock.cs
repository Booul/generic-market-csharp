namespace generic_market_csharp.Models
{
    public class Stock
    {
        public int Id {get; set;}
        public Product Product {get; set;}
        public int ProductId {get; set;}
        public float Amount {get; set;}
    }
}