using System;
using System.Text.Json;
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
            var result = await client.CryptoCandle("KRAKEN:TBTCEUR", "D", 1572651390, 1575243390);
            System.Console.WriteLine(JsonSerializer.Serialize(result,
                new JsonSerializerOptions {WriteIndented = true}));
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