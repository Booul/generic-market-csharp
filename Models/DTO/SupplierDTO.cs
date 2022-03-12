using System.ComponentModel.DataAnnotations;

namespace generic_market_csharp.Models.DTO
{
    public class SupplierDTO
    {
        [Required]
        public int Id {get; set;}

        [Required(ErrorMessage = "Supplier name is required.")]
        [StringLength(100, ErrorMessage = "Supplier name is too long.")]
        [MinLength(2, ErrorMessage = "Supplier name is too small.")]
        public string Name {get; set;}

        [Required(ErrorMessage = "Supplier's email is mandatory.")]
        [EmailAddress(ErrorMessage = "Email inválido.")]
        public string Email {get; set;}

        [Required(ErrorMessage = "Supplier's phone number is required.")]
        [Phone(ErrorMessage = "Invalid phone.")]
        public string Phone {get; set;}
    }
}