using _02___Data_Annotations.Models;
using Microsoft.EntityFrameworkCore;

namespace _02___Data_Annotations.Data;

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
            optionsBuilder.UseSqlite("Data Source=relacionamentos.annotations.db");
        }
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // A maior parte do mapeamento está via Data Annotations.
        // Aqui ficam apenas comportamentos que não têm equivalente direto e claro em annotations.
        modelBuilder.Entity<Curso>()
            .HasOne(x => x.Departamento)
            .WithMany(x => x.Cursos)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Aluno>()
            .HasOne(x => x.Mentor)
            .WithMany(x => x.Mentorados)
            .OnDelete(DeleteBehavior.NoAction);
    }
}
