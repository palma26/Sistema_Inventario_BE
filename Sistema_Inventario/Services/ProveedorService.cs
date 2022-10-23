using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

namespace Sistema_Inventario.Services
{
    public class ProveedorService : IProveedor
    {
        private readonly InventarioDbContext db;
        public ProveedorService(InventarioDbContext inventarioDbContext)
        {
            db = inventarioDbContext;
        }
        public bool AddProveedor(Proveedor proveedor)
        {
            proveedor.Estado = 1;
            db.Proveedor.Add(proveedor);
            return db.SaveChanges() > 0;
        }

        public bool DeleteProveedor(Proveedor proveedor)
        {
            proveedor.Estado = 0;
            db.Proveedor.Update(proveedor);
            return db.SaveChanges() > 0;
        }

        public Proveedor GetProveedor(int id)
        {
            return db.Proveedor.First(p => p.Id == id);
        }

        public ICollection<Proveedor> GetProveedores()
        {
            return (from p in db.Proveedor where p.Estado ==1 select p).ToList();   
        }

        public bool UpdateProveedor(Proveedor proveedor)
        {
            proveedor.Estado = 1;
            db.Proveedor.Update(proveedor);
            return db.SaveChanges() > 0;
        }
    }
}
