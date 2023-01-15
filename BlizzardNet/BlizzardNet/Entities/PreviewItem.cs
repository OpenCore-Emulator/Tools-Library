using System.Collections.Generic;
using BlizzardNet.Entities.BlizzardGeneric;

namespace BlizzardNet.Entities
{
    public class PreviewItem
    {
        public Item item { get; set; }
        public Quality quality { get; set; }
        public string name { get; set; }
        public Media media { get; set; }
        public ItemClass item_class { get; set; }
        public ItemSubclass item_subclass { get; set; }
        public InventoryType inventory_type { get; set; }
        public Binding binding { get; set; }
        public string unique_equipped { get; set; }
        public Weapon weapon { get; set; }
        public List<Stat> stats { get; set; }
        public List<Spell> spells { get; set; }
        public SellPrice sell_price { get; set; }
        public Requirements requirements { get; set; }
        public Level level { get; set; }
        public Durability durability { get; set; }
    }
}