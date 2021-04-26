using System;
using System.Net;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace Finnhub.Client
{
    public class FinnhubClient
    {
        private readonly string _token;
        private const string BaseUrl = "https://finnhub.io/api/v1";

        public FinnhubClient(string token)
        {
            _token = token;
        }

        public async Task<CryptoCandles> CryptoCandle(string symbol, string resolution, long from,
            long to)
        {
            var cryptoCandles = $"{BaseUrl}/crypto/candle";
            var url = $"{cryptoCandles}?symbol={symbol}&resolution={resolution}&from={from}&to={to}&token={_token}";
            return await CallUrl<CryptoCandles>(url);
        }

        private static async Task<T> CallUrl<T>(string url) where T : new()
        {
            using var client = new HttpClient {BaseAddress = new Uri(url)};
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(
                new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));
            try
            {
                var response = await client.GetAsync(url);
                var club = await response.Content.ReadFromJsonAsync<T>();
                return club;
            }
            catch (HttpRequestException e)
            {
                if (e.Source != null)
                {
                    Console.WriteLine("HttpRequestException source: {0}", e.Source);
                }

                return new T();
            }
        }
    }
}