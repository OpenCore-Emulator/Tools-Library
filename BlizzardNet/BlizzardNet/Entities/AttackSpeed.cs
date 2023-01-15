using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class AttackSpeed
    {
        [JsonPropertyName("value")]
        public int Value { get; set; }
        
        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
    }
}