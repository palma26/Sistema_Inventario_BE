using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Usuario
    {
        [Key]
       public int id { get; set; }
        public string? User { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string? Emial { get; set; }
        public string? password { get; set; }
        public int Estado { get; set; }
    }
}
