using DbApi.DTO;
using DbApi.Excepetions;

namespace DbApi.Config
{
    public class ErrorMiddleware
    {
        private RequestDelegate _next; 

        public ErrorMiddleware(RequestDelegate next)
        {
            _next  = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                
            }
            catch(NotFoundException ex)
            {
                context.Response.StatusCode = 400;
                var resposta = new ErrorDTO(ex.Message);
                await context.Response.WriteAsJsonAsync(resposta);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ocorreu um erro ao obter os clientes: {ex.Message}");
                //return StatusCode(500, "Ocorreu um erro na chamada por favor tente novamente mais tarde");
                context.Response.StatusCode = 500;

                var resposta = new ErrorDTO("Ocorreu um erro na chamada por favor tente novamente mais tarde");

                await context.Response.WriteAsJsonAsync(resposta);

            }
            
        }

    }
}