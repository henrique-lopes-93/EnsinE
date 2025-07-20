using EnsinE.CRM.Data;
using EnsinE.CRM.Models;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

using (var scope = app.Services.CreateScope())
{
    var db = scope.ServiceProvider.GetRequiredService<ApplicationDbContext>();
    int retries = 0;
    int maxRetries = 10;
    while (retries < maxRetries)
    {
        try
        {
            db.Database.Migrate();
            break;
        }
        catch (Exception ex)
        {
            retries++;
            Console.WriteLine($"Tentativa {retries}: Falha ao conectar ao banco. Erro: {ex.Message}");
            Thread.Sleep(3000);
        }
    }

    if (!db.Produtos.Any())
    {
        var produtos = new List<Produto>
        {
            new Produto { Nome = "Curso de Excel", Preco = 499.90m, Situacao = true, Comissao = 10 },
            new Produto { Nome = "Curso de Power BI", Preco = 699.90m, Situacao = true, Comissao = 12 },
            new Produto { Nome = "Curso de SQL", Preco = 599.00m, Situacao = true, Comissao = 11 },
            new Produto { Nome = "Curso de Python", Preco = 799.00m, Situacao = true, Comissao = 15 },
            new Produto { Nome = "Curso Inativo", Preco = 199.90m, Situacao = false, Comissao = 9 },
            new Produto { Nome = "Curso de Análise de Dados", Preco = 899.90m, Situacao = true, Comissao = 14 },
            new Produto { Nome = "Curso de Gestão Ágil", Preco = 749.00m, Situacao = true, Comissao = 13 },
            new Produto { Nome = "Curso de Comunicação Profissional", Preco = 399.90m, Situacao = true, Comissao = 9 },
            new Produto { Nome = "Curso Inativo", Preco = 399.90m, Situacao = false, Comissao = 9 }
        };

        db.Produtos.AddRange(produtos);
        db.SaveChanges();
    }

    // Popula Clientes se estiver vazio
    if (!db.Clientes.Any())
    {
        var produtos = db.Produtos.ToList(); // Pega os produtos inseridos
        var vendedores = new[] { "João", "Maria", "Carlos" };
        var rnd = new Random();

        var clientes = new List<Cliente>
        {
            new Cliente { NomeCompleto = "Ana Beatriz", Telefone = "11999990001", Email = "ana@example.com", Desconto = 5, Vendedor = vendedores[0], ProdutoId = produtos[0].ProdutoId },
            new Cliente { NomeCompleto = "Bruno Lima", Telefone = "11999990002", Email = "bruno@example.com", Desconto = 0, Vendedor = vendedores[1], ProdutoId = produtos[1].ProdutoId },
            new Cliente { NomeCompleto = "Carla Mendes", Telefone = "11999990003", Email = "carla@example.com", Desconto = 10, Vendedor = vendedores[2], ProdutoId = produtos[2].ProdutoId },
            new Cliente { NomeCompleto = "Daniel Souza", Telefone = "11999990004", Email = "daniel@example.com", Desconto = 7, Vendedor = vendedores[0], ProdutoId = produtos[3].ProdutoId },
            new Cliente { NomeCompleto = "Eduarda Martins", Telefone = "11999990005", Email = "eduarda@example.com", Desconto = 3, Vendedor = vendedores[1], ProdutoId = produtos[5].ProdutoId },
            new Cliente { NomeCompleto = "Felipe Rocha", Telefone = "11999990006", Email = "felipe@example.com", Desconto = 2, Vendedor = vendedores[2], ProdutoId = produtos[6].ProdutoId },
            new Cliente { NomeCompleto = "Gabriela Dias", Telefone = "11999990007", Email = "gabriela@example.com", Desconto = 8, Vendedor = vendedores[0], ProdutoId = produtos[7].ProdutoId },
            new Cliente { NomeCompleto = "Hugo Almeida", Telefone = "11999990008", Email = "hugo@example.com", Desconto = 4, Vendedor = vendedores[1], ProdutoId = produtos[0].ProdutoId },
            new Cliente { NomeCompleto = "Isabela Ferreira", Telefone = "11999990009", Email = "isabela@example.com", Desconto = 6, Vendedor = vendedores[2], ProdutoId = produtos[1].ProdutoId },
            new Cliente { NomeCompleto = "João Victor", Telefone = "11999990010", Email = "joao@example.com", Desconto = 0, Vendedor = vendedores[0], ProdutoId = produtos[2].ProdutoId },
            new Cliente { NomeCompleto = "Karina Lopes", Telefone = "11999990011", Email = "karina@example.com", Desconto = 12, Vendedor = vendedores[1], ProdutoId = produtos[3].ProdutoId },
            new Cliente { NomeCompleto = "Lucas Silva", Telefone = "11999990012", Email = "lucas@example.com", Desconto = 5, Vendedor = vendedores[2], ProdutoId = produtos[5].ProdutoId },
            new Cliente { NomeCompleto = "Mariana Costa", Telefone = "11999990013", Email = "mariana@example.com", Desconto = 1, Vendedor = vendedores[0], ProdutoId = produtos[6].ProdutoId }
        };

        db.Clientes.AddRange(clientes);
        db.SaveChanges();
    }
}



app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
