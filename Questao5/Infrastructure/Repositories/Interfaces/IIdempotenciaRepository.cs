using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Repositories.Interfaces
{
    public interface IIdempotenciaRepository
    {
        Task<Idempotencia> ObterPorChave(string chave);
        Task Salvar(Idempotencia idempotencia);
    }
}
