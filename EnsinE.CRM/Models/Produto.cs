// Models/Produto.cs
using System.ComponentModel.DataAnnotations;

namespace EnsinE.CRM.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }

        [Required]
        public string Nome { get; set; } = string.Empty;

        [Range(0, double.MaxValue)]
        public decimal Preco { get; set; }

        public bool Situacao { get; set; } = true;

        [Range(0, 100)]
        public decimal Comissao { get; set; }
    }
}
