using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class Damage
    {
        [JsonPropertyName("min_value")]
        public int MinValue { get; set; }
        
        [JsonPropertyName("max_value")]
        public int MaxValue { get; set; }
        
        [JsonPropertyName("display_string")]
        public string DisplayString { get; set; }
        
        [JsonPropertyName("damage_class")]
        public DamageClass DamageClass { get; set; }
    }
}