using DbApi.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DbApi.Controllers
{
    [ApiController]
    [Route("funcionarios")] 
    //pode aparecer como [controller] esse cenario vai pegar o nome da controller e remover a palavra controller
    public class FuncionariosController : ControllerBase
    {
        private AppDbContext _context;

        public FuncionariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpGet]
        public async Task<IActionResult> ObterFuncionariosAsync ()
        {
            List<Funcionario> funcionarios = await _context.Funcionarios.ToListAsync();
            return Ok(funcionarios);
        } 

        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorIdAsync([FromRoute] string id)
        {
            Funcionario func = await  _context.Funcionarios.Where(f => f.Id == id).FirstOrDefaultAsync();
           //Funcionario func = await  _context.Funcionarios.FindAsync(id);
            return Ok(func);
        }
        

        [HttpPost]
        public async Task<IActionResult> InserirFuncionariosAsync([FromBody] Funcionario funcionario)
        {
            await _context.Funcionarios.AddAsync(funcionario);
            await _context.SaveChangesAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete ([FromRoute] string id)
        {
            Funcionario funcionario = await _context.Funcionarios.FindAsync(id);

            if(funcionario == null)
            {
                return NoContent();
            }


            _context.Funcionarios.Remove(funcionario);
            await _context.SaveChangesAsync();

            return NoContent();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateAsync([FromRoute] string id, [FromBody] Funcionario funcionarioAtualizado)
        {
            Funcionario funcionarioDB = await _context.Funcionarios.FindAsync(id);

            if(funcionarioDB == null)
            {
                return NotFound("Funcionario nõa encontrado!"); 
            }
            


            // funcionarioDB.Nome = funcionarioAtualizado.Nome;
            // funcionarioDB.Email = funcionarioAtualizado.Email;

            funcionarioDB.Update(funcionarioAtualizado);

            _context.Funcionarios.Update(funcionarioDB);
            await _context.SaveChangesAsync();

            return Ok(); 
        }


    }

}