using Microsoft.AspNetCore.Mvc;
using DbApi.Models;
using System.Net.Http.Headers;
using Microsoft.EntityFrameworkCore;

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
    }
}