using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Inventario.Migrations
{
    public partial class migracionNuevavvvbbb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Compra",
                newName: "Descripcion");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Compra",
                newName: "Usuario");
        }
    }
}
