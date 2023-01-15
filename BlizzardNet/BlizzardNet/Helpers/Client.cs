using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;
using BlizzardNet.Entities;

namespace BlizzardNet.Helpers
{
    public class Client
    {
        // Blizzard API Client ID
        public string ClientId { get; set; }
        
        // Blizzard API Client Secret
        public string ClientSecret { get; set; }
        
        // Blizzard Api Token
        public BlizzardToken Token { get; set; }
        
        // Blizzard API Region
        public string Region { get; set; }
        
        // Blizzard API Locale
        public string Locale { get; set; }
        
        // Initialize the Blizzard API Client
        public Client(string clientId, string clientSecret, string region = "us", string locale = "en_US")
        {
            ClientId = clientId;
            ClientSecret = clientSecret;
            Region = region;
            Locale = locale;
        }
        
        // Get the access token for the Blizzard API
        public async Task<BlizzardToken> GetAccessToken()
        {
            // If the token is not null, return it
            if (Token != null)
                return Token;

            using (HttpClient client = new HttpClient())
            {
                // Set the client ID and client secret
                var values = new Dictionary<string, string>
                {
                    { "client_id", ClientId },
                    { "client_secret", ClientSecret },
                    { "grant_type", "client_credentials" }
                };

                // Create the request
                var content = new FormUrlEncodedContent(values);

                // Send the request
                var response = await client.PostAsync("https://us.battle.net/oauth/token", content);
                
                // Read the response
                string responseString = await response.Content.ReadAsStringAsync();
                
                // Deserialize the response
                BlizzardToken blizzardToken = JsonSerializer.Deserialize<BlizzardToken>(responseString);
                
                // Return the token
                return blizzardToken;
            }
        }
        
        public async Task<T> Get<T>(string url, bool persistence = false) where T:class
        {
            if (Token is null)
                Token = GetAccessToken().Result;

            using (HttpClient client = new HttpClient())
            {
                // Set the authorization header
                client.DefaultRequestHeaders.Add("Authorization", $"Bearer {Token.AccessToken}");
                
                // Send the request
                var response = await client.GetAsync(url);
                
                // Read the response
                string responseString = await response.Content.ReadAsStringAsync();
                T result = JsonSerializer.Deserialize<T>(responseString);

                return result;
            }
        }
    }
}