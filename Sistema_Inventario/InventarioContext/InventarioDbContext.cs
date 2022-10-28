using Microsoft.EntityFrameworkCore;
using Sistema_Inventario.Entidades;

namespace Sistema_Inventario.Context
{
    public class InventarioDbContext : DbContext
    {
        public InventarioDbContext(DbContextOptions<InventarioDbContext> options) : base(options)
        {

        }

        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Sucursal> Sucursal { get; set; }
        public DbSet<Bodega> Bodega { get; set; } 
        public DbSet<Categoria> Categoria { get; set; }
        public DbSet<Producto> Producto { get; set; }
        public DbSet<Existencia> Existencia { get; set; } 
        public DbSet<Cliente> Cliente { get; set; }
        public DbSet<Proveedor> Proveedor { get; set; }
        public DbSet<Compra> Compra { get; set; }
        public DbSet<DetalleCompra> DetalleCompra { get; set; }
        public DbSet<Venta> Venta { get; set; }
        public DbSet<DetalleVenta> DetalleVenta { get; set; }
        public DbSet<NotaCredito> NotaCredito { get; set; }
        public DbSet<NotaDebito> NotaDebito { get; set; }
        public DbSet<Ajuste> Ajuste { get; set; }
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Rol> Rol { get; set; } 

        public DbSet<Traslado> Traslado { get; set; }   
    }
}
