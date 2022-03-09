using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class SupplierDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Nome do fornecedor é obrigatório.")]
        [StringLength(100, ErrorMessage = "Nome do fornecedor é muito grande.")]
        [MinLength(2, ErrorMessage = "Nome do fornecedor é muito pequeno.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "E-mail do fornecedor é obrigatório.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Telefone do fornecedor é obrigatório.")]
        [EmailAddress(ErrorMessage = "Telefone inválido.")]
        public string Phone {get; set;}
    }
}