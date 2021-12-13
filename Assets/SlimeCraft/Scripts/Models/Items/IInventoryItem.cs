namespace SlimeCraft.Models.Items
{
    public interface IInventoryItem
    {
        ItemType Type { get; }
        ItemState State { get; }
    }

    public enum ItemType
    {
         None,
         Red,
         Green,
         Blue,
         Yellow,
         Cyan,
         Purple
    }

    public enum ItemState
    {
        None,
        PickedUp
    }
}