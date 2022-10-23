using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Ajuste
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int TipoAjuste { get; set; }
        public int Cantidad { get; set; }
        public int Estado { get; set; }
        public int BodegaId { get; set; }
        [ForeignKey("BodegaId")]
        public Bodega? Bodega { get; set; }
        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]
        public Producto? Producto { get; set; }
    }
}
