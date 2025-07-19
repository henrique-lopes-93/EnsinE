// Data/ApplicationDbContext.cs
using Microsoft.EntityFrameworkCore;
using EnsinE.CRM.Models;

namespace EnsinE.CRM.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Produto> Produtos => Set<Produto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Produto>()
            .HasOne(p => p.Cliente)
            .WithMany(c => c.Produtos)
            .HasForeignKey(p => p.ClienteId);
    }
}
