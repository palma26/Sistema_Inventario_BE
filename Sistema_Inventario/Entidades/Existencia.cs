using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Existencia
    {
        [Key]
        public int Id { get; set; }

        public int Cantidad { get; set; }

        public int ProductoId { get; set; }
        [ForeignKey("ProductoId")]

        public Producto? producto { get; set; }

        public int BodegaId { get; set; }
        [ForeignKey("BodegaId")]

        public Bodega? bodega { get; set; }
    }
}
