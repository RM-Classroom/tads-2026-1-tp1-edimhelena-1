using TADS_TP.Models;
using TADS_TP.Repositories;

namespace TADS_TP.Services
{
    public class PagamentoService
    {
        private readonly PagamentoRepository _repository;

        public PagamentoService(PagamentoRepository repository)
        {
            _repository = repository;
        }

        public List<PagamentoModel> GetAll()
        {
            return _repository.GetAll();
        }

        public PagamentoModel GetById(int id)
        {
            var pagamento = _repository.GetById(id);

            if (pagamento == null)
                throw new Exception("Pagamento não encontrado");

            return pagamento;
        }

        public void Create(PagamentoModel pagamento)
        {
            if(pagamento.AluguelId <= 0)
                throw new Exception("Aluguel é obrigatório");

            if(pagamento.Valor <= 0)
                throw new Exception("Valor deve ser maior que zero");

            if(string.IsNullOrEmpty(pagamento.Status))
                throw new Exception("Status é obrigatório");

            if(pagamento.DataPagamento == default)
                throw new Exception("Data de pagamento é obrigatória");

            _repository.Add(pagamento);
        }

        public void Update(int id, PagamentoModel pagamento)
        {
            if (id != pagamento.Id)
                throw new Exception("ID inválido");

            var existente = _repository.GetById(id);

            if (existente == null)
                throw new Exception("Pagamento não encontrado");

            if (pagamento.AluguelId <= 0)
                throw new Exception("Aluguel é obrigatório");

            if (pagamento.Valor <= 0)
                throw new Exception("Valor deve ser maior que zero");

            if (string.IsNullOrEmpty(pagamento.Status))
                throw new Exception("Status é obrigatório");

            if (pagamento.DataPagamento == default)
                throw new Exception("Data de pagamento é obrigatória");

            _repository.Update(pagamento);
        }

        public void Delete(int id)
        {
            var pagamento = _repository.GetById(id);

            if (pagamento == null)
                throw new Exception("Pagamento não encontrado");

            _repository.Delete(id);
        }

        public List<PagamentoModel> GetByAluguel(int aluguelId)
        {
            return _repository.GetByAluguel(aluguelId);
        }
    }
}
