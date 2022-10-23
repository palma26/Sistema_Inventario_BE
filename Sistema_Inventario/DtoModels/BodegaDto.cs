using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class BodegaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        [Required]
        public int SucursalId { get; set; }
    }
}
