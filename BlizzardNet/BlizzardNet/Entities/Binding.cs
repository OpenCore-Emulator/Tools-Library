using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class Binding
    {
        [JsonPropertyName("type")]
        public string Type { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
    }
}