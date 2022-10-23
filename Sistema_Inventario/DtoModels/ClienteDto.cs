using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class ClienteDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(14)]
        public string? Nit { get; set; }

        [Required]
        [StringLength(14)]
        public string? Telefono { get; set; }
    }
}
