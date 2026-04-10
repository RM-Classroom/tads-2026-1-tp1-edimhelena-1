using TADS_TP.Models;

namespace TADS_TP.Repositories
{
    public class FabricanteRepository
    {
        private readonly ApplicationContext _context;
        public FabricanteRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(FabricanteModel fabricante)
        {
            _context.Fabricantes.Add(fabricante);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var fabricante = _context.Fabricantes.Find(id);
            if (fabricante != null)
            {
                _context.Fabricantes.Remove(fabricante);
                _context.SaveChanges();
            }
        }

        public void Update(FabricanteModel fabricante)
        {
            _context.Fabricantes.Update(fabricante);
            _context.SaveChanges();
        }

        public FabricanteModel GetById(int id)
        {
            return _context.Fabricantes.Find(id);
        }

        public List<FabricanteModel> GetAll()
        {
            return _context.Fabricantes.ToList();
        }
    }
}
