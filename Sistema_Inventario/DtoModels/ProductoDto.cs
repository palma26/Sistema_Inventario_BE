using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class ProductoDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Codigo { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        public int? Cantidad { get; set; }

        [Required]
        public decimal? Costo { get; set; }

        [Required]
        public decimal? Precio { get; set; }

        public int CategoriaId { get; set; }
    }
}
