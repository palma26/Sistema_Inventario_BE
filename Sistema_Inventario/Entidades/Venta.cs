using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Venta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required, StringLength(50)]
        public string? Descripcion { get; set; }

        public decimal precio { get; set; } 
        public int cantidad { get; set; }
        public int IdProducto { get; set; }
        [ForeignKey("IdProducto")]

        public string? TipoPago { get; set; }

        public int Estado { get; set; }


        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }


        public ICollection<DetalleVenta> detalleVentas { get; set; }
    }
}
