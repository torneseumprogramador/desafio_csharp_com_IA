using _01___Explicacao.Models;
using Microsoft.EntityFrameworkCore;

namespace _01___Explicacao.Context;

public sealed class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<Cliente> Clientes => Set<Cliente>();
    public DbSet<Endereco> Enderecos => Set<Endereco>();

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<Cliente>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.Property(x => x.Nome).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Telefone).HasMaxLength(30).IsRequired();
            entity.HasOne(x => x.Endereco)
                .WithOne(x => x.Cliente)
                .HasForeignKey<Endereco>(x => x.ClienteId)
                .OnDelete(DeleteBehavior.Cascade);

            entity.HasData(
                new Cliente { Id = 1, Nome = "Mariana Souza", Telefone = "(11) 90000-0000" },
                new Cliente { Id = 2, Nome = "Carlos Henrique Lima", Telefone = "(21) 99876-1234" },
                new Cliente { Id = 3, Nome = "Fernanda Alves", Telefone = "(31) 99123-4567" },
                new Cliente { Id = 4, Nome = "Rafael Costa", Telefone = "(41) 98888-7777" },
                new Cliente { Id = 5, Nome = "Juliana Martins", Telefone = "(51) 99777-6666" }
            );
        });

        modelBuilder.Entity<Endereco>(entity =>
        {
            entity.HasKey(x => x.Id);
            entity.HasIndex(x => x.ClienteId).IsUnique();
            entity.Property(x => x.Logradouro).HasMaxLength(150).IsRequired();
            entity.Property(x => x.Numero).HasMaxLength(20).IsRequired();
            entity.Property(x => x.Complemento).HasMaxLength(120);
            entity.Property(x => x.Bairro).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Cidade).HasMaxLength(100).IsRequired();
            entity.Property(x => x.Estado).HasMaxLength(2).IsRequired();
            entity.Property(x => x.Cep).HasMaxLength(12).IsRequired();

            entity.HasData(
                new Endereco
                {
                    Id = 1,
                    ClienteId = 1,
                    Logradouro = "Rua das Flores",
                    Numero = "120",
                    Complemento = "Apto 12",
                    Bairro = "Centro",
                    Cidade = "Sao Paulo",
                    Estado = "SP",
                    Cep = "01000-000"
                },
                new Endereco
                {
                    Id = 2,
                    ClienteId = 2,
                    Logradouro = "Avenida Atlantica",
                    Numero = "450",
                    Complemento = null,
                    Bairro = "Copacabana",
                    Cidade = "Rio de Janeiro",
                    Estado = "RJ",
                    Cep = "22010-000"
                },
                new Endereco
                {
                    Id = 3,
                    ClienteId = 3,
                    Logradouro = "Rua da Bahia",
                    Numero = "980",
                    Complemento = "Sala 5",
                    Bairro = "Funcionarios",
                    Cidade = "Belo Horizonte",
                    Estado = "MG",
                    Cep = "30160-011"
                },
                new Endereco
                {
                    Id = 4,
                    ClienteId = 4,
                    Logradouro = "Rua XV de Novembro",
                    Numero = "300",
                    Complemento = null,
                    Bairro = "Centro",
                    Cidade = "Curitiba",
                    Estado = "PR",
                    Cep = "80020-310"
                },
                new Endereco
                {
                    Id = 5,
                    ClienteId = 5,
                    Logradouro = "Avenida Ipiranga",
                    Numero = "1500",
                    Complemento = "Bloco B",
                    Bairro = "Partenon",
                    Cidade = "Porto Alegre",
                    Estado = "RS",
                    Cep = "90610-001"
                }
            );
        });

        base.OnModelCreating(modelBuilder);
    }
}
