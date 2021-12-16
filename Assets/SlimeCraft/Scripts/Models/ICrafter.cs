using SlimeCraft.Models.Items;

namespace SlimeCraft.Models
{
    public interface ICrafter
    {
        IInventoryItem Craft(params IInventoryItem[] ingredients);
    }
}