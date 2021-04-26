using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Finnhub.Client
{
    public class Stock
    {
        [JsonPropertyName("currency")]        
        public string Currency { get; set; } = null!;

        [JsonPropertyName("description")]  
        public string Description { get; set; } = null!;
        
        [JsonPropertyName("displaySymbol")]  
        public string DisplaySymbol { get; set; } = null!;
        
        [JsonPropertyName("figi")]  
        public string Figi { get; set; } = null!;
        
        [JsonPropertyName("mic")]  
        public string Mic { get; set; } = null!;
        
        [JsonPropertyName("symbol")]  
        public string Symbol { get; set; } = null!;
        
        [JsonPropertyName("type")]  
        public string Type { get; set; } = null!;
    }
}