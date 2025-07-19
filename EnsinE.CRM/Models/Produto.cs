// Models/Produto.cs
public class Produto
{
    public int ProdutoId { get; set; }
    public string Nome { get; set; } = null!;
    public decimal Preco { get; set; }

    public int ClienteId { get; set; }
    public Cliente Cliente { get; set; } = null!;
}