using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

namespace Sistema_Inventario.Services
{
    public class RolService : IRol
    {
        private readonly InventarioDbContext db;
        public RolService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }
        public bool AddRol(Rol rol)
        {
            rol.Estado = 1;
            db.Rol.Add(rol);
            return db.SaveChanges() > 0;
        }

        public bool DeleteRol(Rol rol)
        {
            rol.Estado = 0;
            db.Rol.Update(rol);
           return db.SaveChanges() > 0;
        }

        public Rol getRol(int id)
        {
            return db.Rol.First(r=>r.Id == id);
        }

        public ICollection<Rol> GetRols()
        {
            return (from r in db.Rol where r.Estado ==1 select r).ToList();
        }

        public bool UpdateRol(Rol rol)
        {
            rol.Estado = 1;
            db.Rol.Update(rol);
            return db.SaveChanges() > 0;
        }
    }
}
