using SlimeCraft.Models.Items;

namespace SlimeCraft.Views
{
    public interface IItemIconView
    {
        void SetItem(IInventoryItem item, bool grabbed);
    }
}