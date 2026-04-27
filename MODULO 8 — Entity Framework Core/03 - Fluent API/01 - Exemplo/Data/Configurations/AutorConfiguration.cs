using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Exemplo.Data.Configurations;

public class AutorConfiguration : IEntityTypeConfiguration<Autor>
{
    public void Configure(EntityTypeBuilder<Autor> entity)
    {
        entity.ToTable("autores");
        entity.HasKey(a => a.Id);

        entity.Property(a => a.Nome)
            .HasColumnName("nome")
            .HasMaxLength(120)
            .IsRequired();

        entity.Property(a => a.Nacionalidade)
            .HasColumnName("nacionalidade")
            .HasMaxLength(80);
    }
}
