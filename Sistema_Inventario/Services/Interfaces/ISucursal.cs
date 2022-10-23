using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface ISucursal
    {
        ICollection GetSucursales(); //Metodo para obtener las sucursales
        Sucursal GetSucursal(int id); //Metodo para obtener sucursal filtrado por Id
        bool AddSucursal(Sucursal sucursal); //Metodo para agregar suscursales
        bool UpdateSucursal(Sucursal sucursal); //Metodo para editar sucursales
        bool DeleteSucursal(Sucursal sucursal); //Metodo para dar de baja una sucursal 
    }
}
