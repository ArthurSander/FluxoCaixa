using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;

namespace FluxoCaixa.Application.UseCases.Relatorios.Interfaces
{
    public interface ICriarRelatorioUseCase : IUseCase<CriarRelatorioDto, Relatorio>
    {
    }
}
