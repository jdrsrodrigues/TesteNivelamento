using NSubstitute;
using Questao5.Application.Commands;
using Questao5.Application.Handlers;
using Questao5.Domain.Entities;
using Questao5.Infrastructure.Repositories.Interfaces;

namespace Questao5.Tests
{
    public class RegistrarMovimentacaoHandlerTests
    {
        private readonly IMovimentacaoRepository _movimentoRepository = Substitute.For<IMovimentacaoRepository>();
        private readonly IContaCorrenteRepository _contaCorrenteRepository = Substitute.For<IContaCorrenteRepository>();
        private readonly IIdempotenciaRepository _idempotenciaRepository = Substitute.For<IIdempotenciaRepository>();

        [Fact]
        public async Task Deve_Retornar_Erro_Se_Conta_Nao_Existe()
        {
            // Arrange
            var handler = new RegistrarMovimentacaoHandler(_movimentoRepository, _contaCorrenteRepository);
            var command = new RegistrarMovimentacaoCommand("123", "9999", 100, 'C');

            _contaCorrenteRepository.ObterPorId(command.IdContaCorrente).Returns((ContaCorrente)null);

            // Act & Assert
            var exception = await Assert.ThrowsAsync<Exception>(() => handler.Handle(command, CancellationToken.None));
            Assert.Equal("INVALID_ACCOUNT", exception.Message);
        }

        [Fact]
        public async Task Deve_Retornar_IdMovimento_Se_Conta_Valida()
        {
            // Arrange
            var handler = new RegistrarMovimentacaoHandler(_movimentoRepository, _contaCorrenteRepository);
            var command = new RegistrarMovimentacaoCommand("123", "9999", 100, 'C');

            _contaCorrenteRepository.ObterPorId(command.IdContaCorrente).Returns(new ContaCorrente { IdContaCorrente = "9999", Ativo = true });
            _movimentoRepository.RegistrarMovimento(command).Returns(Task.FromResult("MOV123"));

            // Act
            var result = await handler.Handle(command, CancellationToken.None);

            // Assert
            Assert.Equal("MOV123", result);
        }
    }
}