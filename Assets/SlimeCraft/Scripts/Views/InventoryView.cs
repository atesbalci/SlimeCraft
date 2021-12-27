using System;
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
            _hand.GrabbedItem = _inventory.PickUp(_hand.GrabbedItem, index);
            RefreshItems();
        }

        private void OnEnable()
        {
            RefreshItems();
        }

        private void RefreshItems()
        {
            for (int i = 0; i < _inventory.Slots.Length; i++)
            {
                var item = _inventory.Slots[i];
                inventorySlots[i].SetItem(item, _hand.GrabbedItem == item);
            }
        }
    }
}