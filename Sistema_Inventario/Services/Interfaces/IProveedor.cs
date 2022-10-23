using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IProveedor
    {
        ICollection<Proveedor> GetProveedores(); //Metodo para obtener provedores
        Proveedor GetProveedor(int id); //Metodo para obtener proveedor filtrado por Id
        bool AddProveedor(Proveedor proveedor); //Metodo para agregar proveedores
        bool UpdateProveedor(Proveedor proveedor); //Metodo para editar datos de proveedores
        bool DeleteProveedor(Proveedor proveedor); //Metodo para dar de baja a los proveedores
    }
}
