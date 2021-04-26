﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Threading.Tasks;

namespace Finnhub.Client
{
    public class FinnhubClient
    {
        private readonly string _token;
        private const string BaseUrl = "https://finnhub.io/api/v1";
        private readonly string _cryptoExchangesUrl = $"{BaseUrl}/crypto/exchange";
        private readonly string _cryptoCandlesUrl = $"{BaseUrl}/crypto/candle";

        public FinnhubClient(string token)
        {
            _token = token;
        }

        public async Task<CryptoCandles> CryptoCandle(string symbol, string resolution, long from, long to)
        {
            var queryParameters = new Dictionary<string, object>
            {
                {"symbol", symbol},
                {"resolution", resolution},
                {"from", from},
                {"to", to},
                {"token", _token}
            };
            return await CallUrl<CryptoCandles>(_cryptoCandlesUrl, queryParameters);
        }

        public async Task<List<string>> CryptoExchanges()
        {
            var queryParameters = new Dictionary<string, object>
            {
                {"token", _token}
            };
            return await CallUrl<List<string>>(_cryptoExchangesUrl, queryParameters);
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
                return await response.Content.ReadFromJsonAsync<T>();
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