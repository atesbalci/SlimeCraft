namespace SlimeCraft.Models.Objectives
{
    public interface IObjectiveStatusListener
    {
        void CompleteObjective(IObjective objective);
    }
}