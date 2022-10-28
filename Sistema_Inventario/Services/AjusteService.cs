using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class AjusteService : IAjuste
    {
        private readonly InventarioDbContext db;
        public AjusteService(InventarioDbContext inventarioDbContext)
        {
            db = inventarioDbContext;
        }
        public bool AddAjuste(Ajuste Ajuste)
        {
            Ajuste.Estado = 1;
            db.Ajuste.Add(Ajuste);

            Existencia existencia = (from e in db.Existencia where e.ProductoId == Ajuste.ProductoId && e.BodegaId == Ajuste.BodegaId select e).First();

            if (Ajuste.TipoAjuste == 1)
            {
                existencia.Cantidad += Ajuste.Cantidad;
            }
            else { 
                existencia.Cantidad -= Ajuste.Cantidad;
            }

            db.Existencia.Update(existencia);
            

            return db.SaveChanges() > 0;
        }


        public bool Compra(Compra compra) {

            compra.Estado = 1;
            compra.Fecha = DateTime.Now;
            db.Compra.Add(compra);


            foreach (DetalleCompra item in compra.DetalleCompras) {

                Existencia existencia = (from e in db.Existencia where e.ProductoId == item.ProductoId && e.BodegaId == compra.BodegaId select e).First();

                existencia.Cantidad += item.Cantidad;
                db.Existencia.Update(existencia);
            }


            return db.SaveChanges() > 0;
        }

        public bool Trasladar(Traslado transaldo) {


            db.Traslado.Update(transaldo);

            Existencia salida = (from e in db.Existencia where e.BodegaId == transaldo.BodegaSalidaId && e.ProductoId == transaldo.ProductoId select e).First();

            Existencia entrada = (from e in db.Existencia where e.BodegaId == transaldo.BodegaEntradaId && e.ProductoId == transaldo.ProductoId select e).First();

            salida.Cantidad -= transaldo.Cantidad;
            entrada.Cantidad += transaldo.Cantidad;


            db.Existencia.Update(salida);

            db.Existencia.Update(entrada);


            return db.SaveChanges() > 0;
        }


        public bool Venta(Venta venta)
        {

            venta.Estado = 1;
            venta.Fecha = DateTime.Now;
            db.Venta.Add(venta);


            foreach (DetalleVenta item in venta.detalleVentas)
            {


                int idbodega = (from s in db.Sucursal
                                join b in db.Bodega on s.Id equals b.SucursalId select b.Id).First();
                Existencia existencia = (from e in db.Existencia where e.ProductoId == item.ProductoId && e.BodegaId == idbodega select e).First();

                existencia.Cantidad -= item.Cantidad;
                db.Existencia.Update(existencia);
            }


            return db.SaveChanges() > 0;
        }

        public bool DeleteAjuste(Ajuste ajuste)
        {
            ajuste.Estado = 0;
            db.Ajuste.Update(ajuste);
            return db.SaveChanges() > 0;
        }

        public Ajuste GetAjuste(int IdAjuste)
        {
            return db.Ajuste.First(a => a.Id == IdAjuste);
        }

        public ICollection GetAjustes()
        {
            var ajustes = (from a in db.Ajuste
                           join b in db.Bodega on a.BodegaId equals b.Id
                           join p in db.Producto on a.ProductoId equals p.Id
                           where a.Estado == 1
                           select new
                           {
                               Id = a.Id,
                               tipo = a.TipoAjuste,
                               cantidad = a.Cantidad,
                               IdBodega = b.Id,
                               descripcionBodega = b.Descripcion,
                               IdProducto = p.Id,
                               descripcionProducto = p.Descripcion,
                           }).ToList();

            return ajustes;
        }

        public bool UpdateAjuste(Ajuste ajuste)
        {
            ajuste.Estado = 1;
            db.Ajuste.Update(ajuste);
            return db.SaveChanges() > 0;
        }
    }
}
