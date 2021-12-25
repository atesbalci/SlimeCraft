using SlimeCraft.Models;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Behaviours
{
    public class InteractionBehaviour : MonoBehaviour
    {
        [SerializeField] private float interactionDistance;
        [SerializeField] private LayerMask layerMask;
        
        private SlimeCharacter _character;
        private Transform _camera;
        
        public IInteractable CurrentInteractable { get; private set; }
        public IHighlightable CurrentHighlightable { get; private set; }

        [Inject]
        public void Initialize(SlimeCharacter character)
        {
            _character = character;
        }

        private void Start()
        {
            _camera = Camera.main.transform;
        }

        private void Update()
        {
            if (Physics.Raycast(new Ray(_camera.position, _camera.forward), out var hit, 100, layerMask) &&
                (hit.transform.position - transform.position).sqrMagnitude < (interactionDistance * interactionDistance))
            {
                CurrentInteractable = hit.collider.GetComponent<IInteractable>();
                CurrentHighlightable = hit.collider.GetComponent<IHighlightable>();
                CurrentHighlightable?.SetHighlight(true);
            }
            else
            {
                CurrentInteractable = null;
                CurrentHighlightable?.SetHighlight(false);
                CurrentHighlightable = null;
            }
        }

        public void Interact()
        {
            if (CurrentInteractable != null)
            {
                CurrentInteractable.Interact(_character);
                CurrentInteractable = null;
                CurrentHighlightable?.SetHighlight(false);
                CurrentHighlightable = null;
            }
        }
    }
}