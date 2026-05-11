using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace EcommerceCleanArchitecture.Infrastructure.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Cpf", "Email", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "12345678901", "ana@ecommerce.local", "Ana Souza", "11999990001" },
                    { 2, "12345678902", "bruno@ecommerce.local", "Bruno Lima", "11999990002" }
                });

            migrationBuilder.InsertData(
                table: "Produtos",
                columns: new[] { "Id", "Descricao", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1, "Notebook para trabalho e estudo.", "Notebook Pro 14", 5499.90m },
                    { 2, "Mouse ergonomico com conexao sem fio.", "Mouse Sem Fio", 129.90m },
                    { 3, "Teclado mecanico com iluminacao RGB.", "Teclado Mecanico", 349.90m }
                });

            migrationBuilder.InsertData(
                table: "Pedidos",
                columns: new[] { "Id", "ClienteId", "CriadoEm", "Observacao" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 8, 0, 0, 0, 0, DateTimeKind.Utc), "Entregar em horario comercial." },
                    { 2, 2, new DateTime(2026, 5, 8, 0, 30, 0, 0, DateTimeKind.Utc), "Cliente solicitou embalagem para presente." }
                });

            migrationBuilder.InsertData(
                table: "PedidoProdutos",
                columns: new[] { "PedidoId", "ProdutoId", "PrecoUnitario", "Quantidade" },
                values: new object[,]
                {
                    { 1, 1, 5499.90m, 1 },
                    { 1, 2, 129.90m, 2 },
                    { 2, 3, 349.90m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "PedidoProdutos",
                keyColumns: new[] { "PedidoId", "ProdutoId" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "PedidoProdutos",
                keyColumns: new[] { "PedidoId", "ProdutoId" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "PedidoProdutos",
                keyColumns: new[] { "PedidoId", "ProdutoId" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Pedidos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Produtos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);
        }
    }
}
