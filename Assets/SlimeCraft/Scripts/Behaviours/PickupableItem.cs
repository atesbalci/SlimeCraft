using SlimeCraft.Models;
using SlimeCraft.Models.Items;
using UnityEngine;

namespace SlimeCraft.Behaviours
{
    public class PickupableItem : MonoBehaviour, IInteractable
    {
        public ItemType Type;
        
        public InteractionResult Interact(ICharacter source)
        {
            if (Type == ItemType.None) return InteractionResult.Unusable;
            
            if (source.Inventory.PickUp(new InventoryItem { State = ItemState.PickedUp, Type = Type }))
            {
                gameObject.SetActive(false);
                return InteractionResult.Successful;
            }

            return InteractionResult.InventoryFull;
        }
    }
}