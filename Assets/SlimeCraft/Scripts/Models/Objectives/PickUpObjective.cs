using System.Collections.Generic;
using SlimeCraft.Models.Items;

namespace SlimeCraft.Models.Objectives
{
    public class PickUpObjective : IObjective
    {
        public string Id { get; }
        
        private readonly ICollection<ItemType> _items;
        private readonly Inventory _inventory;
        
        private IObjectiveStatusListener _listener;

        public PickUpObjective(string id, Inventory inventory, params ItemType[] items)
        {
            Id = id;
            _inventory = inventory;
            _items = new LinkedList<ItemType>();
            foreach (var item in items)
            {
                _items.Add(item);
            }
        }

        public void Activate()
        {
            _inventory.ItemPickedUp += OnItemPickedUp;
            foreach (var item in _inventory.Items)
            {
                _items.Remove(item.Type);
            }
            
            CheckCompletion();
        }

        private void OnItemPickedUp(IInventoryItem item)
        {
            if (_items.Remove(item.Type))
            {
                CheckCompletion();
            }
        }

        private void CheckCompletion()
        {
            if (Completed)
            {
                _listener?.CompleteObjective(this);
                _inventory.ItemPickedUp -= OnItemPickedUp;
            }
        }

        public void Dispose()
        {
            _inventory.ItemPickedUp -= OnItemPickedUp;
        }

        public void SetListener(IObjectiveStatusListener statusListener)
        {
            _listener = statusListener;
        }

        public bool Completed => _items.Count <= 0;
    }
}