namespace SlimeCraft.Models.Items
{
    public interface IInventoryItem
    {
        ItemType Type { get; }
        ItemState State { get; set; }
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