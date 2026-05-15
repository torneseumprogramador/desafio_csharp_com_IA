using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace primeiraApi.Data.Migrations
{
    /// <inheritdoc />
    public partial class ProtegeSaltAdministradorComJwt : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "salt",
                table: "administradores",
                type: "varchar(500)",
                maxLength: 500,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "id",
                keyValue: 1,
                column: "salt",
                value: "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJpc3MiOiJFY29tbWVyY2UuQVBJIiwiYXVkIjoiRWNvbW1lcmNlLlNhbHQiLCJzYWx0IjoiWldOdmJXMWxjbU5sTFdGa2JXbHVJUT09In0.XhTBjWjQ4a0iU_m3lTQazJCi0KSDef_kM1wFhYD28pI");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "salt",
                table: "administradores",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(500)",
                oldMaxLength: 500)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "administradores",
                keyColumn: "id",
                keyValue: 1,
                column: "salt",
                value: "ZWNvbW1lcmNlLWFkbWluIQ==");
        }
    }
}
