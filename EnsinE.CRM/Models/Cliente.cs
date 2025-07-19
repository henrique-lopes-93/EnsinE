using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;

namespace EnsinE.CRM.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required(ErrorMessage = "O Nome Completo é obrigatório")]
        [Display(Name = "Nome Completo")]
        public string NomeCompleto { get; set; } = string.Empty;

        [Phone(ErrorMessage = "Telefone inválido")]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress(ErrorMessage = "E-mail inválido")]
        public string Email { get; set; } = string.Empty;

        [Range(0, 100, ErrorMessage = "O desconto deve estar entre 0 e 100%")]
        [Display(Name = "Desconto (%)")]
        public decimal Desconto { get; set; }

        [Required(ErrorMessage = "O Vendedor é obrigatório")]
        public string Vendedor { get; set; } = string.Empty;

        [Required(ErrorMessage = "Selecione um produto")]
        [Display(Name = "Produto")]
        public int? ProdutoId { get; set; }


        [ValidateNever]
        public Produto Produto { get; set; } = null!;
    }
}
