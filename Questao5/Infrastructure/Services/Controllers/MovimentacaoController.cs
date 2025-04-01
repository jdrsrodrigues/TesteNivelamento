using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Commands;

namespace Questao5.Infrastructure.Services.Controllers
{
    // Controlador para movimentações
    [ApiController]
    [Route("api/movimentacao")]
    public class MovimentacaoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public MovimentacaoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> RegistrarMovimentacao([FromBody] RegistrarMovimentacaoCommand command)
        {
            try
            {
#if DEBUG
                command = command with { IdRequisicao = Guid.NewGuid().ToString() };
#endif
                var result = await _mediator.Send(command);
                return Ok(new { IdMovimento = result });
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
