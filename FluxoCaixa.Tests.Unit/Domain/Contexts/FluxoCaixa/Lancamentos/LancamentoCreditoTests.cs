using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Tests.Unit.Domain.Contexts.FluxoCaixa.Lancamentos
{
    public class LancamentoCreditoTests
    {
        [Theory]
        [InlineData(100, "Descrição Um", "2024-01-10 18:00:00", 1)]
        [InlineData(1.56, "Descrição Dois", "2024-01-10 15:00:00", 64)]
        public void Novo_WhenCalledWithId_CreateWithId(double valor, string descricao, string strDateTime, int? id)
        {
            var dateTime = DateTime.Parse(strDateTime);
            var lancamento = LancamentoCredito.Novo(valor, descricao, dateTime, id);

            Assert.Equal(valor, lancamento.Valor);
            Assert.Equal(descricao, lancamento.Descricao);
            Assert.Equal(dateTime, lancamento.DataHora);
            Assert.Equal(id, lancamento.Id);
            Assert.Equal(TipoLancamento.Credito, TipoLancamento.Credito);
        }

        [Fact]
        public void Novo_WhenCalledWithId_CreateWithIdSetToZero()
        {
            double valor = 124.52;
            string descricao = "Teste sem id";
            var dateTime = DateTime.Parse("2024-01-10 12:00:00");

            var lancamento = LancamentoCredito.Novo(valor, descricao, dateTime);

            Assert.Equal(valor, lancamento.Valor);
            Assert.Equal(descricao, lancamento.Descricao);
            Assert.Equal(dateTime, lancamento.DataHora);
            Assert.Equal(0, lancamento.Id);
            Assert.Equal(TipoLancamento.Credito, TipoLancamento.Credito);
        }

        [Theory]
        [InlineData(0, 123)]
        [InlineData(123, 0)]
        [InlineData(2445, 2518)]
        public void Lancar_WhenCalled_MustSumValueWithCurrentValue(double valorLancamento, double saldoAtual)
        {
            var valorEsperado = valorLancamento + saldoAtual;
            var lancamento = LancamentoCredito.Novo(valorLancamento, "teste");

            var resultado = lancamento.Lancar(saldoAtual);

            Assert.True(resultado.IsSuccess);
            Assert.Equal(valorEsperado, resultado.Value);
        }
    }
}
