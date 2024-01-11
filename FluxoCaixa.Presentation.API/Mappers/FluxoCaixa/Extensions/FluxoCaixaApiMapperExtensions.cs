using FluxoCaixa.Application.Dtos.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa;
using FluxoCaixa.Domain.Contexts.FluxoCaixa.Lancamentos;
using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using FluxoCaixa.Presentation.API.Models.FluxoCaixa.Responses;

namespace FluxoCaixa.Presentation.API.Mappers.FluxoCaixa.Extensions
{
    public static class FluxoCaixaApiMapperExtensions
    {
        private static readonly Dictionary<TipoLancamento, string> _nomesTiposLancamento = new Dictionary<TipoLancamento, string>()
        {
            { TipoLancamento.Debito, "Débito" },
            { TipoLancamento.Credito, "Crédito"},
            { TipoLancamento.Nenhum, "Inválido"}
        };

        public static CaixaResponseModel ToResponseModel(this Caixa caixa)
        {
            return new CaixaResponseModel(caixa.Id, caixa.Nome, caixa?.Lancamentos.Select(x => x.ToResponseModel()), caixa.Saldo.Valor);
        }

        public static LancamentoResponseModel ToResponseModel(this ILancamento lancamento)
        {
            return new LancamentoResponseModel(lancamento.Id, lancamento.Valor, lancamento.Descricao,
                _nomesTiposLancamento[lancamento.Tipo], lancamento.DataHora.ToString("dd-MM-yyyy HH:mm:ss"));
        }

        public static ConsultarSaldoResponseModel ToResponseModel(this ConsultarSaldoDto dto)
        {
            return new ConsultarSaldoResponseModel(dto.IdCaixa, dto.Saldo);
        }
    }
}
