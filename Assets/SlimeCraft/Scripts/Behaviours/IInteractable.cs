using SlimeCraft.Models;

namespace SlimeCraft.Behaviours
{
    public interface IInteractable
    {
        InteractionResult Interact(ICharacter source);
    }

    public enum InteractionResult
    {
        Successful,
        InventoryFull,
        Unusable
    }
}