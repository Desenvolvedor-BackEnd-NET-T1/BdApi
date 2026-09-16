using Microsoft.AspNetCore.Mvc;
using DbApi.Models;
using DbApi.Services.interfaces;
using DbApi.Excepetions;
using DbApi.DTO;


namespace DbApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController: ControllerBase
    {

        private IClientesService _clientesService;

        public ClientesController(IClientesService clientesService)
        {
            _clientesService = clientesService;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            //try { 
                //todo obter todos os  clientes  registardos no  banco de dados;

                List<Cliente> clientes =  await _clientesService.ObterTodosAsync();
                return Ok(clientes); 
            // }
            // catch (Exception ex)
            // {
            //     Console.WriteLine($"Ocorreu um erro ao obter os clientes: {ex.Message}");
            //     return StatusCode(500, "Lascou de vez!!! ");
            // }
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute]string id)
        {
            //Cliente cliente = await _contexto.Clientes.FindAsync(id);
            Cliente cliente = await _clientesService.ObterPorIdAsync(id);
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Cliente  cliente)
        {
            await _clientesService.InserirAsync(cliente);
            //todo: salvar o cliente no banco de dados. 
            return Created("/clientes",cliente);
        }

        [HttpDelete("{id}")]
        //[HttpDelete("{id}")] é a mesma coisa que [Route("{id}")]
        public async Task<IActionResult> DeleteAscync([FromRoute] string id)
        {   
            await _clientesService.Deletar(id);
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string id, [FromBody]Cliente clienteAtualizado)
        {
            await _clientesService.Update(clienteAtualizado, id);
            return Ok();
        }
    }
}