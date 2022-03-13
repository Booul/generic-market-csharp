using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class DiscountedSaleDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Discounted sale name is required.")]
        [StringLength(100, ErrorMessage = "Discounted sale name is too long.")]
        [MinLength(2, ErrorMessage = "Discounted sale name is too small.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Discounted sale product is required.")]
        public int ProductId {get; set;}

        [Required(ErrorMessage = "Discounted sale percentage is required.")]
        [Range(0, 100, ErrorMessage = "Invalid percentage.")]
        public float Percentage {get; set;}
    }
}