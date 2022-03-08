using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class CategoryDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome da categoria é obrigatória.")]
        [StringLength(100, ErrorMessage = "Nome da categoria é muito grande.")]
        [MinLength(2, ErrorMessage = "Nome da categoria é muito pequeno.")]
        public string Name {get; set;}
    }
}