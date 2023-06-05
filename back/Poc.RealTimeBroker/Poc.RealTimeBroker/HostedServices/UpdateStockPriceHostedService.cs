using Microsoft.AspNetCore.SignalR;
using Poc.RealTimeBroker.Hubs;
using Poc.RealTimeBroker.Models;

namespace Poc.RealTimeBroker.HostedServices
{
    public class UpdateStockPriceHostedService : IHostedService, IDisposable
    {
        private readonly List<string> _stocks;

        private Timer? _timer;
        public IServiceProvider _services { get; }

        public UpdateStockPriceHostedService(IServiceProvider services)
        {
            _services = services;
            _stocks = new List<string>
            {
                "ITSA4",
                "TAEE11",
                "PETR4"
            };
        }

        public void Dispose() => _timer?.Dispose();

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(UpdatePrices, null, 0, 2000);

            return Task.CompletedTask;
        }

        private void UpdatePrices(object state)
        {
            using (IServiceScope scope = _services.CreateScope())
            {
                IHubContext<BrokerHub> hubContext = scope.ServiceProvider.GetRequiredService<IHubContext<BrokerHub>>();

                foreach (var stock in _stocks)
                {
                    double stockPrice = GetRandomNumber(5, 30);
                    Console.WriteLine("Novo Preço: {0}", stockPrice);
                    hubContext.Clients.Group(stock).SendAsync("UpdatePrice", new StockPrice(stock, stockPrice));
                }
            }
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        private double GetRandomNumber(double minimum, double maximum)
        {
            Random random = new();
            return random.NextDouble() * (maximum - minimum) + minimum;
        }
    }
}