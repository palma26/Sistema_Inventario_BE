using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Sucursal
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Nombre { get; set; }

        [Required]
        [StringLength(100)]
        public string? Direccion { get; set; }

        [Required]
        [StringLength(100)]
        public string? Telefono { get; set; }

        public int? Estado { get; set; }

        public int EmpresaId { get; set; }
        [ForeignKey("EmpresaId")]

        public Empresa? Empresa { get; set; }    
    }
}
