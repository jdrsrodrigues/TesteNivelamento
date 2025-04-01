using Dapper;
using Questao5.Application.Commands;
using Questao5.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace Questao5.Infrastructure.Repositories
{
    public class MovimentacaoRepository : IMovimentacaoRepository
    {
        private readonly IDbConnection _dbConnection;

        public MovimentacaoRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<string> RegistrarMovimento(RegistrarMovimentacaoCommand command)
        {
            var idMovimento = Guid.NewGuid().ToString();
            var query = "INSERT INTO movimento (idmovimento, idcontacorrente, datamovimento, tipomovimento, valor) VALUES (@Id, @ContaId, @Data, @Tipo, @Valor)";
            await _dbConnection.ExecuteAsync(query, new { Id = idMovimento, ContaId = command.IdContaCorrente, Data = DateTime.UtcNow.ToString("o"), Tipo = command.Tipo, Valor = command.Valor });
            return idMovimento;
        }

        public async Task<decimal> CalcularSaldo(string idContaCorrente)
        {
            var query = "SELECT COALESCE(SUM(CASE WHEN tipomovimento = 'C' THEN valor ELSE -valor END), 0) FROM movimento WHERE idcontacorrente = @Id";
            return await _dbConnection.ExecuteScalarAsync<decimal>(query, new { Id = idContaCorrente });
        }
    }
}
