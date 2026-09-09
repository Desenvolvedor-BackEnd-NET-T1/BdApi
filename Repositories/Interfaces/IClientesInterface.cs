using DbApi.Models;

namespace DbApi.Repositories.Interfaces
{
    public interface IClientesRepository
    {
        Task<List<Cliente>> ObterTodosAsync();
        Task<Cliente> ObterPorIdAsync(string id);
        Task InserirAsync(Cliente cliente);
        Task Deletar(Cliente cliente);
        Task Atualizar(Cliente cliente);
    }

}