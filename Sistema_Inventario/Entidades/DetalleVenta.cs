using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class DetalleVenta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public decimal Precio { get; set; }

        public int VentaId { get; set; }
        [ForeignKey("VentaId")]

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]

        public Venta? Venta { get; set; }
        public Producto? Producto { get; set; }
    }
}
