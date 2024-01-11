using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using FluxoCaixa.Domain.Events.FluxoCaixa;
using FluxoCaixa.Tests.Integrations.Configuration;
using Moq;

namespace FluxoCaixa.Tests.Integrations.FluxoCaixa.UseCases
{
    public class CriarCaixaUseCaseTests
    {

        [Fact]
        public async Task CriarCaixaUseCase_WhenValidAndNoSaldoInicial_ShouldReturnCaixaOnly()
        {
            #region Arrange;
            var nome = "teste";
            var saldo = 0;

            var fixture = new FluxoCaixaServicesFixture();
            var criarCaixaDto = new CriarCaixaDto()
            {
                Nome = nome,
                SaldoInicial = saldo
            };

            var cancellationToken = new CancellationToken();

            var useCase = fixture.NewCriarCaixaUseCase();
            #endregion

            var resultado = await useCase.ExecutarAsync(criarCaixaDto, cancellationToken);

            #region Assert
            var caixa = resultado.Value;
            Assert.True(resultado.IsSuccess);
            Assert.Equal(nome, caixa.Nome);
            Assert.Equal(saldo, caixa.Saldo.Valor);

            fixture.MockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<CaixaCriada>(), cancellationToken),
                Times.Once());

            var dbCaixa = fixture.DbContext.Caixas.Where(x => x.Id == caixa.Id).FirstOrDefault();
            Assert.NotNull(dbCaixa);
            Assert.Equal(caixa.Nome, dbCaixa.Nome);
            #endregion
        }

        [Fact]
        public async Task CriarCaixaUseCase_WhenValidAndWithSaldoInicial_ShouldReturnCaixaWithLancamento()
        {
            #region Arrange;
            var nome = "teste";
            var saldo = 50;

            var fixture = new FluxoCaixaServicesFixture();
            var criarCaixaDto = new CriarCaixaDto()
            {
                Nome = nome,
                SaldoInicial = saldo
            };

            var cancellationToken = new CancellationToken();

            var useCase = fixture.NewCriarCaixaUseCase();
            #endregion

            var resultado = await useCase.ExecutarAsync(criarCaixaDto, cancellationToken);

            #region Assert
            var caixa = resultado.Value;
            Assert.True(resultado.IsSuccess);
            Assert.Equal(nome, caixa.Nome);
            Assert.Equal(saldo, caixa.Saldo.Valor);
            Assert.Equal(saldo, caixa.Lancamentos.First().Valor);

            fixture.MockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<CaixaCriada>(), cancellationToken),
                Times.Once());

            var dbCaixa = fixture.DbContext.Caixas.Where(x => x.Id == caixa.Id).FirstOrDefault();
            Assert.NotNull(dbCaixa);
            Assert.Equal(caixa.Nome, dbCaixa.Nome);

            var dbLancamentos = fixture.DbContext.Lancamentos.Where(x => caixa.Id == x.Id);
            Assert.Single(dbLancamentos);

            var lancamento = dbLancamentos.First();
            Assert.Equal(saldo, lancamento.Valor);
            Assert.Equal(TipoLancamento.Credito, lancamento.Tipo);
            #endregion
        }

        [Theory]
        [InlineData("nome", -1)]
        [InlineData(" ", 0)]
        [InlineData(null, -1)]
        public async Task CriarCaixaAsync_WhenInvalidInput_ReturnFail(string nome, double saldoInicial)
        {
            #region Arrange;
            var fixture = new FluxoCaixaServicesFixture();
            var criarCaixaDto = new CriarCaixaDto()
            {
                Nome = nome,
                SaldoInicial = saldoInicial
            };

            var cancellationToken = new CancellationToken();


            var useCase = fixture.NewCriarCaixaUseCase();
            #endregion

            var resultado = await useCase.ExecutarAsync(criarCaixaDto, cancellationToken);

            #region Assert
            Assert.True(resultado.IsFailed);

            fixture.MockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<CaixaCriada>(), cancellationToken),
                Times.Never());


            var dbCaixa = fixture.DbContext.Caixas.FirstOrDefault();
            Assert.Null(dbCaixa);

            var dbLancamentos = fixture.DbContext.Lancamentos.FirstOrDefault();
            Assert.Null(dbLancamentos);

            #endregion
        }
    }
}