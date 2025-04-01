using MediatR;
using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class ConsultarSaldoHandler : IRequestHandler<ConsultarSaldoQuery, SaldoDto>
    {
        private readonly IMovimentacaoRepository _movimentoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public ConsultarSaldoHandler(IMovimentacaoRepository movimentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<SaldoDto> Handle(ConsultarSaldoQuery request, CancellationToken cancellationToken)
        {
            var conta = await _contaCorrenteRepository.ObterPorId(request.IdContaCorrente);
            if (conta == null)
                throw new Exception("INVALID_ACCOUNT");

            if (!conta.Ativo)
                throw new Exception("INACTIVE_ACCOUNT");

            var saldo = await _movimentoRepository.CalcularSaldo(request.IdContaCorrente);
            return new SaldoDto(conta.Numero, conta.Nome, DateTime.UtcNow, saldo);
        }
    }
}
