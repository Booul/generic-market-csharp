using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Category name is required.")]
        [StringLength(100, ErrorMessage = "Category name is too long.")]
        [MinLength(2, ErrorMessage = "Category name is too small.")]
        public string Name {get; set;}
    }
}