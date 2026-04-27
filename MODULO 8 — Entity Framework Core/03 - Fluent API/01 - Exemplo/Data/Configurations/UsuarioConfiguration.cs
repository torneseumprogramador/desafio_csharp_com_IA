using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Exemplo.Data.Configurations;

public class UsuarioConfiguration : IEntityTypeConfiguration<Usuario>
{
    public void Configure(EntityTypeBuilder<Usuario> entity)
    {
        entity.ToTable("usuarios");
        entity.HasKey(u => u.Id);

        entity.Property(u => u.Nome)
            .HasColumnName("nome")
            .HasMaxLength(120)
            .IsRequired();

        entity.Property(u => u.Email)
            .HasColumnName("email")
            .HasMaxLength(160)
            .IsRequired();

        entity.Property(u => u.DataCadastro)
            .HasColumnName("data_cadastro")
            .IsRequired();

        entity.HasIndex(u => u.Email)
            .IsUnique();
    }
}
