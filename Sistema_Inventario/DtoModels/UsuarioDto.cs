using Sistema_Inventario.Entidades;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Sistema_Inventario.DtoModels
{
    public class UsuarioDto
    {
        public string? User { get; set; }
        public string? Nombre { get; set; }
        public string? Emial { get; set; }
        public string? password { get; set; }
        public int IdRol { get; set; }
        public Rol? Rol { get; set; }
    }
}
