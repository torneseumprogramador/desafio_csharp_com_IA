using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiraApi.Models;

namespace primeiraApi.Data.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.ToTable("clientes");

        builder.HasKey(c => c.Id);

        builder.Property(c => c.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(c => c.Nome)
            .HasColumnName("nome")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(c => c.Email)
            .HasColumnName("email")
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(c => c.Telefone)
            .HasColumnName("telefone")
            .HasMaxLength(30)
            .IsRequired();

        builder.HasIndex(c => c.Email)
            .IsUnique();

        builder.HasData(
            new Cliente
            {
                Id = 1,
                Nome = "Ana Souza",
                Email = "ana@email.com",
                Telefone = "11999990001"
            },
            new Cliente
            {
                Id = 2,
                Nome = "Bruno Lima",
                Email = "bruno@email.com",
                Telefone = "11999990002"
            },
            new Cliente
            {
                Id = 3,
                Nome = "Carla Mendes",
                Email = "carla@email.com",
                Telefone = "11999990003"
            }
        );
    }
}
