using Questao5.Application.Commands;

namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IMovimentacaoRepository
    {
        Task<string> RegistrarMovimento(RegistrarMovimentacaoCommand command);
        Task<decimal> CalcularSaldo(string idContaCorrente);
    }
}
