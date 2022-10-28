using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Inventario.Migrations
{
    public partial class agrandoajustes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descripcion",
                table: "Ajuste",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descripcion",
                table: "Ajuste");
        }
    }
}
