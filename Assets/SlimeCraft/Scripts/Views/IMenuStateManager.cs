namespace SlimeCraft.Views
{
    public interface IMenuStateManager
    {
        MenuState State { get; }
        void SetState(MenuState state);
    }
}