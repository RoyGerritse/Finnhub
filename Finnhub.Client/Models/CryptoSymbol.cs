using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Finnhub.Client
{
    public class CryptoSymbol
    {
        [JsonPropertyName("description")]        
        public string Description { get; set; }
        
        [JsonPropertyName("displaySymbol")]
        public string DisplaySymbol { get; set; }
        
        [JsonPropertyName("symbol")]
        public string Symbol { get; set; }
    }
}