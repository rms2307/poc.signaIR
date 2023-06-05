using Microsoft.AspNetCore.SignalR;

namespace Poc.RealTimeBroker.Hubs
{
    public class BrokerHub : Hub
    {
        public async Task ConnectToStock(string symbol)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, symbol);
        }
    }
}
