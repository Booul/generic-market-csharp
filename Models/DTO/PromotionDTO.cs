using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class PromotionDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Promotion name is required.")]
        [StringLength(100, ErrorMessage = "Promotion name is too long.")]
        [MinLength(2, ErrorMessage = "Promotion name is too small.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Promotion product is required.")]
        public int ProductId {get; set;}

        [Required(ErrorMessage = "Promotion percentage is required.")]
        [Range(0, 100, ErrorMessage = "Invalid percentage.")]
        public float Percentage {get; set;}
    }
}