using System;
using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class Color
    {
        [JsonPropertyName("r")]
        public int R { get; set; }
        
        [JsonPropertyName("g")]
        public int G { get; set; }
        
        [JsonPropertyName("b {")]
        public int B { get; set; }
        
        [JsonPropertyName("a")]
        public int A { get; set; }

        public Tuple<int, int, int, int> Rgba() => new Tuple<int, int, int, int>(R, G, B, A);

    }
}