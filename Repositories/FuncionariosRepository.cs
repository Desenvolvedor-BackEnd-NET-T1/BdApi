using DbApi.Models;
using DbApi.Repositories.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DbApi.Repositories
{
    
    public class FuncionariosRepository : IFuncionariosRepository
    {
        private AppDbContext _contexto;

        public FuncionariosRepository(AppDbContext context )
        {
            _contexto = context  ;
        }

        public async Task<List<Funcionario>> ObterTodosAsync ()
        {
            return await _contexto.Funcionarios.ToListAsync();
        }

        public async Task<Funcionario> ObterPorIdAsync(string id)
        {
            //return await _contexto.Funcionarios.Where(f=>f.Id == id).FirstOrDefaultAsync();
            return await _contexto.Funcionarios.FindAsync(id);
        }

        public async Task  InserirAsync(Funcionario func)
        {
            await _contexto.Funcionarios.AddAsync(func);
            await _contexto.SaveChangesAsync();
        }

        public async Task DeletarAsync(Funcionario func)
        {
            _contexto.Funcionarios.Remove(func);
            await _contexto.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Funcionario func)
        {
            _contexto.Funcionarios.Update(func);
            await _contexto.SaveChangesAsync();
        }
    }
}