using _01___Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Relacionamentos.Data.Configurations;

public class CursoConfiguration : IEntityTypeConfiguration<Curso>
{
    public void Configure(EntityTypeBuilder<Curso> builder)
    {
        builder.ToTable("Cursos");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Titulo)
            .HasMaxLength(120)
            .IsRequired();

        builder.HasOne(x => x.Departamento)
            .WithMany(x => x.Cursos)
            .HasForeignKey(x => x.DepartamentoId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
