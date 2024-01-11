using FluxoCaixa.Domain.Events;
using FluxoCaixa.Domain.Events.Relatorios;
using FluxoCaixa.Shared.Logs;
using MassTransit;
using Serilog;

namespace FluxoCaixa.Infrastructure.Generic.Publishers
{
    public class EventPublisher : IEventPublisher
    {
        //evitar overload de mensagens sem consumidores
        protected readonly List<Type> _allowedMessageTypes = new List<Type>
        { 
            typeof(RelatorioCriado) 
        };

        protected readonly ILogger _logger;
        protected readonly IBus _bus;

        public EventPublisher(ILogger logger, IBus bus)
        {
            _logger = logger;
            _bus = bus;
        }

        public async Task PublishAsync<T>(T eventData, CancellationToken ct = default) where T : IEvent
        {
            if (!_allowedMessageTypes.Contains(typeof(T)))
                return;

            _logger.Information($"Publicando mensagem na fila. Tipo Mensagem: {LogVariables.TipoMensagem}", typeof(T).Name);

            await _bus.Publish(eventData, ct);
        }
    }
}
