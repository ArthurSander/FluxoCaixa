using FluentResults;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Saldos;
using Moq;

namespace FluxoCaixa.Tests.Unit.Domain.Contexts.FluxoCaixa
{
    public class CaixaTests
    {
        [Fact]
        public void AdicionarLancamento_WhenContabilizarSuccess_ReturnNovoLancamentoAndFillProperties()
        {
            #region Arrange
            var lancamentoMock = new Mock<ILancamento>();
            var saldoMock = new Mock<Saldo>();
            var novoLancamento = new NovoLancamento(1, 1, 1, 1);

            saldoMock.Setup(x => x.Contabilizar(lancamentoMock.Object))
                .Returns(novoLancamento);

            var caixa = new CaixaMock("Teste");
            caixa.SetSaldo(saldoMock.Object);
            #endregion

            var result = caixa.AdicionarLancamento(lancamentoMock.Object);

            Assert.NotEmpty(caixa.Lancamentos);
            Assert.NotEmpty(caixa.HistoricoLancamentos);
            Assert.Equal(novoLancamento.GetHashCode(), result.Value.GetHashCode());
            Assert.True(result.IsSuccess);
        }

        [Fact]
        public void AdicionarLancamento_WhenContabilizarFails_ReturnResultFailAndDontFillProperties()
        {
            #region Arrange
            var errorMessage = "whatever error";
            var lancamentoMock = new Mock<ILancamento>();
            var saldoMock = new Mock<Saldo>();

            saldoMock.Setup(x => x.Contabilizar(lancamentoMock.Object))
                .Returns(Result.Fail(errorMessage));

            var caixa = new CaixaMock("Teste");
            caixa.SetSaldo(saldoMock.Object);
            #endregion

            var result = caixa.AdicionarLancamento(lancamentoMock.Object);

            Assert.True(result.IsFailed);
            Assert.Equal(errorMessage, result.Errors.First().Message);
        }

        [Theory]
        [InlineData("teste", 0)]
        [InlineData("teste com valor", 200)]
        public void ConstructorNewCaixa_WhenCalled_CreateWithPropertiesSet(string name, double saldoInicial)
        {
            var caixa = new Caixa(name, saldoInicial);

            Assert.Equal(name, caixa.Nome);
            Assert.Equal(saldoInicial, caixa.Saldo.Valor);
        }

        [Theory]
        [InlineData(1, "teste", 0)]
        [InlineData(2, "teste com valor", 240)]
        public void ConstructorExistingCaixa_WhenCalled_CreateWithPropertiesSet(int id, string name, double saldoInicial)
        {
            var caixa = new Caixa(id, name, saldoInicial);

            Assert.Equal(id, caixa.Id);
            Assert.Equal(name, caixa.Nome);
            Assert.Equal(saldoInicial, caixa.Saldo.Valor);
        }
    }
}
