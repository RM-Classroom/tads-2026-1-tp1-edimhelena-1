using Microsoft.EntityFrameworkCore;
using TADS_TP.Models;

namespace TADS_TP.Repositories
{
    public class AluguelRepository
    {
        private readonly ApplicationContext _context;
        public AluguelRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(AluguelModel aluguel)
        {
            _context.Alugueis.Add(aluguel);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var aluguel = _context.Alugueis.Find(id);
            if (aluguel != null)
            {
                _context.Alugueis.Remove(aluguel);
                _context.SaveChanges();
            }
        }

        public void Update(AluguelModel aluguel)
        {
            _context.Alugueis.Update(aluguel);
            _context.SaveChanges();
        }

        public AluguelModel GetById(int id)
        {
            return _context.Alugueis.Find(id);
        }

        public List<AluguelModel> GetAll()
        {
            return _context.Alugueis.ToList();
        }

        public List<AluguelModel> GetByCliente(int clienteId)
        {
            return _context.Alugueis
                .Include(a => a.Cliente)
                .Where(a => a.ClienteId == clienteId)
                .ToList();
        }

        public List<AluguelModel> GetByValor(double valor)
        {
            return _context.Alugueis
                .Where(a => a.ValorTotal > valor)
                .ToList();
        }

        public bool VeiculoEstaAlugado(int veiculoId)
        {
            return _context.Alugueis
                .Any(a => a.VeiculoId == veiculoId && a.DataDevolucao == null);
        }

        public List<AluguelModel> GetCompleto()
        {
            return _context.Alugueis
                .Include(a => a.Cliente)
                .Include(a => a.Veiculo)
                .ToList();
        }
    }
}
