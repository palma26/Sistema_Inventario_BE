using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface ICompra
    {
        bool AddCompra(Compra compra);
        ICollection GetCompras();
    }
}
