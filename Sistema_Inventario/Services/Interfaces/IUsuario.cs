using Microsoft.AspNetCore.Identity;
using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IUsuario
    {
        ICollection GetUsuarios();
        bool AddUser(Usuario usuario);
        Usuario GetUsuario(string user);

        Usuario Login(string username);
        bool Update(Usuario usuario);
        bool Delete(Usuario usuario);
    }
}
