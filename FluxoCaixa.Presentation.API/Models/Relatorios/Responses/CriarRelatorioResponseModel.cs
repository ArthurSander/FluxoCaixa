using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;

namespace FluxoCaixa.Presentation.API.Models.Relatorios.Responses
{
    public readonly record struct CriarRelatorioResponseModel(int id, StatusRelatorio status);
}
