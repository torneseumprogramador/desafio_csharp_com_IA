using _01___Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Relacionamentos.Data.Configurations;

public class AulaConfiguration : IEntityTypeConfiguration<Aula>
{
    public void Configure(EntityTypeBuilder<Aula> builder)
    {
        builder.ToTable("Aulas");

        builder.HasKey(x => x.Id);

        builder.Property(x => x.Tema)
            .HasMaxLength(120)
            .IsRequired();

        builder.HasOne(x => x.Curso)
            .WithMany(x => x.Aulas)
            .HasForeignKey(x => x.CursoId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
