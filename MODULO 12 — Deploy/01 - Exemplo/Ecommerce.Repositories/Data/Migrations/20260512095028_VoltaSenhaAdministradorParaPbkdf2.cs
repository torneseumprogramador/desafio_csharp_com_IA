using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeiraApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class VoltaSenhaAdministradorParaPbkdf2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "salt", "senha" },
                values: new object[] { "ZWNvbW1lcmNlLWFkbWluIQ==", "arsKZFqL7zbZu5WW4HT5In6wqWh23P401ucxeFcDnPM=" });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "id",
                keyValue: 1,
                columns: new[] { "salt", "senha" },
                values: new object[] { "$2a$11$sIaHnW6hmUL037L5rBszMO", "$2a$11$sIaHnW6hmUL037L5rBszMOMjDut41nVZGY0.n/aRRGYdFNsFQCvT6" });
        }
    }
}
