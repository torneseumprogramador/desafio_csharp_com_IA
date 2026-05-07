using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeiraApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class AddCpfToCliente : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "cpf",
                table: "clientes",
                type: "varchar(11)",
                maxLength: 11,
                nullable: false,
                defaultValue: "")
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 1,
                column: "cpf",
                value: "12345678909");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 2,
                column: "cpf",
                value: "11144477735");

            migrationBuilder.UpdateData(
                table: "clientes",
                keyColumn: "id",
                keyValue: 3,
                column: "cpf",
                value: "52998224725");

            migrationBuilder.CreateIndex(
                name: "IX_clientes_cpf",
                table: "clientes",
                column: "cpf",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_clientes_cpf",
                table: "clientes");

            migrationBuilder.DropColumn(
                name: "cpf",
                table: "clientes");
        }
    }
}
