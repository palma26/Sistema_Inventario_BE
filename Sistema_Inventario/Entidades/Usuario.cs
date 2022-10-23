using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Sistema_Inventario.Entidades
{
    public class Usuario
    {
        [Key]
        public string? User { get; set; }
        [Required]
        public string? Nombre { get; set; }
        public string? Emial { get; set; }
        public byte? PasswordHash { get; set; }
        public byte? PasswordSalt { get; set; } 
        public int IdRol { get; set; }
        [ForeignKey("IdRol")]
        public Rol? Rol { get; set; }
        public int Estado { get; set; }
    }
}
