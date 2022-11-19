using BlizzardNet.Entities.BlizzardGeneric;

namespace BlizzardNet.Entities
{
    public class Quest
    {
        public Links _links { get; set; }
        public int id { get; set; }
        
        public string title { get; set; }
        public string name { get; set; }
        
        public Area area { get; set; }
        public string description { get; set; }
        public Requirements requirements { get; set; }
        public Rewards rewards { get; set; }
    }
}