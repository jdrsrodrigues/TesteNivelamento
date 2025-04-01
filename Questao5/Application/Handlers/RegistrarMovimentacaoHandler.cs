using MediatR;
using Questao5.Application.Commands;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Database;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Application.Handlers
{
    public class RegistrarMovimentacaoHandler : IRequestHandler<RegistrarMovimentacaoCommand, string>
    {
        private readonly IMovimentacaoRepository _movimentoRepository;
        private readonly IContaCorrenteRepository _contaCorrenteRepository;

        public RegistrarMovimentacaoHandler(IMovimentacaoRepository movimentoRepository, IContaCorrenteRepository contaCorrenteRepository)
        {
            _movimentoRepository = movimentoRepository;
            _contaCorrenteRepository = contaCorrenteRepository;
        }

        public async Task<string> Handle(RegistrarMovimentacaoCommand request, CancellationToken cancellationToken)
        {
            var conta = await _contaCorrenteRepository.ObterPorId(request.IdContaCorrente);
            if (conta == null)
                throw new Exception("INVALID_ACCOUNT");

            if (!conta.Ativo)
                throw new Exception("INACTIVE_ACCOUNT");

            if (request.Valor <= 0)
                throw new Exception("INVALID_VALUE");

            if (request.Tipo != 'C' && request.Tipo != 'D')
                throw new Exception("INVALID_TYPE");

            return await _movimentoRepository.RegistrarMovimento(request);
        }
    }
}
