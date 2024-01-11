namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Eventos
{
    public readonly record struct NovoLancamento(double SaldoAnterior, double SaldoAtual, int CaixaId, int LancamentoId);
}
