using MediatR;

namespace Questao5.Application.Queries
{
    public record ConsultarSaldoQuery(string IdContaCorrente) : IRequest<SaldoDto>;
    public record SaldoDto(int NumeroConta, string NomeTitular, DateTime DataConsulta, decimal Saldo);
}
