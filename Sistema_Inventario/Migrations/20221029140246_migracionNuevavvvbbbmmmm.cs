using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Inventario.Migrations
{
    public partial class migracionNuevavvvbbbmmmm : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Venta_Sucursal_SucursalId",
                table: "Venta");

            migrationBuilder.DropIndex(
                name: "IX_Venta_SucursalId",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "SucursalId",
                table: "Venta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "SucursalId",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Venta_SucursalId",
                table: "Venta",
                column: "SucursalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Venta_Sucursal_SucursalId",
                table: "Venta",
                column: "SucursalId",
                principalTable: "Sucursal",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
