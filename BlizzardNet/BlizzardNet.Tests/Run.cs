using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlizzardNet.Entities;
using BlizzardNet.Helpers;
using NUnit.Framework;

namespace BlizzardNet.Tests
{
    public static class Run
    {
        public static async Task Main(string[] args)
        {
            // Arrange
            var client = new Client("8157ed6b1b664e7b8fea101c82faa73b", "JNdAhhWI4vXm8hUsR2EgDGJ8glrvHzMU", "eu", "fr_FR");
            
            // Act
            Link.Locale = "fr_FR";
            Link.Region = "eu";
            
            QuestAreasIndex questArea = await client.Get<QuestAreasIndex>(Link.QuestAreasIndex());
            List<QuestArea> questDataFormArea = questArea.areas.Select(areas => client.Get<QuestArea>(Link.QuestArea(areas.id)).Result).ToList();

            List<Quest> quests = questDataFormArea.SelectMany(qa => qa.quests.Select(quest => client.Get<Quest>(Link.Quest(quest.id)).Result)).ToList();
            
            // Assert
            Assert.IsNotNull(quests);
        }
    }
}