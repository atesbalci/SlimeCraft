namespace SlimeCraft.Models
{
    public class SlimeCharacter : ICharacter
    {
        public Inventory Inventory { get; }
        private ICrafter Crafter { get; }

        public SlimeCharacter(Inventory inventory, ICrafter crafter)
        {
            Inventory = inventory;
            Crafter = crafter;
        }
    }
}