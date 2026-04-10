using TADS_TP.Models;
using TADS_TP.Repositories;

namespace TADS_TP.Services
{
    public class AluguelService
    {
        private readonly AluguelRepository _repository;

        public AluguelService(AluguelRepository repository)
        {
            _repository = repository;
        }

        public List<AluguelModel> GetAll()
        {
            return _repository.GetAll();
        }

        public AluguelModel GetById(int id)
        {
            var aluguel = _repository.GetById(id);

            if (aluguel == null)
                throw new Exception("Aluguel não encontrado");

            return aluguel;
        }

        public void Create(AluguelModel aluguel)
        {

            if (aluguel.ClienteId <= 0)
                throw new Exception("Cliente é obrigatório");

            if (aluguel.VeiculoId <= 0)
                throw new Exception("Veículo é obrigatório");

            if (aluguel.DataInicio >= aluguel.DataFim)
                throw new Exception("Data fim deve ser maior que data início");

            if (aluguel.ValorDiaria <= 0)
                throw new Exception("Valor da diária inválido");

            bool veiculoOcupado = _repository.VeiculoEstaAlugado(aluguel.VeiculoId);

            if (veiculoOcupado)
                throw new Exception("Veículo já está alugado");

            var dias = (aluguel.DataFim - aluguel.DataInicio).Days;

            aluguel.ValorTotal = dias * aluguel.ValorDiaria;

            _repository.Add(aluguel);
        }

        public void Update(int id, AluguelModel aluguel)
        {
            if (id != aluguel.Id)
                throw new Exception("ID inválido");

            var existente = _repository.GetById(id);

            if (existente == null)
                throw new Exception("Aluguel não encontrado");

            _repository.Update(aluguel);
        }

        public void Delete(int id)
        {
            var aluguel = _repository.GetById(id);

            if (aluguel == null)
                throw new Exception("Aluguel não encontrado");

            _repository.Delete(id);
        }

        public List<AluguelModel> GetCompleto()
        {
            var dados = _repository.GetCompleto();

            if (dados == null || dados.Count == 0)
                throw new Exception("Nenhum aluguel encontrado");

            return dados;
        }

        public List<AluguelModel> GetByCliente(int clienteId)
        {
            var alugueis = _repository.GetByCliente(clienteId);

            if (alugueis == null || alugueis.Count == 0)
                throw new Exception("Nenhum aluguel encontrado para este cliente");

            return alugueis;
        }

        public List<AluguelModel> GetByValor(decimal valor)
        {
            var alugueis = _repository.GetByValor(valor);

            if (alugueis == null || alugueis.Count == 0)
                throw new Exception("Nenhum aluguel encontrado com esse valor");

            return alugueis;
        }
    }
}
