using TADS_TP.Models;

namespace TADS_TP.Repositories
{
    public class ClienteRepository
    {
        private readonly ApplicationContext _context;
        public ClienteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(ClienteModel cliente)
        {
            _context.Clientes.Add(cliente);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var cliente = _context.Clientes.Find(id);
            if (cliente != null)
            {
                _context.Clientes.Remove(cliente);
                _context.SaveChanges();
            }
        }

        public void Update(ClienteModel cliente)
        {
            _context.Clientes.Update(cliente);
            _context.SaveChanges();
        }

        public ClienteModel GetById(int id)
        {
            return _context.Clientes.Find(id);
        }

        public List<ClienteModel> GetAll()
        {
            return _context.Clientes.ToList();
        }
    }
}
