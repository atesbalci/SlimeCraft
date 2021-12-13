using SlimeCraft.Models.Items;

namespace SlimeCraft.Models
{
    public class Inventory
    {
        public readonly IInventoryItem[] Items;

        public Inventory()
        {
            Items = new IInventoryItem[GameRules.InventorySize];
            
            // Test
            Items[0] = new InventoryItem { State = ItemState.PickedUp, Type = ItemType.Blue };
            Items[1] = new InventoryItem { State = ItemState.PickedUp, Type = ItemType.Red };
        }
    }
}