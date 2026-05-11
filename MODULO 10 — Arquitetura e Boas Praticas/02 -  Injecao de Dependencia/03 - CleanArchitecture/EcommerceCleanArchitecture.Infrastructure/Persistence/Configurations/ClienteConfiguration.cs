using EcommerceCleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace EcommerceCleanArchitecture.Infrastructure.Persistence.Configurations;

public class ClienteConfiguration : IEntityTypeConfiguration<Cliente>
{
    public void Configure(EntityTypeBuilder<Cliente> builder)
    {
        builder.HasMany(c => c.Pedidos)
            .WithOne(p => p.Cliente)
            .HasForeignKey(p => p.ClienteId)
            .OnDelete(DeleteBehavior.Restrict);

        builder.HasData(
            new Cliente { Id = 1, Nome = "Ana Souza", Email = "ana@ecommerce.local", Telefone = "11999990001", Cpf = "12345678901" },
            new Cliente { Id = 2, Nome = "Bruno Lima", Email = "bruno@ecommerce.local", Telefone = "11999990002", Cpf = "12345678902" });
    }
}
