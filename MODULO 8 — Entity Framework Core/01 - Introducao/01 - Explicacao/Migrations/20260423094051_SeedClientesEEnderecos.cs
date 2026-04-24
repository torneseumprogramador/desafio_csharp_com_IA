using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace _01___Explicacao.Migrations
{
    /// <inheritdoc />
    public partial class SeedClientesEEnderecos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Clientes",
                columns: new[] { "Id", "Nome", "Telefone" },
                values: new object[,]
                {
                    { 1, "Mariana Souza", "(11) 90000-0000" },
                    { 2, "Carlos Henrique Lima", "(21) 99876-1234" },
                    { 3, "Fernanda Alves", "(31) 99123-4567" },
                    { 4, "Rafael Costa", "(41) 98888-7777" },
                    { 5, "Juliana Martins", "(51) 99777-6666" }
                });

            migrationBuilder.InsertData(
                table: "Enderecos",
                columns: new[] { "Id", "Bairro", "Cep", "Cidade", "ClienteId", "Complemento", "Estado", "Logradouro", "Numero" },
                values: new object[,]
                {
                    { 1, "Centro", "01000-000", "Sao Paulo", 1, "Apto 12", "SP", "Rua das Flores", "120" },
                    { 2, "Copacabana", "22010-000", "Rio de Janeiro", 2, null, "RJ", "Avenida Atlantica", "450" },
                    { 3, "Funcionarios", "30160-011", "Belo Horizonte", 3, "Sala 5", "MG", "Rua da Bahia", "980" },
                    { 4, "Centro", "80020-310", "Curitiba", 4, null, "PR", "Rua XV de Novembro", "300" },
                    { 5, "Partenon", "90610-001", "Porto Alegre", 5, "Bloco B", "RS", "Avenida Ipiranga", "1500" }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Enderecos",
                keyColumn: "Id",
                keyValue: 5);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 1);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 2);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 3);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 4);

            migrationBuilder.DeleteData(
                table: "Clientes",
                keyColumn: "Id",
                keyValue: 5);
        }
    }
}
