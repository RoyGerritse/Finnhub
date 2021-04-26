using Finnhub.Client;

namespace Finnhub.Console
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var client = new FinnhubClient("token");
            client.CryptoCandle("BINANCE:BTCUSDT", "D");
        }
    }
}