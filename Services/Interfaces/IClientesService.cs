using DbApi.Models;

namespace DbApi.Services.interfaces
{
    public interface IClientesService
    {
        Task<List<Cliente>> ObterTodosAsync();
        Task<Cliente> ObterPorIdAsync(string id);
        Task InserirAsync(Cliente cliente);

        Task Deletar (string id);
        Task Update(Cliente clienteAtualizado, string id);
    }
}