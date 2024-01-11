using Microsoft.Extensions.Hosting;

namespace FluxoCaixa.Workers.MessageConsumer
{
    public class Worker : BackgroundService
    {
        private readonly CancellationTokenProvider _cancellationTokenProvider;
        public Worker(CancellationTokenProvider cancellationTokenProvider)
        {
            _cancellationTokenProvider = cancellationTokenProvider;
        }

        protected async override Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _cancellationTokenProvider.CancellationToken = stoppingToken;

            while (!stoppingToken.IsCancellationRequested)
            {
            }
        }
    }
}
