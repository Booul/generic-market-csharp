using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class ProductDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Product name is required.")]
        [StringLength(100, ErrorMessage = "Product name is too long.")]
        [MinLength(2, ErrorMessage = "Product name is too small.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Product category is required.")]
        public int CategoryID {get; set;}

        [Required(ErrorMessage = "Product supplier is required.")]
        public int SupplierID {get; set;}

        [Required(ErrorMessage = "Purchase price of the product is required.")]
        public float PurchasePrice {get; set;}

        [Required(ErrorMessage = "Sale price of the product is required.")]
        public float SalePrice {get; set;}

        [Required(ErrorMessage = "Product measurement type is mandatory.")]
        [Range(1, 3, ErrorMessage = "Invalid measurement type.")]
        public int MeasurementType {get; set;}
    }
}