using SlimeCraft.Behaviours;
using SlimeCraft.Helpers;
using UnityEngine;

namespace SlimeCraft.Views
{
    [RequireComponent(typeof(Outline))]
    public class OutlineHighlight : MonoBehaviour, IHighlightable
    {
        private Outline _outline;

        private void Start()
        {
            _outline = GetComponent<Outline>();
        }

        public void SetHighlight(bool active)
        {
            _outline.SetOutline(active);
        }
    }
}