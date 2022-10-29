using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class CompraService : ICompra
    {
        private readonly InventarioDbContext db;
        public CompraService(InventarioDbContext inventarioDbContext)
        {
            db = inventarioDbContext;
        }
        public bool AddCompra(Compra compra)
        {
            compra.Estado = 1;
            compra.Fecha = DateTime.Now;
            db.Compra.Add(compra);

            return db.SaveChanges() > 0;
        }

        public ICollection GetCompras()
        {
            var compras = (from c in db.Compra
                           join p in db.Proveedor on c.ProveedorId equals p.Id
                           join b in db.Bodega on c.BodegaId equals b.Id
                           select new
                           {
                               DescripcionCompra = c.Descripcion,
                               FechaCompra = c.Fecha,
                               proveedor = p.Nombre,
                               bodega = b.Descripcion
                           }).ToList();

            return compras;
        }
    }
}
