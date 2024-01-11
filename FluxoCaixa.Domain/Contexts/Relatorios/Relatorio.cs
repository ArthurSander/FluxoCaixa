using FluxoCaixa.Domain.Contexts.Relatorios.Caixas;
using FluxoCaixa.Domain.Contexts.Relatorios.Tipos;
using FluxoCaixa.Shared.Extensions;
using Newtonsoft.Json;

namespace FluxoCaixa.Domain.Contexts.Relatorios
{
    public class Relatorio
    {
        public Relatorio(DateOnly data, TipoRelatorio tipo, StatusRelatorio status)
        {
            Data = data;
            Tipo = tipo;
            Status = status;
        }

        public Relatorio(int id, DateOnly data, TipoRelatorio tipo, StatusRelatorio status, string caminhoArquivo = null, Caixa caixa = null)
        {
            Id = id;
            Data = data;
            Tipo = tipo;
            Status = status;
            CaminhoArquivo = caminhoArquivo;
            Caixa = caixa;
        }

        [JsonIgnore]
        public int Id { get; protected set; }
        public DateOnly Data { get; protected set; }
        public Caixa Caixa { get; protected set; }
        public TipoRelatorio Tipo { get; protected set; }
        // Melhoria: Implementar state pattern
        [JsonIgnore]
        public StatusRelatorio Status { get; protected set; }

        [JsonIgnore]
        public string CaminhoArquivo { get; protected set; }

        [JsonIgnore]
        public string NomeArquivo
            => $"{Caixa.Id}-{Data.ToString("yyyy-MM-dd")}";

        public void IniciarProcessamento()
        {
            if (!Caixa.Id.IsGreaterThanZero())
                throw new ArgumentException("Caixa informada não contém Id.");

            Status = StatusRelatorio.Processando;
        }

        public void FinalizarProcessamento(string caminhoArquivo)
        {
            Status = StatusRelatorio.Criado;
            CaminhoArquivo = caminhoArquivo;
        }

        public void InterromperProcessamento()
        {
            Status = StatusRelatorio.Interrompido;
        }

        public void ApontarErroProcessamento()
        {
            Status = StatusRelatorio.Erro;
        }
    }
}
