using System.Collections.Generic;

namespace BlizzardNet.Entities
{
    public class Rewards
    {
        public int experience { get; set; }
        public List<Reputation> reputations { get; set; }
        public Money money { get; set; }
    }
}