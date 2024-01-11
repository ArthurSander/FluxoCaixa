namespace FluxoCaixa.Domain.Events.Relatorios
{
    public class RelatorioProcesado : IEvent
    {
        public RelatorioProcesado(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
