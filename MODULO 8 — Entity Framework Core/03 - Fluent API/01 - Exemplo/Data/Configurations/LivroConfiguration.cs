using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Exemplo.Data.Configurations;

public class LivroConfiguration : IEntityTypeConfiguration<Livro>
{
    public void Configure(EntityTypeBuilder<Livro> entity)
    {
        entity.ToTable("livros");
        entity.HasKey(l => l.Id);

        entity.Property(l => l.Titulo)
            .HasColumnName("titulo")
            .HasMaxLength(160)
            .IsRequired();

        entity.Property(l => l.Isbn)
            .HasColumnName("isbn")
            .HasMaxLength(20)
            .IsRequired();

        entity.Property(l => l.AnoPublicacao)
            .HasColumnName("ano_publicacao")
            .IsRequired();

        entity.Property(l => l.QuantidadeDisponivel)
            .HasColumnName("quantidade_disponivel")
            .IsRequired();

        entity.HasIndex(l => l.Isbn)
            .IsUnique();

        entity.HasOne(l => l.Autor)
            .WithMany(a => a.Livros)
            .HasForeignKey(l => l.AutorId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
