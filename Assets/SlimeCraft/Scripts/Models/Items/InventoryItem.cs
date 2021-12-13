namespace SlimeCraft.Models.Items
{
    public class InventoryItem : IInventoryItem
    {
        public ItemType Type { get; set; }
        public ItemState State { get; set; }
    }
}