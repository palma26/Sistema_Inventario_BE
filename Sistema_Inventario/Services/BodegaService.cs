using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class BodegaService : IBodega
    {
        private readonly InventarioDbContext db;

        public BodegaService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }
        public bool AddBodega(Bodega bodega)
        {
            bodega.Estado = 1;
            db.Bodega.Add(bodega);
            return db.SaveChanges() > 0;
        }

        public bool DeleteBodega(Bodega bodega)
        {
            bodega.Estado = 0;
            db.Bodega.Update(bodega);
            return db.SaveChanges() > 0;
        }

        public Bodega GetBodega(int id)
        {
            return db.Bodega.First(b => b.Id == id);
        }

        public ICollection GetBodegas()
        {
            var bodegas = (from b in db.Bodega
                           join s in db.Sucursal on b.Id equals s.Id
                           where b.Estado == 1
                           select new
                           {
                               Id = b.Id,
                               Descripcion = b.Descripcion,
                               sucursalId = s.Id,
                               nombreSucursal = s.Nombre
                           }).ToList();

            return bodegas;
        }

        public bool UpdateBodega(Bodega bodega)
        {
            bodega.Estado = 1;
            db.Bodega.Update(bodega);
            return db.SaveChanges() > 0;
        }
    }
}
