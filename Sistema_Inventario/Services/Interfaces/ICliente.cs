using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface ICliente
    {
        ICollection<Cliente> GetClientes(); //Metodo para obtener clientes
        Cliente GetCliente(int IdCliente); //Metodo para obtener cliente filtrado por Id
        bool AddCliente(Cliente cliente);   //Metodo para agregar clientes
        bool UpdateCliente(Cliente cliente); //Metodo para editar datos de clientes
        bool DeleteCliente(Cliente cliente); //Metodo para dar de baja a clientes 
    }
}
