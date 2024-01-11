using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;

namespace FluxoCaixa.Application.Dtos.FluxoCaixa
{
    public class AdicionarLancamentoDto
    {
        public int? IdCaixa { get; set; }
        public double? Valor { get; set; }
        public string? Descricao { get; set; }
        public TipoLancamento? TipoLancamento { get; set; }
        public DateTime? DataLancamento { get; set; }
    }
}
