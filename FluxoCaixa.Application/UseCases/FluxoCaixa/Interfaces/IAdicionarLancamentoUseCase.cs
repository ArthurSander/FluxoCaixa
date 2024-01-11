using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.Application.UseCases.FluxoCaixa.Interfaces
{
    public interface IAdicionarLancamentoUseCase : IUseCase<AdicionarLancamentoDto, Caixa>
    {
    }
}
