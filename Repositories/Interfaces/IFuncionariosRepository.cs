using DbApi.Models;

namespace DbApi.Repositories.Interfaces
{
    public interface IFuncionariosRepository
    { 
        Task<List<Funcionario>> ObterTodosAsync ();
        Task<Funcionario> ObterPorIdAsync(string id);
        Task  InserirAsync(Funcionario func);
        Task DeletarAsync(Funcionario func);
        Task AtualizarAsync(Funcionario func);
    }
}