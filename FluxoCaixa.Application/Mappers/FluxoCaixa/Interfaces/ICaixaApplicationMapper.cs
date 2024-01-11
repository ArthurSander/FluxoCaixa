using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces
{
    public interface ICaixaApplicationMapper
    {
        Caixa MapearCaixa(CriarCaixaDto caixaDto);
        ConsultarSaldoDto MapearConsultaSaldo(Caixa caixa);
    }
}
