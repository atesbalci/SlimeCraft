using SlimeCraft.Models.Items;

namespace SlimeCraft.Models
{
    public class Inventory
    {
        public readonly IInventoryItem[] Items;

        public Inventory()
        {
            Items = new IInventoryItem[GameRules.InventorySize];
        }
    }
}