using System.Text.Json.Serialization;

namespace WowHeadItem.Entities;

public class Data
{
    [JsonPropertyName("insert")]
    public List<int> Insert { get; set; } = null!;

    [JsonPropertyName("update")]
    public List<int> Update { get; set; } = null!;
}