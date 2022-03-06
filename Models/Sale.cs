namespace generic_market_csharp.Models
{
    public class Sale
    {
        public int Id {get; set;}
        public DateTime Date {get; set;}
        public float Total {get; set;}
        public float AmountPaid {get; set;}
        public float Change {get; set;}
    }
}