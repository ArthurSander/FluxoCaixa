namespace FluxoCaixa.Domain.Events.FluxoCaixa
{
    public class CaixaCriada : IEvent
    {
        public CaixaCriada(int caixaId)
        {
            CaixaId = caixaId;
        }

        public int CaixaId { get; }
    }
}
