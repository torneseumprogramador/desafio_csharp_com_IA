using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiraApi.Models;

namespace primeiraApi.Data.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("produtos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Nome)
            .HasColumnName("nome")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(p => p.Preco)
            .HasColumnName("preco")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.Property(p => p.Estoque)
            .HasColumnName("estoque")
            .IsRequired();

        builder.HasData(
            new Produto { Id = 1, Nome = "Teclado", Preco = 199.90m, Estoque = 20 },
            new Produto { Id = 2, Nome = "Mouse", Preco = 99.90m, Estoque = 50 },
            new Produto { Id = 3, Nome = "Monitor", Preco = 899.90m, Estoque = 10 },
            new Produto { Id = 4, Nome = "Headset", Preco = 249.90m, Estoque = 15 }
        );
    }
}
