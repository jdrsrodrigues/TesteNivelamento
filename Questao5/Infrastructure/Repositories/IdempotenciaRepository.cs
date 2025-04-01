using Dapper;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace Questao5.Infrastructure.Repositories
{
    public class IdempotenciaRepository : IIdempotenciaRepository
    {
        private readonly IDbConnection _dbConnection;

        public IdempotenciaRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<Idempotencia> ObterPorChave(string chave)
        {
            var query = "SELECT * FROM idempotencia WHERE chave_idempotencia = @Chave";
            return await _dbConnection.QueryFirstOrDefaultAsync<Idempotencia>(query, new { Chave = chave });
        }

        public async Task Salvar(Idempotencia idempotencia)
        {
            var query = "INSERT INTO idempotencia (chave_idempotencia, requisicao, resultado) VALUES (@Chave, @Requisicao, @Resultado) ON CONFLICT(chave_idempotencia) DO UPDATE SET requisicao = @Requisicao, resultado = @Resultado";
            await _dbConnection.ExecuteAsync(query, new { Chave = idempotencia.ChaveIdempotencia, Requisicao = idempotencia.Requisicao, Resultado = idempotencia.Resultado });
        }
    }
}
