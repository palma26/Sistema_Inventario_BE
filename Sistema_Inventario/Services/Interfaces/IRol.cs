using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IRol
    {
        ICollection<Rol> GetRols();
         Rol getRol(int id);
        bool AddRol(Rol rol);   
        bool UpdateRol(Rol rol);
        bool DeleteRol(Rol rol);
    }
}
