using Microsoft.EntityFrameworkCore;
using TADS_TP.Models;

namespace TADS_TP.Repositories
{
    public class VeiculoRepository
    {
        private readonly ApplicationContext _context;
        public VeiculoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(VeiculoModel veiculo)
        {
            _context.Veiculos.Add(veiculo);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var veiculo = _context.Veiculos.Find(id);
            if (veiculo != null)
            {
                _context.Veiculos.Remove(veiculo);
                _context.SaveChanges();
            }
        }

        public void Update(VeiculoModel veiculo)
        {
            var existente = _context.Veiculos.Find(veiculo.Id);
            if (existente == null) return;
    
            existente.Modelo = veiculo.Modelo;
            existente.Ano = veiculo.Ano;
            existente.Quilometragem = veiculo.Quilometragem;
            existente.FabricanteId = veiculo.FabricanteId;
    
            _context.SaveChanges();
        }

        public VeiculoModel GetById(int id)
        {
            return _context.Veiculos.AsNoTracking().FirstOrDefault(v => v.Id == id);
        }

        public List<VeiculoModel> GetAll()
        {
            return _context.Veiculos.ToList();
        }

        public List<VeiculoModel> GetByFabricante(string nomeFabricante)
        {
            return _context.Veiculos
                .Include(v => v.Fabricante)
                .Where(v => v.Fabricante.Nome == nomeFabricante)
                .ToList();
        }
    }
}
