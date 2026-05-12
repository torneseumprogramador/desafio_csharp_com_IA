using Microsoft.EntityFrameworkCore;
using primeiraApi.Models;

namespace primeiraApi.Data;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Administrador> Administradores => Set<Administrador>();
    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Produto> Produtos => Set<Produto>();
    public DbSet<Pedido> Pedidos => Set<Pedido>();
    public DbSet<PedidoProduto> PedidoProdutos => Set<PedidoProduto>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(AppDbContext).Assembly);
        base.OnModelCreating(modelBuilder);
    }
}
