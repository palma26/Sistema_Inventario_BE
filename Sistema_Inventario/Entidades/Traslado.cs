using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Traslado
    {
        [Key]
        public int Id { get; set; }

        
        [Required]
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]

        public int? BodegaEntradaId { get; set; }

        public int? BodegaSalidaId { get; set; }

        public int Cantidad { get; set; }

    }
}
