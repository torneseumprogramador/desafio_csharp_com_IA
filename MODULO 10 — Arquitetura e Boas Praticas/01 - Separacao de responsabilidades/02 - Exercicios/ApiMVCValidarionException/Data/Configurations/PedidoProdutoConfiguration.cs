using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiraApi.Models;

namespace primeiraApi.Data.Configurations;

public class PedidoProdutoConfiguration : IEntityTypeConfiguration<PedidoProduto>
{
    public void Configure(EntityTypeBuilder<PedidoProduto> builder)
    {
        builder.ToTable("pedido_produto");

        builder.HasKey(pp => new { pp.PedidoId, pp.ProdutoId });

        builder.Property(pp => pp.PedidoId)
            .HasColumnName("pedido_id");

        builder.Property(pp => pp.ProdutoId)
            .HasColumnName("produto_id");

        builder.Property(pp => pp.Quantidade)
            .HasColumnName("quantidade")
            .IsRequired();

        builder.Property(pp => pp.PrecoUnitario)
            .HasColumnName("preco_unitario")
            .HasPrecision(10, 2)
            .IsRequired();

        builder.HasOne(pp => pp.Pedido)
            .WithMany(p => p.Itens)
            .HasForeignKey(pp => pp.PedidoId)
            .OnDelete(DeleteBehavior.Cascade);

        builder.HasOne(pp => pp.Produto)
            .WithMany(p => p.PedidoProdutos)
            .HasForeignKey(pp => pp.ProdutoId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new PedidoProduto
            {
                PedidoId = 1,
                ProdutoId = 1,
                Quantidade = 1,
                PrecoUnitario = 199.90m
            },
            new PedidoProduto
            {
                PedidoId = 1,
                ProdutoId = 2,
                Quantidade = 2,
                PrecoUnitario = 99.90m
            },
            new PedidoProduto
            {
                PedidoId = 2,
                ProdutoId = 3,
                Quantidade = 1,
                PrecoUnitario = 899.90m
            }
        );
    }
}
