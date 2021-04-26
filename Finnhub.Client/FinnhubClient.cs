using System;

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

        public void CryptoCandle(string symbol, string resolution, long? @from = null, long? to = null)
        {
            var url = $"{BaseUrl}/crypto/candle?symbol={symbol}&resolution={resolution}&from={from}&to={to}&token={_token}";
        }
    }
}