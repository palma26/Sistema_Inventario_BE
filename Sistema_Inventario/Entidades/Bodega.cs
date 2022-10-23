using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Bodega
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string? Descripcion { get; set; }

        public int? Estado { get; set; }

        public int SucursalId { get; set; }
        [ForeignKey("SucursalId")]

        public Sucursal? Sucursal { get; set; }
    }
}
