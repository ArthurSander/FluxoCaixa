using System.Text.Json.Serialization;

namespace FluxoCaixa.Presentation.API.Models.FluxoCaixa.Requests
{
    public class CriarCaixaRequestModel
    {
        [JsonPropertyName("nome")]
        public string? Nome { get; set; }

        [JsonPropertyName("saldo_inicial")]
        public double? SaldoInicial { get; set; }
    }
}
