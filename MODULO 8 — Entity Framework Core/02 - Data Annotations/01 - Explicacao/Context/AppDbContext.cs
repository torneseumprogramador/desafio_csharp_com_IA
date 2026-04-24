using _01___Explicacao.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Explicacao.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Veiculo> Veiculos => Set<Veiculo>();
    public DbSet<Vaga> Vagas => Set<Vaga>();
    public DbSet<Movimentacao> Movimentacoes => Set<Movimentacao>();
}
