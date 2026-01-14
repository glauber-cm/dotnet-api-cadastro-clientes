using CadastroClientesApi.Data;
using CadastroClientesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesApi.Repositories
{
    public class ClienteRepository : IClienteRepository
    {
        private readonly AppDbContext _context;

        public ClienteRepository(AppDbContext context   )
        {
            _context = context;
        }


        public async Task<IEnumerable<Cliente>> GetAllAsync()
            => await _context.Clientes.ToListAsync();

        public async Task<Cliente?> GetByIdAsync(int id)
            => await _context.Clientes.FindAsync(id);


        public Task AddAsync(Cliente cliente)
        {
           
        }

        public Task DeleteAsync(int id)
        {
        }

        public Task UpdateAsync(Cliente cliente)
        {

        }
    }
}
