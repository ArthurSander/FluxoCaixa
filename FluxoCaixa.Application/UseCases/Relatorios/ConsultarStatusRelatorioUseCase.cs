using FluentResults;
using FluxoCaixa.Application.UseCases.Relatorios.Interfaces;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Repositories.Relatorios;
using Serilog;

namespace FluxoCaixa.Application.UseCases.Relatorios
{
    public class ConsultarStatusRelatorioUseCase : IConsultarStatusRelatorioUseCase
    {
        private readonly IRelatorioReadRepository _repository;

        public ConsultarStatusRelatorioUseCase(IRelatorioReadRepository repository)
        {
            _repository = repository;
        }

        public async Task<Result<Relatorio>> ExecutarAsync(int input, CancellationToken ct = default)
        {
            return await _repository.BuscarRelatorioAsync(input, ct);
        }
    }
}
