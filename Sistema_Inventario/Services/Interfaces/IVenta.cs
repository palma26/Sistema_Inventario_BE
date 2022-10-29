using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IVenta
    {
        bool AddVenta(Venta venta);

        ICollection  GetNotasDebitos();
        ICollection GetNotasCreditos();
    }
}
