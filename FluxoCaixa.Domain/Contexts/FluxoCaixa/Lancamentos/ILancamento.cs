using FluentResults;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos
{
    public interface ILancamento
    {
        int Id { get; }
        double Valor { get; }
        string Descricao { get; }
        TipoLancamento Tipo { get; }
        DateTime DataHora { get; }
        Result<double> Lancar(double saldoAtual);
        void Criado(int id);
    }
}
