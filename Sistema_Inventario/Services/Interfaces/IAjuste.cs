using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IAjuste
    {
        ICollection GetAjustes(); //Metodo para obtener ajustes 
        Ajuste GetAjuste(int IdAjuste); // Metodo para obtener ajustes filtrado por Id 
        bool AddAjuste(Ajuste Ajuste); //Metodo para agregar ajustes
        bool UpdateAjuste(Ajuste ajuste); //Metodo para editar ajuses
        bool DeleteAjuste(Ajuste ajuste);  //Metodo para eliminar ajustes
    }
}
