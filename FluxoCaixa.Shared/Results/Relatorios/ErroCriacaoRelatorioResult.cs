using FluentResults;

namespace FluxoCaixa.Shared.Results.Relatorios
{
    public class ErroCriacaoRelatorioResult : BaseErrorResult
    {
        public ErroCriacaoRelatorioResult(string message) : base(message)
        {
        }

        public ErroCriacaoRelatorioResult(string message, IError causedBy) : base(message, causedBy)
        {
        }
    }
}
