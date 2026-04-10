using TADS_TP.Models;
using TADS_TP.Repositories;

namespace TADS_TP.Services
{
    public class VeiculoService
    {
        private readonly VeiculoRepository _repository;

        public VeiculoService(VeiculoRepository repository)
        {
            _repository = repository;
        }

        public List<VeiculoModel> GetAll()
        {
            return _repository.GetAll();
        }

        public VeiculoModel GetById(int id)
        {
            VeiculoModel veiculo = _repository.GetById(id);

            if (veiculo == null)
                throw new Exception("Veículo não encontrado");

            return veiculo;
        }

        public void Create(VeiculoModel veiculo)
        {
            if (string.IsNullOrEmpty(veiculo.Modelo))
                throw new Exception("Modelo é obrigatório");

            if (veiculo.Ano <= 0)
                throw new Exception("Ano de fabricação inválido");

            if (veiculo.FabricanteId <= 0)
                throw new Exception("Fabricante é obrigatório");

            _repository.Add(veiculo);
        }

        public void Update(int id, VeiculoModel veiculo)
        {
            if (id != veiculo.Id)
                throw new Exception("ID inválido");

            var existente = _repository.GetById(id);

            if (existente == null)
                throw new Exception("Veículo não encontrado");

            if (string.IsNullOrEmpty(veiculo.Modelo))
                throw new Exception("Modelo é obrigatório");

            if (veiculo.Ano <= 0)
                throw new Exception("Ano de fabricação inválido");

            if (veiculo.FabricanteId <= 0)
                throw new Exception("Fabricante é obrigatório");

            _repository.Update(veiculo);
        }

        public void Delete(int id)
        {
            var veiculo = _repository.GetById(id);

            if (veiculo == null)
                throw new Exception("Fabricante não encontrado");

            _repository.Delete(id);
        }

        public List<VeiculoModel> GetByFabricante(string nomeFabricante)
        {
            var veiculos = _repository.GetByFabricante(nomeFabricante);

            if (veiculos == null || veiculos.Count == 0)
                throw new Exception("Nenhum veículo encontrado para esse fabricante");

            return veiculos;
        }
    }
}
