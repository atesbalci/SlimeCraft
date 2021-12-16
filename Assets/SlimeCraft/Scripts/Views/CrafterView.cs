using System;
using SlimeCraft.Models;
using SlimeCraft.Models.Items;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Views
{
    public class CrafterView : MonoBehaviour
    {
        [SerializeField] private InventorySlotView[] inputFields;
        [SerializeField] private InventorySlotView outputField;

        private IInventoryItem[] _currentInputItems;

        private ICrafter _crafter;
        private IHand _hand;
        private Inventory _inventory;

        [Inject]
        public void Initialize(ICrafter crafter, IHand hand, Inventory inventory)
        {
            _crafter = crafter;
            _hand = hand;
            _inventory = inventory;
            
            _currentInputItems = new IInventoryItem[inputFields.Length];
            for (var i = 0; i < inputFields.Length; i++)
            {
                var index = i;
                inputFields[i].Clicked += item => InputClicked(item, index);
            }
            
            outputField.Clicked += OutputClicked;
        }

        private void OnEnable()
        {
            ClearInputs();
        }

        private void InputClicked(IInventoryItem item, int index)
        {
            _currentInputItems[index] = null;
            if (_hand.GrabbedItem != null)
            {
                _currentInputItems[index] = _hand.GrabbedItem;
                _hand.GrabbedItem = null;
            }

            _hand.GrabbedItem = null;
            Refresh();
        }

        private void OutputClicked(IInventoryItem item)
        {
            if (_hand.GrabbedItem == null)
            {
                item.State = ItemState.PickedUp;
                _hand.GrabbedItem = item;
                ClearInputs();
            }
        }

        private void Refresh()
        {
            for (int i = 0; i < _currentInputItems.Length; i++)
            {
                inputFields[i].SetItem(_currentInputItems[i], false);
            }
            
            outputField.SetItem(_crafter.Craft(_currentInputItems), false);
        }

        private void ClearInputs()
        {
            for (int i = 0; i < _currentInputItems.Length; i++)
            {
                _currentInputItems[i] = null;
            }
            
            Refresh();
        }

        private void OnDisable()
        {
            foreach (var item in _currentInputItems)
            {
                _inventory.PickUp(item);
            }
        }
    }
}