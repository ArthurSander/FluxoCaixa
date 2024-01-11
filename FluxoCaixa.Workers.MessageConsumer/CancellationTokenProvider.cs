using FluxoCaixa.Infrastructure.Generic.Process;

namespace FluxoCaixa.Workers.MessageConsumer
{
    public class CancellationTokenProvider : ICancellationTokenProvider
    {
        public CancellationToken CancellationToken { get; set; } = default;
    }
}
