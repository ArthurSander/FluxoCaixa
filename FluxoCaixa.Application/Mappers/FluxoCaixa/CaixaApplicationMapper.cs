using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;

namespace FluxoCaixa.Application.Mappers.FluxoCaixa
{
    public class CaixaApplicationMapper : ICaixaApplicationMapper
    {
        public Caixa MapearCaixa(CriarCaixaDto caixaDto)
            => new Caixa(caixaDto.Nome);

        public ConsultarSaldoDto MapearConsultaSaldo(Caixa caixa)
        {
            return new ConsultarSaldoDto()
            {
                IdCaixa = caixa.Id,
                Saldo = caixa.Saldo.Valor
            };
        }
    }
}
