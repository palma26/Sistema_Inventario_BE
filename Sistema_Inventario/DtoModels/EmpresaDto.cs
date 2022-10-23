using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class EmpresaDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nit { get; set; }

        [Required]
        [StringLength(1000)]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(20)]
        public string? Telefono { get; set; }

    }
}
