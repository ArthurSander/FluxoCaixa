using FluentResults;

namespace FluxoCaixa.Application.Services.Relatorios
{
    public interface IRelatorioApplicationService
    {
        Task<Result> IniciarGeracaoRelatorioAsync(int idRelatorio, CancellationToken cancellationToken = default);
    }
}
