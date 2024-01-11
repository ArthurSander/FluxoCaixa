using FluxoCaixa.Domain.Contexts.SharedKernel.Tipos;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Presentation.API.Models.FluxoCaixa.Requests
{
    public class AdicionarLancamentoRequestModel
    {
        [JsonIgnore]
        [BindNever]
        public int? IdCaixa { get; set; }

        [JsonPropertyName("descricao")]
        public string? Descricao { get; set; }

        [JsonPropertyName("valor")]
        public double? Valor { get; set; }

        // IMPLEMENTAÇÃO FUTURA
        //[JsonPropertyName("data_lancamento")] 
        //public DateTime? DataLancamento { get; set; }

        [JsonPropertyName("tipo_lancamento")]
        public TipoLancamento TipoLancamento { get; set; }
    }
}
