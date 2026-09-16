using DbApi.Excepetions;
using DbApi.Models;
using DbApi.Repositories.Interfaces;
using DbApi.Services.interfaces;

namespace DbApi.Services
{
    public class ClientesServices : IClientesService
    {
        private IClientesRepository _clientesRepository;

        public ClientesServices (IClientesRepository clientesRepository)
        {
            _clientesRepository = clientesRepository;
        }


        public async Task Deletar (string id)
        {
            Cliente  cliente = await _clientesRepository.ObterPorIdAsync(id);

            if(cliente != null)
            {
                await _clientesRepository.Deletar(cliente);
            }  
        }

        public async Task InserirAsync(Cliente cliente)
        {
            await _clientesRepository.InserirAsync(cliente);
        }

        public async Task<Cliente> ObterPorIdAsync(string id)
        {
            return await _clientesRepository.ObterPorIdAsync(id);
        }

        public async Task<List<Cliente>> ObterTodosAsync() 
                => await _clientesRepository.ObterTodosAsync();

        public async Task Update(Cliente clienteAtualizado, string id)
        {
            var clienteDb  = await _clientesRepository.ObterPorIdAsync(id);
            
            if(clienteDb == null)
            {
                throw new NotFoundException($"cliente Id : {id} não encontrado"); 
            }

            clienteDb.Update(clienteAtualizado);

            await _clientesRepository.Atualizar(clienteDb);
        }
    }
}