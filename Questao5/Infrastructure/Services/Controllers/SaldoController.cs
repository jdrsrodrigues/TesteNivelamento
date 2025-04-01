using MediatR;
using Microsoft.AspNetCore.Mvc;
using Questao5.Application.Queries;

namespace Questao5.Infrastructure.Services.Controllers
{
    [ApiController]
    [Route("api/saldo")]
    public class SaldoController : ControllerBase
    {
        private readonly IMediator _mediator;

        public SaldoController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet("{idContaCorrente}")]
        public async Task<IActionResult> ConsultarSaldo(string idContaCorrente)
        {
            try
            {
                var result = await _mediator.Send(new ConsultarSaldoQuery(idContaCorrente));
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Error = ex.Message });
            }
        }
    }
}
