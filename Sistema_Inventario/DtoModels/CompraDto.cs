using Sistema_Inventario.Entidades;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class CompraDto
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string? Usuario { get; set; }

        [Required]
        public DateTime Fecha { get; set; }
        
        [Required]
        public int ProveedorId { get; set; }

        public int BodegaId { get; set; }
        public  List<DetalleCompraDto> DetalleCompras { get; set; } 
    }
}
