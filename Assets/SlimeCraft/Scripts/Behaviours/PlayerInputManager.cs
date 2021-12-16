using StarterAssets;
using UnityEngine;
using UnityEngine.InputSystem;

namespace SlimeCraft.Behaviours
{
    public class PlayerInputManager : MonoBehaviour, IPlayerInputManager
    {
        [SerializeField] private StarterAssetsInputs starterInputs;
        
        private bool _cursorLock = true;

        public bool CursorLock
        {
            get => _cursorLock;
            set
            {
                _cursorLock = value;
                starterInputs.cursorLocked = value;
                Cursor.lockState = value ? CursorLockMode.Locked : CursorLockMode.None;
            }
        }

        public void OnPlayerInput(InputAction.CallbackContext context)
        {
            switch (context.action.name)
            {
                case "Move":
                    starterInputs.MoveInput(context.ReadValue<Vector2>());
                    break;
                case "Look":
                    if (CursorLock)
                    {
                        starterInputs.LookInput(context.ReadValue<Vector2>());
                    }
                    break;
                case "Jump":
                    starterInputs.JumpInput(context.action.triggered);
                    break;
            }
        }
    }
}