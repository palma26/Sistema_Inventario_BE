using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Sistema_Inventario.Migrations
{
    public partial class migracionNuevavvv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Usuario",
                table: "Venta",
                newName: "Descripcion");

            migrationBuilder.AlterColumn<int>(
                name: "TipoPago",
                table: "Venta",
                type: "int",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(50)",
                oldMaxLength: 50);

            migrationBuilder.AddColumn<int>(
                name: "IdProducto",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "cantidad",
                table: "Venta",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<decimal>(
                name: "precio",
                table: "Venta",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "idProducto",
                table: "NotaDebito",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "idProducto",
                table: "NotaCredito",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IdProducto",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "cantidad",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "precio",
                table: "Venta");

            migrationBuilder.DropColumn(
                name: "idProducto",
                table: "NotaDebito");

            migrationBuilder.DropColumn(
                name: "idProducto",
                table: "NotaCredito");

            migrationBuilder.RenameColumn(
                name: "Descripcion",
                table: "Venta",
                newName: "Usuario");

            migrationBuilder.AlterColumn<string>(
                name: "TipoPago",
                table: "Venta",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldMaxLength: 50);
        }
    }
}
