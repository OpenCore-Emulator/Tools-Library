namespace BlizzardNet.Entities
{
    public class Stat
    {
        public Type type { get; set; }
        public int value { get; set; }
        public bool is_negated { get; set; }
        public Display display { get; set; }
    }
}