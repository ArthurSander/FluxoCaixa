using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Application.Mappers.FluxoCaixa.Interfaces;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Factories.FluxoCaixa.Interfaces;

namespace FluxoCaixa.Application.Mappers.FluxoCaixa
{
    public class LancamentoApplicationMapper : ILancamentoApplicationMapper
    {
        protected readonly ILancamentoFactory _factory;

        public LancamentoApplicationMapper(ILancamentoFactory factory)
        {
            _factory = factory;
        }

        public ILancamento MapearLancamento(AdicionarLancamentoDto dto)
        {
            return _factory.Criar(dto.TipoLancamento.Value, dto.Descricao, dto.Valor.Value, dto.DataLancamento);
        }
    }
}
