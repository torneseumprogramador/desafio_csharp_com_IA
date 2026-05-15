using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using primeiraApi.Enums;
using primeiraApi.Models;

namespace primeiraApi.Data.Configurations;

public class AdministradorConfiguration : IEntityTypeConfiguration<Administrador>
{
    public void Configure(EntityTypeBuilder<Administrador> builder)
    {
        builder.ToTable("administradores");

        builder.HasKey(a => a.Id);

        builder.Property(a => a.Id)
            .HasColumnName("id")
            .ValueGeneratedOnAdd();

        builder.Property(a => a.Nome)
            .HasColumnName("nome")
            .HasMaxLength(150)
            .IsRequired();

        builder.Property(a => a.Email)
            .HasColumnName("email")
            .HasMaxLength(180)
            .IsRequired();

        builder.Property(a => a.Rule)
            .HasColumnName("rule")
            .HasConversion(
                rule => rule.ToString().ToLowerInvariant(),
                value => Enum.Parse<AdministradorRule>(value, true))
            .HasMaxLength(30)
            .IsRequired();

        builder.Property(a => a.Senha)
            .HasColumnName("senha")
            .HasMaxLength(200)
            .IsRequired();

        builder.Property(a => a.Salt)
            .HasColumnName("salt")
            .HasMaxLength(500)
            .IsRequired();

        builder.HasIndex(a => a.Email)
            .IsUnique();

        builder.HasData(
            new Administrador
            {
                Id = 1,
                Nome = "Administrador",
                Email = "admin@ecommerce.com",
                Rule = AdministradorRule.Administrador,
                Senha = "arsKZFqL7zbZu5WW4HT5In6wqWh23P401ucxeFcDnPM=",
                Salt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdGa2JXbHVJUT09In0.XhTBjWjQ4a0iU_m3lTQazJCi0KSDef_kM1wFhYD28pI"
            },
            new Administrador
            {
                Id = 2,
                Nome = "Editor",
                Email = "editor@ecommerce.com",
                Rule = AdministradorRule.Editor,
                Senha = "YIqRvjW3RdX4B5emFtgvGuyJ7lRBEghAkWOYEQMWjAo=",
                Salt = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdWa2FYUnZjZz09In0.AyDxp6PGB4SQvRNCxINl9aHmDNcgVq-872nXC2e3bO4"
            });
    }
}
