using TADS_TP.Models;

namespace TADS_TP.Repositories
{
    public class PagamentoRepository
    {
        private readonly ApplicationContext _context;
        public PagamentoRepository(ApplicationContext context)
        {
            _context = context;
        }

        public void Add(PagamentoModel pagamento)
        {
            _context.Pagamentos.Add(pagamento);
            _context.SaveChanges();
        }

        public void Delete(int id)
        {
            var pagamento = _context.Pagamentos.Find(id);
            if (pagamento != null)
            {
                _context.Pagamentos.Remove(pagamento);
                _context.SaveChanges();
            }
        }

        public void Update(PagamentoModel pagamento)
        {
            _context.Pagamentos.Update(pagamento);
            _context.SaveChanges();
        }

        public PagamentoModel GetById(int id)
        {
            return _context.Pagamentos.Find(id);
        }

        public List<PagamentoModel> GetAll()
        {
            return _context.Pagamentos.ToList();
        }

        public List<PagamentoModel> GetByAluguel(int aluguelId)
        {
            return _context.Pagamentos
                .Where(p => p.AluguelId == aluguelId)
                .ToList();
        }
    }
}
