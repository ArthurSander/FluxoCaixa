namespace FluxoCaixa.Domain.Events.Relatorios
{
    public class RelatorioCriado : IEvent
    {
        public RelatorioCriado(int id)
        {
            Id = id;
        }

        public int Id { get; set; }
    }
}
