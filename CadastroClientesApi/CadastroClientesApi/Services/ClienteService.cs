using CadastroClientesApi.DTOs;
using CadastroClientesApi.Models;
using CadastroClientesApi.Repositories;

namespace CadastroClientesApi.Services
{
    public class ClienteService
    {
        private readonly IClienteRepository _repository;

        public ClienteService(IClienteRepository repository)
        {
            _repository = repository;
        }

        public async Task<IEnumerable<Cliente>> GetAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<Cliente?> GetByIdAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<Cliente> CreateAsync(ClienteCreateDto dto)
        {
            var cliente = new Cliente
            {
                Nome = dto.Nome,
                Email = dto.Email,
                Telefone = dto.Telefone
            };

            await _repository.AddAsync(cliente);

            return cliente;
        }

        public async Task<bool> UpdateAsync(int id, ClienteCreateDto dto)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
                return false;

            cliente.Nome = dto.Nome;
            cliente.Email = dto.Email;
            cliente.Telefone = dto.Telefone;

            await _repository.UpdateAsync(cliente);

            return true;
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var cliente = await _repository.GetByIdAsync(id);

            if (cliente == null)
                return false;

            await _repository.DeleteAsync(cliente);
            return true;
        }

    }
}
