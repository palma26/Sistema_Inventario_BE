using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class VentaService : IVenta
    {
        private readonly InventarioDbContext db;

        public VentaService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }
        public bool AddVenta(Venta venta)
        {
            venta.Fecha = DateTime.Now;
            venta.Estado = 1;
            db.Venta.Add(venta);

            return db.SaveChanges() > 0;
        }

        public ICollection GetNotasCreditos()
        {
            var notasCredito = (from N in db.Venta
                                join p in db.Producto on N.IdProducto equals p.Id
                                join c in db.Cliente on N.ClienteId equals c.Id
                                where N.TipoPago == "credito"
                                select new
                                {
                                    descripcion = N.Descripcion,
                                    precio = N.precio,
                                    cantidad = N.cantidad,
                                    producto = p.Descripcion,
                                    cliente = c.Nombre
                                }).ToList();

            return notasCredito;
        }

        public ICollection GetNotasDebitos()
        {
            var notasDebito = (from N in db.Venta
                                join p in db.Producto on N.IdProducto equals p.Id
                                join c in db.Cliente on N.ClienteId equals c.Id
                                where N.TipoPago == "debito"
                                select new
                                {
                                    descripcion = N.Descripcion,
                                    precio = N.precio,
                                    cantidad = N.cantidad,
                                    producto = p.Descripcion,
                                    cliente = c.Nombre
                                }).ToList();

            return notasDebito;
        }
    }
}
