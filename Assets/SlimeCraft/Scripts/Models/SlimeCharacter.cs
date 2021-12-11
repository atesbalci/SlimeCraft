namespace SlimeCraft.Models
{
    public class SlimeCharacter
    {
        private Inventory Inventory { get; }

        public SlimeCharacter(Inventory inventory)
        {
            Inventory = inventory;
        }
    }
}