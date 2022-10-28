using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

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


            foreach (DetalleCompra item in compra.DetalleCompras)
            {

                Existencia existencia = (from e in db.Existencia where e.ProductoId == item.ProductoId && e.BodegaId == compra.BodegaId select e).First();

                existencia.Cantidad += item.Cantidad;
                db.Existencia.Update(existencia);
            }


            return db.SaveChanges() > 0;
        }
    }
}
