using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeiraApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class SeedAdministradorEditor : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "administradores",
                columns: new[] { "id", "email", "nome", "rule", "salt", "senha" },
                values: new object[] { 2, "editor@ecommerce.com", "Editor", "editor", "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdWa2FYUnZjZz09In0.AyDxp6PGB4SQvRNCxINl9aHmDNcgVq-872nXC2e3bO4", "YIqRvjW3RdX4B5emFtgvGuyJ7lRBEghAkWOYEQMWjAo=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "administradores",
                keyColumn: "id",
                keyValue: 2);
        }
    }
}
