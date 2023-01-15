using BlizzardNet.Entities.BlizzardGeneric;

namespace BlizzardNet.Entities
{
    public class Item
    {
        public Links _links { get; set; }
        public int id { get; set; }
        public string name { get; set; }
        public Quality quality { get; set; }
        public int level { get; set; }
        public int required_level { get; set; }
        public Media media { get; set; }
        public ItemClass item_class { get; set; }
        public ItemSubclass item_subclass { get; set; }
        public InventoryType inventory_type { get; set; }
        public int purchase_price { get; set; }
        public int sell_price { get; set; }
        public int max_count { get; set; }
        public bool is_equippable { get; set; }
        public bool is_stackable { get; set; }
        public PreviewItem preview_item { get; set; }
        public int purchase_quantity { get; set; }
    }
}