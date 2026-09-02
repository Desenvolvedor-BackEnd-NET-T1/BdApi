using Microsoft.AspNetCore.Mvc;
using DbApi.Models; 

namespace DbApi.Controllers
{
    [ApiController]
    [Route("clientes")]
    public class ClientesController: ControllerBase
    {
        [HttpGet]
        public IActionResult ObterTodos()
        {
            //todo obter todos os  clientes  registardos no  banco de dados;

            List<Cliente> clientes = new List<Cliente>()
            {
                new Cliente()
                {
                    Nome= "Vitor ", Email = "Vitor@email", Telefone = "546464", Endereco = "rua xpto "
                }, 
                new Cliente()
                {
                    Nome= "Camila ", Email = "Camila@email", Telefone = "546432464", Endereco = "rua abc "
                }, 
                new Cliente()
                {
                    Nome= "Bruno ", Email = "bruno@email", Telefone = "546464", Endereco = "rua xpto "
                }
            };
            return Ok(clientes); 
        }

        [HttpPost]
        public IActionResult Criar([FromBody] Cliente  cliente)
        {
            //todo: salvar o cliente no banco de dados. 
            return Created();
        }
    }
}