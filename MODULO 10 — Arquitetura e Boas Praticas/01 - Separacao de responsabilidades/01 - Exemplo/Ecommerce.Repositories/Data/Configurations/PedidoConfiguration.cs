using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiraApi.Models;

namespace primeiraApi.Data.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.ToTable("pedidos");

        builder.HasKey(p => p.Id);

        builder.Property(p => p.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(p => p.ClienteId)
            .HasColumnName("cliente_id")
            .IsRequired();

        builder.Property(p => p.CriadoEm)
            .HasColumnName("criado_em")
            .IsRequired();

        builder.Property(p => p.Observacao)
            .HasColumnName("observacao")
            .HasMaxLength(500);

        builder.HasOne(p => p.Cliente)
            .WithMany(c => c.Pedidos)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Pedido
            {
                Id = 1,
                ClienteId = 1,
                CriadoEm = new DateTime(2026, 5, 1, 10, 0, 0),
                Observacao = "Pedido inicial da Ana"
            },
            new Pedido
            {
                Id = 2,
                ClienteId = 2,
                CriadoEm = new DateTime(2026, 5, 2, 14, 30, 0),
                Observacao = "Pedido inicial do Bruno"
            }
        );
    }
}
