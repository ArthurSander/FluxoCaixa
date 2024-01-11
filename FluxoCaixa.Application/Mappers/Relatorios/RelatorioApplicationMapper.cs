using FluxoCaixa.Application.Dtos.Relatorios;
using FluxoCaixa.Application.Mappers.Relatorios.Interfaces;
using FluxoCaixa.Domain.Contexts.Relatorios;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;

namespace FluxoCaixa.Application.Mappers.Relatorios
{
    public class RelatorioApplicationMapper : IRelatorioApplicationMapper
    {
        public Relatorio MapearNovoRelatorio(CriarRelatorioDto dto, StatusRelatorio statusInicial)
        {
            return new Relatorio(dto.Data.Value, dto.TipoRelatorio.Value, statusInicial);
        }
    }
}
