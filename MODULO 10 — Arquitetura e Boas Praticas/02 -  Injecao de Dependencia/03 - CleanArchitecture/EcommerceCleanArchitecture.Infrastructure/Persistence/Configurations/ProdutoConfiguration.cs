using EcommerceCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCleanArchitecture.Infrastructure.Persistence.Configurations;

public class ProdutoConfiguration : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.HasData(
            new Produto { Id = 1, Nome = "Notebook Pro 14", Descricao = "Notebook para trabalho e estudo.", Preco = 5499.90m },
            new Produto { Id = 2, Nome = "Mouse Sem Fio", Descricao = "Mouse ergonomico com conexao sem fio.", Preco = 129.90m },
            new Produto { Id = 3, Nome = "Teclado Mecanico", Descricao = "Teclado mecanico com iluminacao RGB.", Preco = 349.90m });
    }
}
