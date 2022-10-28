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
        public string? Usuario { get; set; }

        [Required, StringLength(50)]
        public string? TipoPago { get; set; }

        public int Estado { get; set; }

        public int SucursalId { get; set; }

        [ForeignKey("SucursalId")]
        public Sucursal? Sucursal { get; set; }

        public int ClienteId { get; set; }
        [ForeignKey("ClienteId")]
        public Cliente? Cliente { get; set; }


        public ICollection<DetalleVenta> detalleVentas { get; set; }
    }
}
