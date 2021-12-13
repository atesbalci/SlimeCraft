using SlimeCraft.Models.Items;

namespace SlimeCraft.Views
{
    public interface IHand
    {
        IInventoryItem GrabbedItem { get; set; }
    }
}