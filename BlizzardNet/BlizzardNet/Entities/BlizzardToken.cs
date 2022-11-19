using System.Text.Json.Serialization;

namespace BlizzardNet.Entities
{
    public class BlizzardToken
    {
        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; }
        
        [JsonPropertyName("token_type")]
        public string TokenType { get; set; }
        
        [JsonPropertyName("expires_in")]
        public int ExpiresIn { get; set; }
        
        [JsonPropertyName("sub")]
        public string Sub { get; set; }
    }
}