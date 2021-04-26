using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Finnhub.Client
{
    public class FinnhubClient : IFinnhubClient
    {
        private readonly string _token;
        private const string BaseUrl = "https://finnhub.io/api/v1";

        public FinnhubClient(string token)
        {
            _token = token;
        }

        public async Task<List<string>> CryptoExchanges()
        {
            var url = $"{BaseUrl}/crypto/exchange";
            var queryParameters = new Dictionary<string, object>
            {
                {"token", _token}
            };
            return await CallUrl<List<string>>(url, queryParameters);
        }


        public async Task<List<CryptoSymbol>> CryptoSymbol(string exchange)
        {
            var url = $"{BaseUrl}/crypto/symbol";
            var queryParameters = new Dictionary<string, object>
            {
                {"token", _token},
                {"exchange", exchange},
            };
            return await CallUrl<List<CryptoSymbol>>(url, queryParameters);
        }


        public async Task<CryptoCandles> CryptoCandle(string symbol, string resolution, long from, long to)
        {
            var url = $"{BaseUrl}/crypto/candle";
            var queryParameters = new Dictionary<string, object>
            {
                {"token", _token},
                {"symbol", symbol},
                {"resolution", resolution},
                {"from", from},
                {"to", to}
            };
            return await CallUrl<CryptoCandles>(url, queryParameters);
        }

        public static string ToJson<T>(T result)
        {
            var options = new JsonSerializerOptions {WriteIndented = true};
            return JsonSerializer.Serialize(result, options);
        }

        private static async Task<T> CallUrl<T>(string url, Dictionary<string, object> queryParameters) where T : new()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            var queryRequest = string.Join("&", queryParameters.Select((x) => x.Key + "=" + x.Value));
            try
            {
                var response = await client.GetAsync($"?{queryRequest}");
                return await response.Content.ReadFromJsonAsync<T>() ?? throw new InvalidOperationException();
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