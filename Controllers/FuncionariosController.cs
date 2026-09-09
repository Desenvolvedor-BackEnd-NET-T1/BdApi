using DbApi.Models;
using Microsoft.AspNetCore.Mvc;
using DbApi.Repositories;

namespace DbApi.Controllers
{
    [ApiController]
    [Route("funcionarios")] 
    //pode aparecer como [controller] esse cenario vai pegar o nome da controller e remover a palavra controller
    public class FuncionariosController : ControllerBase
    {
        private FuncionariosRepository _funcionariosRepository; 

        public FuncionariosController(AppDbContext context)
        {
            _funcionariosRepository = new FuncionariosRepository(context);
        }
        [HttpGet]
        public async Task<IActionResult> ObterFuncionariosAsync ()
        {
            List<Funcionario> funcionarios = await _funcionariosRepository.ObterTodosAsync();
            return Ok(funcionarios);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] string id)
        {
            Funcionario func = await  _funcionariosRepository.ObterPorIdAsync(id);
            return Ok(func);
        }
        

        [HttpPost]
        public async Task<IActionResult> InserirFuncionariosAsync([FromBody] Funcionario funcionario)
        {
            await _funcionariosRepository.InserirAsync(funcionario);
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] string id)
        {
            Funcionario funcionario = await _funcionariosRepository.ObterPorIdAsync(id);

            if(funcionario == null)
            {
                return NoContent();
            }

            await _funcionariosRepository.DeletarAsync(funcionario);

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] Funcionario funcionarioAtualizado)
        {
            Funcionario funcionarioDB = await _funcionariosRepository.ObterPorIdAsync(id);
            if(funcionarioDB == null)
            {
                return NotFound("Funcionario nõa encontrado!"); 
            }
            // funcionarioDB.Nome = funcionarioAtualizado.Nome;
            // funcionarioDB.Email = funcionarioAtualizado.Email;
            funcionarioDB.Update(funcionarioAtualizado);
            await _funcionariosRepository.AtualizarAsync(funcionarioDB);
            return Ok(); 
        }  
    }
}