using SlimeCraft.Models;
using SlimeCraft.Models.Items;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Views
{
    public class InventoryView : MonoBehaviour
    {
        [SerializeField] private InventorySlotView[] inventorySlots;
        
        private Inventory _inventory;
        private IHand _hand;
        
        [Inject]
        public void Initialize(Inventory inventory, IHand hand)
        {
            _inventory = inventory;
            _hand = hand;
            for (var i = 0; i < inventorySlots.Length; i++)
            {
                var inventorySlot = inventorySlots[i];
                var index = i;
                inventorySlot.Clicked += item => ItemClicked(item, index);
            }
        }

        private void ItemClicked(IInventoryItem item, int index)
        {
            if (_hand.GrabbedItem != null)
            {
                for (int i = 0; i < _inventory.Items.Length; i++)
                {
                    if (_inventory.Items[i] == _hand.GrabbedItem)
                    {
                        _inventory.Items[i] = null;
                        break;
                    }
                }
                _inventory.Items[index] = _hand.GrabbedItem;
                _hand.GrabbedItem = null;
            }
            
            _hand.GrabbedItem = item;
            RefreshItems();
        }

        private void OnEnable()
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            for (int i = 0; i < _inventory.Items.Length; i++)
            {
                var item = _inventory.Items[i];
                inventorySlots[i].SetItem(item, _hand.GrabbedItem == item);
            }
        }
    }
}