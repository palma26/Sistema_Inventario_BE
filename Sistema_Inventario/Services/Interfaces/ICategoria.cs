using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface ICategoria
    {
        ICollection<Categoria> GetCategorias(); //Metodo para obtener las categorias
        Categoria GetCategoria(int IdCategoria); //Metodo para obtener una categoria filtrada por Id 
        bool AddCategoria(Categoria categoria); //Metodo para agregar categorias
        bool UpdateCategoria(Categoria categoria); //Metodo para editar categorias
        bool DeleteCategoria(Categoria categoria); //Metodo para dar de baja una categoria

    }
}
