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


        public async Task AddAsync(Cliente cliente)
        {
           _context.Clientes.Add(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }
    }
}
