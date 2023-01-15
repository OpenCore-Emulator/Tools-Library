using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class Display
    {
        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
        
        [JsonPropertyName("color")]
        public Color Color { get; set; }
    }
}