using System.Text.Json.Serialization;

namespace FluxoCaixa.Presentation.API.Models.FluxoCaixa.Responses
{
    public readonly record struct CaixaResponseModel(int id, string nome, IEnumerable<LancamentoResponseModel> lancamentos, double saldo_atual);
}
