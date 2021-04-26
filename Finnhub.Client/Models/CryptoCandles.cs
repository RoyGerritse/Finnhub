using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Finnhub.Client
{
    public class CryptoCandles
    {
        [JsonPropertyName("c")]
        public List<double> Close { get; set; }

        [JsonPropertyName("h")] 
        public List<double> High { get; set; }

        [JsonPropertyName("l")] 
        public List<double> Low { get; set; }

        [JsonPropertyName("o")] 
        public List<double> Open { get; set; }

        [JsonPropertyName("s")] 
        public string Status { get; set; }

        [JsonPropertyName("t")] 
        public List<long> Time { get; set; }

        [JsonPropertyName("v")] 
        public List<double> Volume { get; set; }
    }
}