using UnityEngine;
using Zenject;

namespace SlimeCraft.Views
{
    public class MenuInputManager : MonoBehaviour
    {
        private IMenuStateManager _menuStateManager;
        
        [Inject]
        public void Initialize(IMenuStateManager menuStateManager)
        {
            _menuStateManager = menuStateManager;
        }
        
        public void ToggleInventory()
        {
            _menuStateManager.SetState(_menuStateManager.State == MenuState.Regular
                ? MenuState.Inventory
                : MenuState.Regular);
        }
    }
}