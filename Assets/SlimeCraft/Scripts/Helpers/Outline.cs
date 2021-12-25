using UnityEngine;

namespace SlimeCraft.Helpers
{
    public class Outline : MonoBehaviour
    {
        [SerializeField] private Renderer rend;
        [SerializeField] private Material outlineMaterial;

        private bool _outlineEnabled;
        private Material _material;
        private int _materialOutlineStencilProperty;

        private void Start()
        {
            _material = Instantiate(rend.sharedMaterial);
            rend.sharedMaterial = _material;
            _materialOutlineStencilProperty = Shader.PropertyToID("_OutlineStencilWriteValue");
        }

        public void SetOutline(bool b)
        {
            if (rend)
            {
                if (!_outlineEnabled && b)
                {
                    rend.sharedMaterials = new[] { _material, outlineMaterial };
                }
                else if (_outlineEnabled && !b)
                {
                    rend.sharedMaterials = new[] { _material };
                }

                _material.SetInt(_materialOutlineStencilProperty, b ? 2 : 0);
                _outlineEnabled = b;
            }
        }
    }
}