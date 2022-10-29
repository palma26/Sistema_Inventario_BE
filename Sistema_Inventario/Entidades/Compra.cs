using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Compra
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Descripcion { get; set; }

        [Required]
        public DateTime Fecha { get; set; }

        [Required]
        public int ProveedorId { get; set; }

        [Required]
        public int BodegaId { get; set; }


        public int Estado {get; set;}

        public virtual ICollection<DetalleCompra> DetalleCompras { get; set; }      

        
    }
}
