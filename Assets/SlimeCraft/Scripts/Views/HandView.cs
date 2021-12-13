using System;
using SlimeCraft.Models.Items;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace SlimeCraft.Views
{
    public class HandView : MonoBehaviour, IHand
    {
        [SerializeField] private Image icon;
        
        private IInventoryItem _grabbedItem;
        private RectTransform _canvas;

        public IInventoryItem GrabbedItem
        {
            get => _grabbedItem;
            set
            {
                _grabbedItem = value;
                gameObject.SetActive(value != null);
                icon.color = value?.Type.ToColor() ?? Color.clear;
            }
        }

        private void Awake()
        {
            _canvas = (RectTransform) GetComponentInParent<Canvas>().transform;
        }

        private void OnDisable()
        {
            GrabbedItem = null;
        }

        private void Update()
        {
            var canvasSize = _canvas.sizeDelta;
            var pos = Mouse.current.position.ReadValue();
            pos.x *= canvasSize.x / Screen.width;
            pos.y *= canvasSize.y / Screen.height;
            ((RectTransform) transform).anchoredPosition = pos;
        }
    }
}