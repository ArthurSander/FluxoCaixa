using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;
using System.Text.Json.Serialization;

namespace FluxoCaixa.Presentation.API.Models.Relatorios.Requests
{
    public class CriarRelatorioRequestModel
    {
        [JsonPropertyName("id_caixa")]
        public int? IdCaixa { get; set; }

        [JsonPropertyName("tipo_relatorio")]
        public TipoRelatorio? TipoRelatorio { get; set; }

        [JsonPropertyName("data_relatorio")]
        public DateTime? DataRelatorio { get; set; }
    }
}
