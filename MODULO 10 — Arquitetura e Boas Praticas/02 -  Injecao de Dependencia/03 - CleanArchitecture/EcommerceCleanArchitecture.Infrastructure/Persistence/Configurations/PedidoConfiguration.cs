using EcommerceCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCleanArchitecture.Infrastructure.Persistence.Configurations;

public class PedidoConfiguration : IEntityTypeConfiguration<Pedido>
{
    public void Configure(EntityTypeBuilder<Pedido> builder)
    {
        builder.HasData(
            new Pedido { Id = 1, ClienteId = 1, CriadoEm = new DateTime(2026, 5, 8, 0, 0, 0, DateTimeKind.Utc), Observacao = "Entregar em horario comercial." },
            new Pedido { Id = 2, ClienteId = 2, CriadoEm = new DateTime(2026, 5, 8, 0, 30, 0, DateTimeKind.Utc), Observacao = "Cliente solicitou embalagem para presente." });
    }
}
