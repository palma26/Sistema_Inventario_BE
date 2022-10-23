using Sistema_Inventario.Context;
using Sistema_Inventario.Entidades;
using Sistema_Inventario.Services.Interfaces;

namespace Sistema_Inventario.Services
{
    public class ClienteService : ICliente
    {
        private readonly InventarioDbContext db;

        public ClienteService(InventarioDbContext inventarioDbContext)
        {
            this.db = inventarioDbContext;
        }

        public bool AddCliente(Cliente cliente)
        {
            cliente.Estado = 1;
            db.Cliente.Add(cliente);
            return db.SaveChanges() > 0;
        }

        public bool DeleteCliente(Cliente cliente)
        {
            cliente.Estado = 0;
            db.Cliente.Update(cliente);
            return db.SaveChanges() > 0;
        }

        public Cliente GetCliente(int IdCliente)
        {
            return db.Cliente.First(c => c.Id == IdCliente);
        }

        public ICollection<Cliente> GetClientes()
        {
            return (from c in db.Cliente where c.Estado == 1 select c).ToList();
        }

        public bool UpdateCliente(Cliente cliente)
        {
            cliente.Estado = 1;
            db.Cliente.Update(cliente);
            return db.SaveChanges() > 0;
        }
    }
}
