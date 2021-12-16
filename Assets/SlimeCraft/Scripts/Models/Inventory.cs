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

        public void PickUp(IInventoryItem item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    break;
                }
            }
        }
    }
}