using System.ComponentModel.DataAnnotations;

namespace EnsinE.CRM.Models
{
    public class Cliente
    {
        public int ClienteId { get; set; }

        [Required]
        public string NomeCompleto { get; set; } = string.Empty;

        [Phone]
        public string Telefone { get; set; } = string.Empty;

        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [Range(0, 100)]
        public decimal Desconto { get; set; }

        public string Vendedor { get; set; } = string.Empty;

        // FK
        public int ProdutoId { get; set; }

        // Navegação
        public Produto Produto { get; set; } = null!;
    }
}
