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
            throw new NotImplementedException();
        }

        public bool UpdateAjuste(Ajuste ajuste)
        {
            throw new NotImplementedException();
        }
    }
}
