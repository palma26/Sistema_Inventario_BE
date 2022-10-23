using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IBodega
    {
        ICollection GetBodegas(); //Metodo para obtener listado de bodegas
        Bodega GetBodega(int id); //Metodo para obtener bodega filtrada por Id
        bool AddBodega(Bodega bodega); //Metodo para agregar bodegas
        bool UpdateBodega(Bodega bodega); //Metodo para editar datos de bodegas
        bool DeleteBodega(Bodega bodega); //Metodo para dar de baja bodegas 
    }
}
