using System;
using SlimeCraft.Models.Items;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeCraft.Views
{
    public class InventorySlotView : MonoBehaviour, IItemIconView
    {
        public Action<IInventoryItem> Clicked;
        
        [SerializeField] private Image iconImage;

        private IInventoryItem _inventoryItem;
        
        public void SetItem(IInventoryItem item, bool grabbed)
        {
            iconImage.gameObject.SetActive(item != null && !grabbed);
            var color = (item?.Type ?? ItemType.None).ToColor();
            iconImage.color = color;
            _inventoryItem = item;
        }

        public void OnClick()
        {
            Clicked?.Invoke(_inventoryItem);
        }
    }
}