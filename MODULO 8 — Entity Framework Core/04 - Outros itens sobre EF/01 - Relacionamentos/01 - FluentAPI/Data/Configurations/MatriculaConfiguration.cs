using _01___Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Relacionamentos.Data.Configurations;

public class MatriculaConfiguration : IEntityTypeConfiguration<Matricula>
{
    public void Configure(EntityTypeBuilder<Matricula> builder)
    {
        builder.ToTable("Matriculas");

        builder.HasKey(x => new { x.AlunoId, x.CursoId });

        builder.Property(x => x.NotaFinal)
            .HasPrecision(5, 2);

        builder.HasOne(x => x.Aluno)
            .WithMany(x => x.Matriculas)
            .HasForeignKey(x => x.AlunoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Matriculas)
            .HasForeignKey(x => x.CursoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
