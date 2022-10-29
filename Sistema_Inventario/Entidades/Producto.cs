using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Producto
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        public int Cantidad { get; set; } 

        [Required]
        public decimal? Costo { get; set; }

        [Required]
        public decimal? Precio { get; set; }    

        public int? Estado { get; set; }

        public int CategoriaId { get; set; }
        [ForeignKey("CategoriaId")]

        public Categoria? Categoria { get; set; }
    }
}
