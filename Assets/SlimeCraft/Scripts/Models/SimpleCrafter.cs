using System.Linq;
using SlimeCraft.Models.Items;

namespace SlimeCraft.Models
{
    public class SimpleCrafter : ICrafter
    {
        public IInventoryItem Craft(params IInventoryItem[] ingredients)
        {
            var retType = ItemType.None;
            if (ingredients.Length == 2 && ingredients.All(item => item != null))
            {
                var ingredientTypes = ingredients.Select(ing => ing.Type).ToList();
                if (ingredientTypes.Contains(ItemType.Red) && ingredientTypes.Contains(ItemType.Blue))
                {
                    retType = ItemType.Purple;
                }
                else if (ingredientTypes.Contains(ItemType.Red) && ingredientTypes.Contains(ItemType.Green))
                {
                    retType = ItemType.Yellow;
                }
                else if (ingredientTypes.Contains(ItemType.Green) && ingredientTypes.Contains(ItemType.Blue))
                {
                    retType = ItemType.Cyan;
                }
            }

            if (retType != ItemType.None)
            {
                return new InventoryItem {State = ItemState.None, Type = retType};
            }
            
            return null;
        }
    }
}