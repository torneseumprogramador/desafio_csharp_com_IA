using _01___Relacionamentos.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Relacionamentos.Data.Configurations;

public class MaterialApoioConfiguration : IEntityTypeConfiguration<MaterialApoio>
{
    public void Configure(EntityTypeBuilder<MaterialApoio> builder)
    {
        builder.ToTable("MateriaisApoio");

        builder.HasKey(x => x.AulaId);

        builder.Property(x => x.Url)
            .HasMaxLength(250)
            .IsRequired();

        builder.HasOne(x => x.Aula)
            .WithOne(x => x.MaterialApoio)
            .HasForeignKey<MaterialApoio>(x => x.AulaId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}
