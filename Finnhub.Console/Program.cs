using System;
using Finnhub.Client;

namespace Finnhub.Console
{
    public class Program
    {
        private static EnvironmentSettings EnvironmentSettings { get; set; }

        public static void Main()
        {
            EnvironmentSettings = new EnvironmentSettings();

            var client = new FinnhubClient(EnvironmentSettings.Token);
            client.CryptoCandle("BINANCE:BTCUSDT", "D", 1572651390, 1575243390);
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