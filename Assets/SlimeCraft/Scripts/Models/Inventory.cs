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

        public bool PickUp(IInventoryItem item)
        {
            for (int i = 0; i < Items.Length; i++)
            {
                if (Items[i] == null)
                {
                    Items[i] = item;
                    return true;
                }
            }

            return false;
        }
    }
}