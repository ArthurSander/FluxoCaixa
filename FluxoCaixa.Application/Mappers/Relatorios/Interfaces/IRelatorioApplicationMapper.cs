using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;

namespace FluxoCaixa.Application.Mappers.Relatorios.Interfaces
{
    public interface IRelatorioApplicationMapper
    {
        Relatorio MapearNovoRelatorio(CriarRelatorioDto dto, StatusRelatorio statusInicial);
    }
}
