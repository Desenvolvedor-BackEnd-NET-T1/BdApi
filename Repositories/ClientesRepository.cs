using DbApi.Models;
using DbApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbApi.Repositories
{

    public class ClientesRepository : IClientesRepository
    {
        private AppDbContext _context;

        public ClientesRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task Atualizar(Cliente cliente)
        {
            _context.Clientes.Update(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task Deletar(Cliente cliente)
        {
            _context.Clientes.Remove(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task InserirAsync(Cliente cliente)
        {
            await _context.Clientes.AddAsync(cliente);
            await _context.SaveChangesAsync();
        }

        public async Task<Cliente> ObterPorIdAsync(string id)
        {
            return await _context.Clientes.FindAsync(id); 
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            return await _context.Clientes.ToListAsync();
        }
    }
}