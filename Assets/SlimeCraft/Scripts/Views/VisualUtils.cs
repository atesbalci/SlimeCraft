using SlimeCraft.Models.Items;
using UnityEngine;

namespace SlimeCraft.Views
{
    public static class VisualUtils
    {
        public static Color ToColor(this ItemType itemType)
        {
            switch (itemType)
            {
                case ItemType.Red:
                    return Color.red;
                case ItemType.Green:
                    return Color.green;
                case ItemType.Blue:
                    return Color.blue;
                case ItemType.Yellow:
                    return Color.yellow;
                case ItemType.Cyan:
                    return Color.cyan;
                case ItemType.Purple:
                    return Color.magenta;
                default:
                    return Color.clear;
            }
        }
    }
}