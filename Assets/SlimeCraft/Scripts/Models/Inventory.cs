using System;
using System.Collections.Generic;
using System.Linq;
using SlimeCraft.Models.Items;

namespace SlimeCraft.Models
{
    public class Inventory
    {
        public event Action<IInventoryItem> ItemPickedUp; 
        public readonly IInventoryItem[] Slots;

        public Inventory()
        {
            Slots = new IInventoryItem[GameRules.InventorySize];
        }

        public bool PickUp(IInventoryItem item)
        {
            if (item == null) return true;
            for (int i = 0; i < Slots.Length; i++)
            {
                if (Slots[i] == null)
                {
                    Slots[i] = item;
                    ItemPickedUp?.Invoke(item);
                    return true;
                }
            }

            return false;
        }
        
        public IInventoryItem PickUp(IInventoryItem item, int index)
        {
            IInventoryItem retVal = Slots[index];
            Slots[index] = item;
            if (item != null) ItemPickedUp?.Invoke(item);
            return retVal;
        }

        public IEnumerable<IInventoryItem> Items => Slots.Where(slot => slot != null);
    }
}