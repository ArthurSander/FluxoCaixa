using System.Text.Json.Serialization;

namespace FluxoCaixa.Presentation.API.Models.FluxoCaixa.Responses
{
    public readonly record struct LancamentoResponseModel(int id, double valor, string descricao, string tipo, string data);
}
