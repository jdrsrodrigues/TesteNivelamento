using MediatR;

namespace Questao5.Application.Commands
{
    public record RegistrarMovimentacaoCommand(string? IdRequisicao, string IdContaCorrente, decimal Valor, char Tipo) : IRequest<string>;
}
