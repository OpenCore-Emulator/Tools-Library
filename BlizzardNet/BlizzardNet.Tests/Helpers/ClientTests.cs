using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlizzardNet.Entities;
using BlizzardNet.Helpers;
using NUnit.Framework;

namespace BlizzardNet.Tests.Helpers
{
    [TestFixture]
    public class ClientTests
    {
        [Test]
        [TestCase("SECRET_ID", "SECRET_PASS", "eu", "frFR")]
        public void CreateClient_IsNotNull(string clientId, string clientSecret, string region, string locale)
        {
            // Arrange
            
            // Act
            var client = new Client(clientId, clientSecret, region, locale);

            // Assert
            Assert.IsNotNull(client);
        }
        
        [Test]
        [TestCase("SECRET_ID", "SECRET_PASS", "eu", "frFR")]
        public async Task GenerateBlizzardToken_IsNotNull(string clientId, string clientSecret, string region, string locale)
        {
            // Arrange
            var client = new Client(clientId, clientSecret, region, locale);
            
            // Act
            var token = client.Token = await client.GetAccessToken();
            
            // Assert
            Assert.IsNotNull(token);
        }
        
        [Test]
        [TestCase("SECRET_ID", "SECRET_PASS", "eu", "ru_RU")]
        public async Task GetAllQuestArea(string clientId, string clientSecret, string region, string locale)
        {
            // Arrange
            var client = new Client(clientId, clientSecret, region, locale);
            
            // Act
            Link.Locale = locale;
            Link.Region = region;
            
            QuestAreasIndex questArea = await client.Get<QuestAreasIndex>(Link.QuestAreasIndex());
            
            // Assert
            Assert.IsNotNull(questArea);
        }
        
        [Test]
        [TestCase("SECRET_ID", "SECRET_PASS", "eu", "fr_FR")]
        public async Task GetAllQuestDataInArea(string clientId, string clientSecret, string region, string locale)
        {
            // Arrange
            var client = new Client(clientId, clientSecret, region, locale);
            
            // Act
            Link.Locale = locale;
            Link.Region = region;
            
            QuestAreasIndex questArea = await client.Get<QuestAreasIndex>(Link.QuestAreasIndex());
            
            List<QuestArea> quests = questArea.areas.Select(areas => client.Get<QuestArea>(Link.QuestArea(areas.Id)).Result).ToList();
            
            // Assert
            Assert.IsNotNull(quests);
        }
        
        [Test]
        [TestCase("SECRET_ID", "SECRET_PASS", "eu", "fr_FR", 39)]
        public async Task GetItem(string clientId, string clientSecret, string region, string locale, int itemId)
        {
            // Arrange
            var client = new Client(clientId, clientSecret, region, locale);
            
            // Act
            Link.Locale = locale;
            Link.Region = region;
            
            Item item = await client.Get<Item>(Link.Item(itemId));
            
            // Assert
            Assert.IsNotNull(item);
        }
    }
}