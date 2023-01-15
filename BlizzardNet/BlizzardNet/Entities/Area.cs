using System.Text.Json.Serialization;
using BlizzardNet.Entities.BlizzardGeneric;

namespace BlizzardNet.Entities
{
    public class Area
    {
        [JsonPropertyName("key")]
        public Key Key { get; set; }
        
        [JsonPropertyName("name")]
        public string Name { get; set; }
        
        [JsonPropertyName("id")]
        public int Id { get; set; }
    }
}