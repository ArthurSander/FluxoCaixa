using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Events;
using FluxoCaixa.Domain.Events.FluxoCaixa;
using FluxoCaixa.Domain.Repositories.FluxoCaixa;
using FluxoCaixa.Domain.Services.FluxoCaixa;
using FluxoCaixa.Shared.Results.FluxoCaixa;
using Moq;
using Serilog;

namespace FluxoCaixa.Tests.Unit.Domain.Services.FluxoCaixa
{
    public class FluxoCaixaServiceTest
    {
        [Fact]
        public async Task CriarCaixaAsync_WhenValid_PublishMessageAndReturnCaixa()
        {
            #region Arrange
            var cancellationToken = new CancellationToken();
            var caixa = new Caixa("teste", 53);
            var updatedCaixa = new Caixa(2, "teste", 53);

            var mockRepository = new Mock<ICaixaWriteRepository>();
            var mockLogger = new Mock<ILogger>();
            var mockEventPublisher = new Mock<IEventPublisher>();

            mockRepository.Setup(x => x.CriarCaixaAsync(caixa, cancellationToken))
                .ReturnsAsync(updatedCaixa);

            var service = new FluxoCaixaService(mockLogger.Object, mockRepository.Object, mockEventPublisher.Object);
            #endregion

            var result = await service.CriarCaixaAsync(caixa, cancellationToken);

            Assert.True(result.IsSuccess);
            Assert.Equal(updatedCaixa.GetHashCode(), result.Value.GetHashCode());
            mockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<CaixaCriada>(), cancellationToken), Times.Once());
        }

        [Fact]
        public async Task CriarCaixaAsync_WhenNotAbleToCreateInRepository_ReturnFailedResultWithNoEventPublished()
        {
            #region Arrange
            var cancellationToken = new CancellationToken();
            var caixa = new Caixa("teste", 53);

            var mockRepository = new Mock<ICaixaWriteRepository>();
            var mockLogger = new Mock<ILogger>();
            var mockEventPublisher = new Mock<IEventPublisher>();

            mockRepository.Setup(x => x.CriarCaixaAsync(caixa, cancellationToken))
                .ReturnsAsync(Result.Fail("whatever error"));

            var service = new FluxoCaixaService(mockLogger.Object, mockRepository.Object, mockEventPublisher.Object);
            #endregion

            var result = await service.CriarCaixaAsync(caixa, cancellationToken);

            Assert.True(result.IsFailed);
            mockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<CaixaCriada>(), cancellationToken), Times.Never());
        }

        [Fact]
        public async Task ComputarLancamentoAsync_WhenValid_PublishMessageAndReturnCaixa()
        {
            #region Arrange
            var cancellationToken = new CancellationToken();

            var lancamentoId = 12;
            var caixaId = 1;

            var mockCaixa = new Mock<Caixa>();
            var novoLancamento = new NovoLancamento();
            var mockLancamento = new Mock<ILancamento>();
            var mockRepository = new Mock<ICaixaWriteRepository>();
            var mockLogger = new Mock<ILogger>();
            var mockEventPublisher = new Mock<IEventPublisher>();

            mockCaixa.Setup(x => x.AdicionarLancamento(mockLancamento.Object))
                .Returns(novoLancamento);

            mockCaixa.Setup(x => x.Id).Returns(caixaId);

            mockRepository.Setup(x => x.AdicionarLancamentoAsync(caixaId, mockLancamento.Object,
                novoLancamento, cancellationToken))
                .ReturnsAsync(lancamentoId);

            var service = new FluxoCaixaService(mockLogger.Object, mockRepository.Object, mockEventPublisher.Object);
            #endregion

            var resultado = await service.ComputarLancamentoAsync(mockCaixa.Object, mockLancamento.Object, cancellationToken);


            #region Assert
            Assert.True(resultado.IsSuccess);
            Assert.Equal(mockCaixa.Object.GetHashCode(), resultado.Value.GetHashCode());

            mockRepository.Verify(x =>
                x.AdicionarLancamentoAsync(caixaId, mockLancamento.Object, novoLancamento, cancellationToken), 
                Times.Once());
            mockLancamento.Verify(x => x.Criado(lancamentoId), Times.Once());
            mockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<LancamentoCriado>(), cancellationToken), Times.Once());
            #endregion
        }

        [Fact]
        public async Task ComputarLancamentoAsync_WhenCaixaAdicionarLancamentoFails_ReturnFailWithNoEventPublished()
        {
            #region Arrange
            var cancellationToken = new CancellationToken();

            var caixaId = 1;

            var mockCaixa = new Mock<Caixa>();
            var mockLancamento = new Mock<ILancamento>();
            var mockRepository = new Mock<ICaixaWriteRepository>();
            var mockLogger = new Mock<ILogger>();
            var mockEventPublisher = new Mock<IEventPublisher>();

            mockCaixa.Setup(x => x.AdicionarLancamento(mockLancamento.Object))
                .Returns(Result.Fail("whatever error"));

            mockCaixa.Setup(x => x.Id).Returns(caixaId);

            var service = new FluxoCaixaService(mockLogger.Object, mockRepository.Object, mockEventPublisher.Object);
            #endregion

            var resultado = await service.ComputarLancamentoAsync(mockCaixa.Object, mockLancamento.Object, cancellationToken);

            #region Assert
            Assert.True(resultado.IsFailed);

            mockRepository.Verify(x =>
                x.AdicionarLancamentoAsync(caixaId, mockLancamento.Object, It.IsAny<NovoLancamento>(), cancellationToken),
                Times.Never());
            mockLancamento.Verify(x => x.Criado(It.IsAny<int>()), Times.Never());
            mockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<LancamentoCriado>(), cancellationToken), Times.Never());
            #endregion
        }

        [Fact]
        public async Task ComputarLancamentoAsync_WhenAddToRepositoryFails_ReturnFailWithNoEventPublished()
        {
            #region Arrange
            var cancellationToken = new CancellationToken();

            var caixaId = 1;

            var mockCaixa = new Mock<Caixa>();
            var mockLancamento = new Mock<ILancamento>();
            var mockRepository = new Mock<ICaixaWriteRepository>();
            var mockLogger = new Mock<ILogger>();
            var mockEventPublisher = new Mock<IEventPublisher>();
            var novoLancamento = new NovoLancamento();

            mockCaixa.Setup(x => x.AdicionarLancamento(mockLancamento.Object))
                .Returns(novoLancamento);

            mockCaixa.Setup(x => x.Id).Returns(caixaId);

            mockRepository.Setup(x => x.AdicionarLancamentoAsync(caixaId, mockLancamento.Object, novoLancamento, cancellationToken))
                .ReturnsAsync(Result.Fail("whatever error"));

            var service = new FluxoCaixaService(mockLogger.Object, mockRepository.Object, mockEventPublisher.Object);
            #endregion

            var resultado = await service.ComputarLancamentoAsync(mockCaixa.Object, mockLancamento.Object, cancellationToken);

            #region Assert
            Assert.True(resultado.IsFailed);

            mockRepository.Verify(x =>
                x.AdicionarLancamentoAsync(caixaId, mockLancamento.Object, novoLancamento, cancellationToken),
                Times.Once());
            mockLancamento.Verify(x => x.Criado(It.IsAny<int>()), Times.Never());
            mockEventPublisher.Verify(x => x.PublishAsync(It.IsAny<LancamentoCriado>(), cancellationToken), Times.Never());
            #endregion
        }
    }
}
