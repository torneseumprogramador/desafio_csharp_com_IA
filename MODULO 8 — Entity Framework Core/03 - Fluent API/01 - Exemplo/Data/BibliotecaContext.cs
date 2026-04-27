using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace _01___Exemplo.Data;

public class BibliotecaContext : DbContext
{
    public DbSet<Autor> Autores => Set<Autor>();
    public DbSet<Livro> Livros => Set<Livro>();
    public DbSet<Usuario> Usuarios => Set<Usuario>();
    public DbSet<Emprestimo> Emprestimos => Set<Emprestimo>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=biblioteca.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
