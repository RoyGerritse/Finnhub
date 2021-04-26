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
        
        public async Task<List<string>> ForexExchanges()
        {
            var url = $"{BaseUrl}/forex/exchange";
            return await CallUrl<List<string>>(url);
        }

        public async Task<List<ExchangeSymbol>> ForexSymbol(string exchange)
        {
            var url = $"{BaseUrl}/forex/symbol";
            var queryParameters = new Dictionary<string, object>
            {
                {"exchange", exchange},
            };
            return await CallUrl<List<ExchangeSymbol>>(url, queryParameters);
        }
        
        public async Task<List<string>> CryptoExchanges()
        {
            var url = $"{BaseUrl}/crypto/exchange";
            return await CallUrl<List<string>>(url);
        }

        public async Task<List<ExchangeSymbol>> CryptoSymbol(string exchange)
        {
            var url = $"{BaseUrl}/crypto/symbol";
            var queryParameters = new Dictionary<string, object>
            {
                {"exchange", exchange},
            };
            return await CallUrl<List<ExchangeSymbol>>(url, queryParameters);
        }

        public async Task<CryptoCandles> CryptoCandle(string symbol, string resolution, long from, long to)
        {
            var url = $"{BaseUrl}/crypto/candle";
            var queryParameters = new Dictionary<string, object>
            {
                {"symbol", symbol},
                {"resolution", resolution},
                {"from", from},
                {"to", to}
            };
            return await CallUrl<CryptoCandles>(url, queryParameters);
        }

        // public static string ToJson<T>(T result)
        // {
        //     var options = new JsonSerializerOptions {WriteIndented = true};
        //     return JsonSerializer.Serialize(result, options);
        // }

        private async Task<T> CallUrl<T>(string url, Dictionary<string, object>? queryParameters = null) where T : new()
        {
            using var client = new HttpClient
            {
                BaseAddress = new Uri(url)
            };
            var mediaType = new MediaTypeWithQualityHeaderValue("application/json");
            client.DefaultRequestHeaders.Add("X-Finnhub-Token", _token);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(mediaType);
            try
            {
                HttpResponseMessage response;
                if (queryParameters != null)
                {
                    var queryRequest = string.Join("&", queryParameters.Select((x) => x.Key + "=" + x.Value));
                    response = await client.GetAsync($"?{queryRequest}");
                }
                else
                {
                    response = await client.GetAsync("");
                }

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