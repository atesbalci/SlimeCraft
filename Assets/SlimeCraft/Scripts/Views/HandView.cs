using System;
using SlimeCraft.Models;
using SlimeCraft.Models.Items;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Zenject;

namespace SlimeCraft.Views
{
    public class HandView : MonoBehaviour, IHand
    {
        [SerializeField] private Image icon;

        private Inventory _inventory;
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

        [Inject]
        public void Initialize(Inventory inventory)
        {
            _inventory = inventory;
            _canvas = (RectTransform) GetComponentInParent<Canvas>().transform;
            GrabbedItem = null;
        }

        private void OnDisable()
        {
            if (GrabbedItem != null)
            {
                _inventory.PickUp(GrabbedItem);
                GrabbedItem = null;
            }
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