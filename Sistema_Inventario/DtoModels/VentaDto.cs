using Sistema_Inventario.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class VentaDto
    {
        public int Id { get; set; }
        public DateTime Fecha { get; set; }

        public string? Descripcion { get; set; }

        public decimal precio { get; set; }
        public int cantidad { get; set; }
        public int IdProducto { get; set; }

        public int TipoPago { get; set; }

        public int SucursalId { get; set; }

    }
}
