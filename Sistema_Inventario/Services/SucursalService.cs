using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;
using System.Reflection.Metadata.Ecma335;

namespace Sistema_Inventario.Services
{
    public class SucursalService : ISucursal
    {
        private readonly InventarioDbContext db;
        public SucursalService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }
        public bool AddSucursal(Sucursal sucursal)
        {
            sucursal.Estado = 1;
            db.Sucursal.Add(sucursal);
            return db.SaveChanges() > 0;
        }

        public bool DeleteSucursal(Sucursal sucursal)
        {
            sucursal.Estado = 0;
            db.Sucursal.Update(sucursal);
            return db.SaveChanges() > 0;
        }

        public Sucursal GetSucursal(int id)
        {
            return db.Sucursal.First(s => s.Id == id);
        }

        public ICollection GetSucursales()
        {
            var sucursales = (from s in db.Sucursal
                              join e in db.Empresa on s.Id equals e.Id
                              where s.Estado == 1
                              select new
                              {
                                  Id = s.Id,
                                  nombre = s.Nombre,
                                  direccion = s.Direccion,
                                  telefono = s.Telefono,
                                  empresaId = e.Id,
                                  nombreEmpresa = e.Nombre
                              }).ToList();

            return sucursales;
        }

        public bool UpdateSucursal(Sucursal sucursal)
        {
            sucursal.Estado = 1;
            db.Sucursal.Update(sucursal);
            return db.SaveChanges() > 0;
        }
    }
}
