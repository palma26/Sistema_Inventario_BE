using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

namespace Sistema_Inventario.Services
{
    public class CategoriaService : ICategoria
    {
        private readonly InventarioDbContext db;
        public CategoriaService(InventarioDbContext inventarioDbContext)
        {
            db = inventarioDbContext;
        }
        public bool AddCategoria(Categoria categoria)
        {
            categoria.Estado = 1;
            db.Categoria.Add(categoria);
            return db.SaveChanges() >= 0;
        }

        public bool DeleteCategoria(Categoria categoria)
        {
            categoria.Estado = 0;
            db.Categoria.Update(categoria);
            return db.SaveChanges() >= 0;
        }

        public Categoria GetCategoria(int IdCategoria)
        {
            return db.Categoria.First(c => c.Id == IdCategoria);    
        }

        public ICollection<Categoria> GetCategorias()
        {
            return (from c in db.Categoria where c.Estado == 1 select c).ToList();
        }

        public bool UpdateCategoria(Categoria categoria)
        {
            categoria.Estado = 1;
            return db.SaveChanges() >= 0;
        }
    }
}
