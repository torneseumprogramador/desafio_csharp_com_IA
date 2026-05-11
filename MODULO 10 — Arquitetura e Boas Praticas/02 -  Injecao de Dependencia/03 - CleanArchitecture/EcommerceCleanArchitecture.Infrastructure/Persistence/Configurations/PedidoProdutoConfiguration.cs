using EcommerceCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCleanArchitecture.Infrastructure.Persistence.Configurations;

public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
{
    public void Configure(EntityTypeBuilder<PedidoProduto> builder)
    {
        builder.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        builder.HasOne(pp => pp.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(pp => pp.PedidoId);

        builder.HasOne(pp => pp.Produto)
            .WithMany(p => p.Pedidos)
            .HasForeignKey(pp => pp.ProdutoId);

        builder.HasData(
            new PedidoProduto { PedidoId = 1, ProdutoId = 1, Quantidade = 1, PrecoUnitario = 5499.90m },
            new PedidoProduto { PedidoId = 1, ProdutoId = 2, Quantidade = 2, PrecoUnitario = 129.90m },
            new PedidoProduto { PedidoId = 2, ProdutoId = 3, Quantidade = 1, PrecoUnitario = 349.90m });
    }
}
