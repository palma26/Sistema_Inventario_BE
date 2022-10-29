using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

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
            venta.Estado = 1;
            db.Venta.Add(venta);

            if (venta.TipoPago == 1)
            {
                NotaCredito notaCredito = new NotaCredito();

                notaCredito.Observacion = venta.Descripcion;
                notaCredito.Fecha = DateTime.Now;
                notaCredito.Valor = venta.precio;
                notaCredito.cantidad = venta.cantidad;
                notaCredito.idProducto = venta.IdProducto;

                db.NotaCredito.Add(notaCredito);

                db.SaveChanges();

            }else if(venta.TipoPago == 2)
            {
                NotaDebito notaDebito = new NotaDebito();
                notaDebito.Observacion = venta.Descripcion;
                notaDebito.Fecha = DateTime.Now;
                notaDebito.Valor = venta.precio;
                notaDebito.cantidad = venta.cantidad;
                notaDebito.idProducto = venta.IdProducto;

                db.NotaDebito.Add(notaDebito);
                db.SaveChanges();
            }

            return db.SaveChanges() > 0;
        }

       
    }
}
