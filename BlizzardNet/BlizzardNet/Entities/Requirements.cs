namespace BlizzardNet.Entities
{
    public class Requirements
    {
        public int min_character_level { get; set; }
        public int max_character_level { get; set; }
        public Faction faction { get; set; }
        public Level level { get; set; }
    }
}