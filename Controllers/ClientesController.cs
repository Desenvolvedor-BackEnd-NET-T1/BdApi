using Microsoft.AspNetCore.Mvc;
using DbApi.Models;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;
using DbApi.Migrations;

namespace DbApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController: ControllerBase
    {
        private AppDbContext _contexto;

        public ClientesController(AppDbContext context)
        {
            _contexto =  context;
        }

        [HttpGet]
        public async Task<IActionResult> ObterTodosAsync()
        {
            //todo obter todos os  clientes  registardos no  banco de dados;

            List<Cliente> clientes =  await _contexto.Clientes.ToListAsync();
            return Ok(clientes); 
        }
        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute]string id)
        {
            //Cliente cliente = await _contexto.Clientes.FindAsync(id);
            Cliente cliente = await _contexto.Clientes.Where(c => c.Id == id).FirstOrDefaultAsync();
            return Ok(cliente);
        }

        [HttpPost]
        public async Task<IActionResult> CriarAsync([FromBody] Cliente  cliente)
        {
            await _contexto.Clientes.AddAsync(cliente);
            await _contexto.SaveChangesAsync();
            //todo: salvar o cliente no banco de dados. 
            return Created("/clientes",cliente);
        }

        [HttpDelete("{id}")]
        //[HttpDelete("{id}")] é a mesma coisa que [Route("{id}")]
        public async Task<IActionResult> DeleteAscync([FromRoute] string id)
        {   
            Cliente  cliente = await _contexto.Clientes.FindAsync(id);

            if(cliente == null)
            {
                return Ok();
            }  
            _contexto.Clientes.Remove(cliente);
            await _contexto.SaveChangesAsync();
            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute]string id, [FromBody]Cliente clienteAtualizado)
        {
            var clienteDb  = await _contexto.Clientes.FindAsync(id);
            
            if(clienteDb == null)
            {
                return NotFound($"cliente Id : {id} não encontrado"); 
            }

            clienteDb.Update(clienteAtualizado);

            _contexto.Clientes.Update(clienteDb);
            await _contexto.SaveChangesAsync();

            return Ok();
        }


    }
}