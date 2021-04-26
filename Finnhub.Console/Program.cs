using System;
using System.Threading.Tasks;
using Finnhub.Client;

namespace Finnhub.Console
{
    public class Program
    {
        private static EnvironmentSettings EnvironmentSettings { get; set; }

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
            }

            // var result = await client.CryptoCandle("KRAKEN:TBTCEUR", "D", 1572651390, 1575243390);
            // System.Console.WriteLine(FinnhubClient.ToJson(result));
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
        }

        public string Token { get; }
    }
}