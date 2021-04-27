using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Finnhub.Client
{
    public class ExchangeSymbol
    {
        [JsonPropertyName("description")]        
        public string Description { get; set; } = null!;

        [JsonPropertyName("displaySymbol")]
        public string DisplaySymbol { get; set; } = null!;
        
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; } = null!;
    }
}