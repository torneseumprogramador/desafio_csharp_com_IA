using _01___Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Relacionamentos.Data;

public class EscolaContext : DbContext
{
    public DbSet<Departamento> Departamentos => Set<Departamento>();
    public DbSet<Curso> Cursos => Set<Curso>();
    public DbSet<Aluno> Alunos => Set<Aluno>();
    public DbSet<Matricula> Matriculas => Set<Matricula>();
    public DbSet<Aula> Aulas => Set<Aula>();
    public DbSet<MaterialApoio> MateriaisApoio => Set<MaterialApoio>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlite("Data Source=relacionamentos.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(typeof(EscolaContext).Assembly);
    }
}
