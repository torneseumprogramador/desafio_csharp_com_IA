using _01___Exemplo.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace _01___Exemplo.Data.Configurations;

public class EmprestimoConfiguration : IEntityTypeConfiguration<Emprestimo>
{
    public void Configure(EntityTypeBuilder<Emprestimo> entity)
    {
        entity.ToTable("emprestimos");
        entity.HasKey(e => e.Id);

        entity.Property(e => e.DataEmprestimo)
            .HasColumnName("data_emprestimo")
            .IsRequired();

        entity.Property(e => e.DataPrevistaDevolucao)
            .HasColumnName("data_prevista_devolucao")
            .IsRequired();

        entity.Property(e => e.DataDevolucao)
            .HasColumnName("data_devolucao");

        entity.Property(e => e.Status)
            .HasColumnName("status")
            .HasMaxLength(30)
            .IsRequired();

        entity.HasOne(e => e.Livro)
            .WithMany(l => l.Emprestimos)
            .HasForeignKey(e => e.LivroId)
            .OnDelete(DeleteBehavior.Restrict);

        entity.HasOne(e => e.Usuario)
            .WithMany(u => u.Emprestimos)
            .HasForeignKey(e => e.UsuarioId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}
