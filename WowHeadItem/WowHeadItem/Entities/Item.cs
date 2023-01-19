using System.Text.Json.Serialization;

namespace WowHeadItem.Entities;

public class Item
{
    [JsonPropertyName("id")]
    public int entry { get; set; }
    
    [JsonPropertyName("name")]
    public string name { get; set; }
    
    [JsonPropertyName("description")]
    public string description { get; set; }
    
    [JsonPropertyName("displayid")]
    public int displayid { get; set; }
    
    [JsonPropertyName("subclass")]
    public int subclass { get; set; }
    
    [JsonPropertyName("classs")]
    public int Class { get; set; }
    
    [JsonPropertyName("quality")]
    public int quality { get; set; }

    [JsonPropertyName("flags")]
    public int flags { get; set; }

    [JsonPropertyName("flags2")]
    public int flags2 { get; set; }
    
    [JsonPropertyName("level")]
    public int level { get; set; }
    
    [JsonPropertyName("armor")]
    public int armor { get; set; }

    [JsonPropertyName("slot")]
    public int slot { get; set; }

    [JsonPropertyName("dura")]
    public int durability { get; set; }
    
    [JsonPropertyName("int")]
    public int intelligence { get; set; }
    
    [JsonPropertyName("sellprice")]
    public int sellprice { get; set; }
    
    [JsonPropertyName("sheathtype")]
    public int sheathtype { get; set; }
    
    [JsonPropertyName("sta")]
    public int stamina { get; set; }
    
    [JsonPropertyName("str")]
    public int strenght { get; set; }
    
    [JsonPropertyName("versatility")]
    public int versatility { get; set; }
}