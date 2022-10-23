using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

namespace Sistema_Inventario.Services
{
    public class EmpresaService : IEmpresa 
    {
        InventarioDbContext db;  
        public EmpresaService(InventarioDbContext inventarioDb)
        {
            db = inventarioDb;
        }

        //Metodo para agregar empresas
        public bool AddEmpresa(Empresa empresa)
        {
            empresa.Estado = 1;
            db.Empresa.Add(empresa);
            return db.SaveChanges() > 0;
        }

        public bool DeleteEmpresa(Empresa empresa)
        {
            empresa.Estado = 0;
            db.Empresa.Update(empresa);
            return db.SaveChanges() > 0;
        }

        public Empresa GetEmpresa(int id)
        {
            return db.Empresa.First(e=>e.Id == id);
        }

        //Metodo para obtener las empresas activas
        public ICollection<Empresa> GetEmpresas()
        {
            return (from e in db.Empresa where e.Estado == 1 select e).ToList(); 
        }

        public bool UpdtaeEmpresa(Empresa empresa)
        {
            empresa.Estado = 1;
            db.Empresa.Update(empresa);
            return db.SaveChanges() > 0;
        }
    }
}
