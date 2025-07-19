// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using EnsinE.CRM.Models;

namespace EnsinE.CRM.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Produto> Produtos { get; set; } = default!;


    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Cliente>()
        .HasOne(c => c.Produto)
        .WithMany() // Produto não precisa conhecer os clientes
        .HasForeignKey(c => c.ProdutoId);

  
         
    }

}
