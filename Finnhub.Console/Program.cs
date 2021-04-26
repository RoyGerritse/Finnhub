using System;
using System.Threading.Tasks;
using Finnhub.Client;

namespace Finnhub.Console
{
    public class Program
    {
        private static EnvironmentSettings EnvironmentSettings { get; set; } = null!;

        public static async Task Main()
        {
            EnvironmentSettings = new EnvironmentSettings();
            var client = new FinnhubClient(EnvironmentSettings.Token);
            var exchanges = await client.CryptoExchanges();
            System.Console.WriteLine("CRYPTO EXCHANGES:");
            System.Console.WriteLine("============");
            foreach (var exchange in exchanges)
            {
                System.Console.WriteLine($"=> {exchange}");
                var exchangeSymbols = await client.CryptoSymbol(exchange);
                foreach (var exchangeSymbol in exchangeSymbols)
                {
                    System.Console.WriteLine(
                        $"==> {exchangeSymbol.Symbol}, {exchangeSymbol.DisplaySymbol}, {exchangeSymbol.Description}");
                }
            }
            
            
            var forexExchanges = await client.ForexExchanges();
            System.Console.WriteLine("FOREX EXCHANGES:");
            System.Console.WriteLine("============");
            foreach (var exchange in forexExchanges)
            {
                System.Console.WriteLine($"=> {exchange}");
                var exchangeSymbols = await client.ForexSymbol(exchange);
                foreach (var exchangeSymbol in exchangeSymbols)
                {
                    System.Console.WriteLine($"==> {exchangeSymbol.Symbol}, {exchangeSymbol.DisplaySymbol}, {exchangeSymbol.Description}");
                }
            }
        }
    }

    public class EnvironmentSettings
    {
        private const string FinnhubToken = "FINNHUB_TOKEN";

        public EnvironmentSettings()
        {
            var token = Environment.GetEnvironmentVariable(FinnhubToken);
            if (token != null)
            {
                Token = token;
            }
            else
            {
                throw new InvalidOperationException("environment token is null");
            }
        }

        public string Token { get; }
    }
}