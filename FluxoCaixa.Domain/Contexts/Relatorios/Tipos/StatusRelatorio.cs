namespace FluxoCaixa.Domain.Contexts.Relatorios.Tipos
{
    public enum StatusRelatorio
    {
        NaFila = 1,
        Processando = 2,
        Criado = 3,
        Erro = 100,
        Interrompido = 101
    }
}
