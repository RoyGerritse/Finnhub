using System.Collections.Generic;
using System.Threading.Tasks;

namespace Finnhub.Client
{
    public interface IFinnhubClient
    {
        Task<List<string>> CryptoExchanges();
        Task<List<ExchangeSymbol>> CryptoSymbol(string exchange);
        Task<CryptoCandles> CryptoCandle(string symbol, string resolution, long from, long to);
    }
}