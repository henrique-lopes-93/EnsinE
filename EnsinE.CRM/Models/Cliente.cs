// Models/Cliente.cs
public class Cliente
{
    public int ClienteId { get; set; }
    public string NomeCompleto { get; set; } = null!;
    public ICollection<Produto> Produtos { get; set; } = new List<Produto>();
}
