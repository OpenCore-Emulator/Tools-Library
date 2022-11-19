using System.Collections.Generic;
using BlizzardNet.Entities.BlizzardGeneric;

namespace BlizzardNet.Entities
{
    public class QuestArea
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string area { get; set; }
        public List<Quest> quests { get; set; }
    }
}