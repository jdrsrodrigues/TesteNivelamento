using NSubstitute;
using Questao5.Application.Handlers;
using Questao5.Application.Queries;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Tests
{
    public class ConsultarSaldoHandlerTests
    {
        private readonly IMovimentacaoRepository _movimentoRepository = Substitute.For<IMovimentacaoRepository>();
        private readonly IContaCorrenteRepository _contaCorrenteRepository = Substitute.For<IContaCorrenteRepository>();

        [Fact]
        public async Task Deve_Retornar_Erro_Se_Conta_Nao_Existe()
        {
            // Arrange
            var handler = new ConsultarSaldoHandler(_movimentoRepository, _contaCorrenteRepository);
            var query = new ConsultarSaldoQuery("9999");

            _contaCorrenteRepository.ObterPorId(query.IdContaCorrente).Returns((ContaCorrente)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(query, CancellationToken.None));
            Assert.Equal("INVALID_ACCOUNT", exception.Message);
        }

        [Fact]
        public async Task Deve_Retornar_Saldo_Se_Conta_Valida()
        {
            // Arrange
            var handler = new ConsultarSaldoHandler(_movimentoRepository, _contaCorrenteRepository);
            var query = new ConsultarSaldoQuery("9999");

            _contaCorrenteRepository.ObterPorId(query.IdContaCorrente).Returns(new ContaCorrente { IdContaCorrente = "9999", Ativo = true, Nome = "João", Numero = 12345 });
            _movimentoRepository.CalcularSaldo(query.IdContaCorrente).Returns(Task.FromResult(500m));

            // Act
            var result = await handler.Handle(query, CancellationToken.None);

            // Assert
            Assert.Equal(500m, result.Saldo);
            Assert.Equal("João", result.NomeTitular);
            Assert.Equal(12345, result.NumeroConta);
        }
    }
}
