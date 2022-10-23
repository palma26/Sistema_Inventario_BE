using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;
using System.Collections;

namespace Sistema_Inventario.Services
{
    public class ProductoService : IProducto
    {
        private readonly InventarioDbContext db;
        public ProductoService(InventarioDbContext inventarioDbContext)
        {
            this.db = inventarioDbContext;  
        }
        public bool AddProducto(Producto producto)
        {
            producto.Estado = 1;
            db.Producto.Add(producto);
            return db.SaveChanges() > 0;
        }

        public bool DeleteProducto(Producto producto)
        {
            producto.Estado = 0;
            db.Producto.Update(producto);
            return db.SaveChanges() >= 0;
        }

        public bool EditProducto(Producto producto)
        {
            producto.Estado = 1;
            db.Producto.Update(producto);
            return db.SaveChanges() >= 0;
        }

        public Producto GetProducto(int id)
        {
            return db.Producto.First(p => p.Id == id);
        }

        public ICollection GetProductos()
        {
            var productos = (from p in db.Producto
                             join c in db.Categoria on p.CategoriaId equals c.Id
                             where p.Estado == 1
                             select new
                             {
                                 Id = p.Id,
                                 codigo = p.Codigo,
                                 descripcion = p.Descripcion,
                                 costo = p.Costo,
                                 precio = p.Precio,
                                 cantidad = p.Cantidad,
                                 categoriaId = c.Id,
                                 categoria = c.Descripcion
                             }).ToList();

            return productos;
        }
    }
}
