using Sistema_Inventario.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class AjusteDto
    {
        public int Id { get; set; }
        [Required]
        public int TipoAjuste { get; set; }
        public int Cantidad { get; set; }
        public string? Descripcion { get; set; }
        public int BodegaId { get; set; }
        public int ProductoId { get; set; }
    }
}
