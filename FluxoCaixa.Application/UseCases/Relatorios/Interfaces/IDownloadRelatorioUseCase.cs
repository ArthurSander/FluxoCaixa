using FluxoCaixa.Application.Dtos;

namespace FluxoCaixa.Application.UseCases.Relatorios.Interfaces
{
    public interface IDownloadRelatorioUseCase : IUseCase<int, FileDto>
    {
    }
}
