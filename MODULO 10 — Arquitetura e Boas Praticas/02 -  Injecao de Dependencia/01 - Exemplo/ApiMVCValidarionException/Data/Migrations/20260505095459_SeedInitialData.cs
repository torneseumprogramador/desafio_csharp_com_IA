using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace primeiraApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedInitialData : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "clientes",
                columns: new[] { "id", "email", "nome", "telefone" },
                values: new object[,]
                {
                    { 1, "ana@email.com", "Ana Souza", "11999990001" },
                    { 2, "bruno@email.com", "Bruno Lima", "11999990002" },
                    { 3, "carla@email.com", "Carla Mendes", "11999990003" }
                });

            migrationBuilder.InsertData(
                table: "produtos",
                columns: new[] { "id", "estoque", "nome", "preco" },
                values: new object[,]
                {
                    { 1, 20, "Teclado", 199.90m },
                    { 2, 50, "Mouse", 99.90m },
                    { 3, 10, "Monitor", 899.90m },
                    { 4, 15, "Headset", 249.90m }
                });

            migrationBuilder.InsertData(
                table: "pedidos",
                columns: new[] { "id", "cliente_id", "criado_em", "observacao" },
                values: new object[,]
                {
                    { 1, 1, new DateTime(2026, 5, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Pedido inicial da Ana" },
                    { 2, 2, new DateTime(2026, 5, 2, 14, 30, 0, 0, DateTimeKind.Unspecified), "Pedido inicial do Bruno" }
                });

            migrationBuilder.InsertData(
                table: "pedido_produto",
                columns: new[] { "pedido_id", "produto_id", "preco_unitario", "quantidade" },
                values: new object[,]
                {
                    { 1, 1, 199.90m, 1 },
                    { 1, 2, 99.90m, 2 },
                    { 2, 3, 899.90m, 1 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "pedido_produto",
                keyColumns: new[] { "pedido_id", "produto_id" },
                keyValues: new object[] { 1, 1 });

            migrationBuilder.DeleteData(
                table: "pedido_produto",
                keyColumns: new[] { "pedido_id", "produto_id" },
                keyValues: new object[] { 1, 2 });

            migrationBuilder.DeleteData(
                table: "pedido_produto",
                keyColumns: new[] { "pedido_id", "produto_id" },
                keyValues: new object[] { 2, 3 });

            migrationBuilder.DeleteData(
                table: "produtos",
                keyColumn: "id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "pedidos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "pedidos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "produtos",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "produtos",
                keyColumn: "id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "produtos",
                keyColumn: "id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
