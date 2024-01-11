namespace FluxoCaixa.Domain.Contexts.SharedKernel.Tipos
{
    public enum TipoLancamento
    {
        //Caso não informado, usar 'Nenhum' como padrão para validar e parar a operação.
        Nenhum = 0,
        Debito = 1,
        Credito = 2
    }
}
