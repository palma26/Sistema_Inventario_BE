using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class DetalleCompra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int Cantidad { get; set; }

        public decimal PrecioTotalCompra { get; set; }

        public int CompraId { get; set; }
        [ForeignKey("CompraId")]
        public Compra? Compra { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto? Producto{ get; set; }
    }
}
