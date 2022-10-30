using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Inventario.Migrations
{
    public partial class migracionusuarios : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PasswordHash",
                table: "Usuario");

            migrationBuilder.DropColumn(
                name: "PasswordSalt",
                table: "Usuario");

            migrationBuilder.AddColumn<string>(
                name: "password",
                table: "Usuario",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "password",
                table: "Usuario");

            migrationBuilder.AddColumn<byte>(
                name: "PasswordHash",
                table: "Usuario",
                type: "tinyint",
                nullable: true);

            migrationBuilder.AddColumn<byte>(
                name: "PasswordSalt",
                table: "Usuario",
                type: "tinyint",
                nullable: true);
        }
    }
}
