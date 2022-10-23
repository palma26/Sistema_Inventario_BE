using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IEmpresa
    {
        ICollection<Empresa> GetEmpresas(); //Metodo para obtener empresas activas
        Empresa GetEmpresa(int id); //Metodo para obtener empresa filtrado por Id
        bool AddEmpresa(Empresa empresa); //Metodo para agregar empresas
        bool UpdtaeEmpresa(Empresa empresa); //Metodo para editar una empresa
        bool DeleteEmpresa(Empresa empresa); //Metodo para dar de baja una empresa
    }
}
