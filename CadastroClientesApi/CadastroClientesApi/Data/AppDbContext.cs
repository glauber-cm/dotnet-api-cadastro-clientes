using CadastroClientesApi.Models;
using Microsoft.EntityFrameworkCore;

namespace CadastroClientesApi.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options) { }

        public DbSet<Cliente> Clientes => Set<Cliente>();
    }
}
