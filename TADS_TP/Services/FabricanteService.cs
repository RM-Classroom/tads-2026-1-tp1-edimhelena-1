using TADS_TP.Models;
using TADS_TP.Repositories;

namespace TADS_TP.Services
{
    public class FabricanteService
    {
        private readonly FabricanteRepository _repository;

        public FabricanteService(FabricanteRepository repository)
        {
            _repository = repository;
        }

        public List<FabricanteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public FabricanteModel GetById(int id)
        {
            FabricanteModel fabricante = _repository.GetById(id);

            if (fabricante == null)
                throw new Exception("Fabricante não encontrado");

            return fabricante;
        }

        public void Create(FabricanteModel fabricante)
        {
            if (string.IsNullOrEmpty(fabricante.Nome))
                throw new Exception("Nome é obrigatório");

            if (string.IsNullOrEmpty(fabricante.Contato))
                throw new Exception("contato é obrigatório");

            _repository.Add(fabricante);
        }

        public void Update(int id, FabricanteModel fabricante)
        {
            if (id != fabricante.Id)
                throw new Exception("ID inválido");

            FabricanteModel res = _repository.GetById(id);

            if (res == null)
                throw new Exception("Cliente não encontrado");

            if (string.IsNullOrEmpty(fabricante.Nome))
                throw new Exception("Nome é obrigatório");

            if (string.IsNullOrEmpty(fabricante.Contato))
                throw new Exception("Contato é obrigatório");

            _repository.Update(fabricante);
        }

        public void Delete(int id)
        {
            var fabricante = _repository.GetById(id);

            if (fabricante == null)
                throw new Exception("Fabricante não encontrado");

            _repository.Delete(id);
        }
    }
}
