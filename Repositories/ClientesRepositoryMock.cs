using DbApi.Models;
using DbApi.Repositories.Interfaces;

namespace DbApi.Repositories
{
    public class ClientesRepositoryMock : IClientesRepository
    {
        public async Task Atualizar(Cliente cliente)
        {
        }

        public async Task Deletar(Cliente cliente)
        {
           
        }

        public async Task InserirAsync(Cliente cliente)
        {
            
        }

        public async  Task<Cliente> ObterPorIdAsync(string id)
        {
            return new Cliente()
            {
                Nome = "Mock", Endereco = "teste"

            };
        }

        public async Task<List<Cliente>> ObterTodosAsync()
        {
            var lista =  new List<Cliente>();
            

            lista.Add(
                new Cliente()
                {
                    Nome = "Mock", Endereco = "teste"

                });

            lista.Add(
                new Cliente()
                {
                    Nome = "Mock2", Endereco = "teste"

                });
            return lista; 
            
        }
    }
}