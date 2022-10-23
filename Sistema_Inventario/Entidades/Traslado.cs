using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Traslado
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int SucursalId { get; set; }
        [ForeignKey("SucursalId")]

        [Required]
        public int BodegaId { get; set; }
        [ForeignKey("BodegaId")]
        

        [Required]
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        
        public int? SucursalEntradaId { get; set; }
        public int? BodegaEntradaId { get; set; }

        public Sucursal? Sucursal { get; set; }
        public Bodega? Bodega { get; set; }
    }
}
