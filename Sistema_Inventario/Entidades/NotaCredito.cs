using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class NotaCredito
    {
        [Key]
        public int Id { get; set; }

        [Required, StringLength(50)]
        public string? Observacion { get; set; }
        public int idProducto { get; set; }
        public DateTime Fecha { get; set; }
        public decimal Valor { get; set; }
        public int cantidad { get; set; }
        public int Estado { get; set; }

    }
}
