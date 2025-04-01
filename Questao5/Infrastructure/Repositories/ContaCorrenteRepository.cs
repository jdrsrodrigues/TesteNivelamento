using Dapper;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;
using System.Data;

namespace Questao5.Infrastructure.Repositories
{
    public class ContaCorrenteRepository : IContaCorrenteRepository
    {
        private readonly IDbConnection _dbConnection;

        public ContaCorrenteRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task<ContaCorrente> ObterPorId(string id)
        {
            var query = "SELECT * FROM contacorrente WHERE idcontacorrente = @Id";
            return await _dbConnection.QueryFirstOrDefaultAsync<ContaCorrente>(query, new { Id = id });
        }
    }
}
