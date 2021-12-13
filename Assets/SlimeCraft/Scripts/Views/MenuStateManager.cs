using SlimeCraft.Behaviours;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Views
{
    public class MenuStateManager : MonoBehaviour, IMenuStateManager
    {
        public MenuState State { get; private set; }

        private IPlayerInputManager _playerInputManager;

        [SerializeField] private GameObject inventoryScreenContainer;
        [SerializeField] private GameObject crosshair;

        [Inject]
        public void Initialize(IPlayerInputManager playerInputManager)
        {
            _playerInputManager = playerInputManager;
            SetState(MenuState.Regular);
        }

        public void SetState(MenuState state)
        {
            State = state;
            crosshair.SetActive(state == MenuState.Regular);
            inventoryScreenContainer.SetActive(state == MenuState.Inventory);
            _playerInputManager.CursorLock = state == MenuState.Regular;
        }
    }

    public enum MenuState
    {
        Regular,
        Inventory
    }
}