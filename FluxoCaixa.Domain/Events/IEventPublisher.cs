namespace FluxoCaixa.Domain.Events
{
    public interface IEventPublisher
    {
        Task PublishAsync<T>(T eventData, CancellationToken ct = default) where T : IEvent;
    }
}
