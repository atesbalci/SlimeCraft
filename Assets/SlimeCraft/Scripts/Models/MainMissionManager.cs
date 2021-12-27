using SlimeCraft.Models.Items;
using SlimeCraft.Models.Objectives;

namespace SlimeCraft.Models
{
    public class MainMissionManager : IMissionManager
    {
        public ObjectiveSet ObjectiveSet { get; }
        
        public MainMissionManager(SlimeCharacter slimeCharacter)
        {
            ObjectiveSet = new ObjectiveSet(
                new PickUpObjective("RedAndBlue", slimeCharacter.Inventory, ItemType.Red, ItemType.Blue),
                new PickUpObjective("Purple", slimeCharacter.Inventory, ItemType.Purple));
            ObjectiveSet.Start();
        }
    }
}