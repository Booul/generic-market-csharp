namespace generic_market_csharp.Models
{
    public class Product
    {
        public int Id {get; set;}
        public string Name {get; set;}
        public Category Category {get; set;}
        public Supplier Supplier {get; set;}
        public float PurchasePrice {get; set;}
        public float SalePrice {get; set;}
        public int MeasurementType {get; set;}
        public bool Status {get; set;}
    }
}