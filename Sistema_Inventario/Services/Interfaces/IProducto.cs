using Sistema_Inventario.Entidades;
using System.Collections;

namespace Sistema_Inventario.Services.Interfaces
{
    public interface IProducto
    {
        ICollection GetProductos(); //Metodo para obtener productos
        Producto GetProducto(int id);   //Metodo para obtener un producto filtrando Id
        bool AddProducto(Producto producto);    //Metodo para agregar productos
        bool EditProducto(Producto producto); //Metodo pra editar datos de productos
        bool DeleteProducto(Producto producto); //Metodo para dar de baja un producto
    }
}
