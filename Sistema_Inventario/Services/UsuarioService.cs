using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class UsuarioService : IUsuario
    {
        private readonly InventarioDbContext db;

        public UsuarioService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }
        public bool AddUser(Usuario usuario)
        {
            usuario.Estado = 1;
            db.Usuario.Add(usuario);
            return db.SaveChanges() > 0;
        }

        public bool Delete(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public Usuario GetUsuario(string user)
        {
            throw new NotImplementedException();
        }

        public ICollection GetUsuarios()
        {
            throw new NotImplementedException();
        }

        public Usuario Login(string username)
        {
            return db.Usuario.First(u => u.User == username);
        }

        public bool Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
