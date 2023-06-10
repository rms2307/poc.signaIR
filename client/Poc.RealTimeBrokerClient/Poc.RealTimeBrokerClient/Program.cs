using Microsoft.AspNetCore.SignalR.Client;
using Poc.RealTimeBrokerClient;

const string url = "https://localhost:7100/brokerhub";

await using var connection = new HubConnectionBuilder()
    .WithUrl(url)
    .Build();

connection.On<StockPrice>("UpdatePrices", (stockPrice) =>
{
    Console.WriteLine($"Symbol: {stockPrice.Symbol} => Price:  {stockPrice.Price}");
});

await connection.StartAsync();

List<string> stocks = new() { "ITSA4", };
foreach (var stock in stocks)
{
    await connection.InvokeAsync("ConnectToStock", stock);
}

Console.ReadLine();