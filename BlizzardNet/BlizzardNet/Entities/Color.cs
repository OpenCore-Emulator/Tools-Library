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
        public float A { get; set; }

        public Tuple<int, int, int, float> Rgba() => new Tuple<int, int, int, float>(R, G, B, A);

    }
}