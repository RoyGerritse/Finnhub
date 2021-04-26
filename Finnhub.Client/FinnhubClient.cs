using System;
using System.Text.Json.Serialization;

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

        public void CryptoCandle(string symbol, string resolution, long? from = null, long? to = null)
        {
            if (from == null && to == null)
            {
                var currentEpoch = DateTimeOffset.Now.ToUnixTimeSeconds();
                to = currentEpoch;
            }

            var url =
                $"{BaseUrl}/crypto/candle?symbol={symbol}&resolution={resolution}&from={from}&to={to}&token={_token}";
        }
    }

    public class CryptoCandles
    {
        [JsonPropertyName("c")]
        public double[] Close { get; set; }
        
        [JsonPropertyName("h")]
        public double[] High { get; set; }
        
        [JsonPropertyName("l")]
        public double[] Low { get; set; }
        
        [JsonPropertyName("s")]
        public string Status { get; set; }
        
        [JsonPropertyName("time")]
        public long[] Time { get; set; }
        
        [JsonPropertyName("v")]
        public long[] Volume { get; set; }
        
    }
}