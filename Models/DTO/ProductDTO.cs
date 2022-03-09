using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class ProductDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome do produto é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome do produto é muito grande.")]
        [MinLength(2, ErrorMessage = "Nome do produto é muito pequeno.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Categoria do produto é obrigatório.")]
        public int CategoryID {get; set;}

        [Required(ErrorMessage = "Fornecedor do produto é obrigatório.")]
        public int SupplierID {get; set;}

        [Required(ErrorMessage = "Preço de custo do produto é obrigatório.")]
        public float PurchasePrice {get; set;}

        [Required(ErrorMessage = "Preço de venda do produto é obrigatório.")]
        public float SalePrice {get; set;}

        [Required(ErrorMessage = "Tipo de medição do produto é obrigatório.")]
        [Range(1, 3, ErrorMessage = "Tipo de medição inválida.")]
        public int MeasurementType {get; set;}
    }
}