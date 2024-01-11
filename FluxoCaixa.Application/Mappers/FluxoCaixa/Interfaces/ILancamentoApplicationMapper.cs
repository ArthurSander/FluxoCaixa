using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;

namespace FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces
{
    public interface ILancamentoApplicationMapper
    {
        ILancamento MapearLancamento(AdicionarLancamentoDto dto);
    }
}
