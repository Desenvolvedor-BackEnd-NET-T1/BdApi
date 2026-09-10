using Microsoft.AspNetCore.Mvc;
using DbApi.Models;
using DbApi.Repositories.Interfaces;


namespace DbApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController: ControllerBase
    {
        private IClientesRepository _clienteRepository;

        public ClientesController(IClientesRepository clienteRepository)
        {
            _clienteRepository = clienteRepository;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            //todo obter todos os  clientes  registardos no  banco de dados;

            List<Cliente> clientes =  await _clienteRepository.ObterTodosAsync();
            return Ok(clientes); 
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute]string id)
        {
            //Cliente cliente = await _contexto.Clientes.FindAsync(id);
            Cliente cliente = await _clienteRepository.ObterPorIdAsync(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Cliente  cliente)
        {
            await _clienteRepository.InserirAsync(cliente);
            //todo: salvar o cliente no banco de dados. 
            return Created("/clientes",cliente);
        }

        [HttpDelete("{id}")]
        //[HttpDelete("{id}")] é a mesma coisa que [Route("{id}")]
        public async Task<IActionResult> DeleteAscync([FromRoute] string id)
        {   
            Cliente  cliente = await _clienteRepository.ObterPorIdAsync(id);

            if(cliente == null)
            {
                return Ok();
            }  
            await _clienteRepository.Deletar(cliente);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string id, [FromBody]Cliente clienteAtualizado)
        {
            var clienteDb  = await _clienteRepository.ObterPorIdAsync(id);
            
            if(clienteDb == null)
            {
                return NotFound($"cliente Id : {id} não encontrado"); 
            }

            clienteDb.Update(clienteAtualizado);

            await _clienteRepository.Atualizar(clienteDb);

            return Ok();
        }


    }
}