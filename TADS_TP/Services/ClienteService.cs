using TADS_TP.Models;
using TADS_TP.Repositories;

namespace TADS_TP.Services
{
    public class ClienteService
    {
        private readonly ClienteRepository _repository;

        public ClienteService(ClienteRepository repository)
        {
            _repository = repository;
        }

        public List<ClienteModel> GetAll()
        {
            return _repository.GetAll();
        }

        public ClienteModel GetById(int id)
        {
            ClienteModel cliente = _repository.GetById(id);

            if(cliente == null)
                throw new Exception("Cliente não encontrado");

            return cliente;
        }

        public void Create(ClienteModel cliente)
        {
            if (string.IsNullOrEmpty(cliente.Nome))
                throw new Exception("Nome é obrigatório");

            if (string.IsNullOrEmpty(cliente.CPF))
                throw new Exception("CPF é obrigatório");

            if (string.IsNullOrEmpty(cliente.Email))
                throw new Exception("Email é obrigatório");

            _repository.Add(cliente);
        }

        public void Update(int id, ClienteModel cliente)
        {
            if (id != cliente.Id)
                throw new Exception("ID inválido");

            ClienteModel res = _repository.GetById(id);

            if (res == null)
                throw new Exception("Cliente não encontrado");

            if (string.IsNullOrEmpty(cliente.Nome))
                throw new Exception("Nome é obrigatório");

            if (string.IsNullOrEmpty(cliente.CPF))
                throw new Exception("CPF é obrigatório");

            if (string.IsNullOrEmpty(cliente.Email))
                throw new Exception("Email é obrigatório");

            _repository.Update(cliente);
        }

        public void Delete(int id)
        {
            var cliente = _repository.GetById(id);

            if (cliente == null)
                throw new Exception("Cliente não encontrado");

            _repository.Delete(id);
        }
    }
}
