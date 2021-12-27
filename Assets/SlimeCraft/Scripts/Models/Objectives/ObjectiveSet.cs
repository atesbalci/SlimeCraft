using System;
using System.Collections.Generic;

namespace SlimeCraft.Models.Objectives
{
    public class ObjectiveSet : IObjectiveStatusListener
    {
        public event Action<IObjective> ObjectiveCompleted; 

        public readonly IList<IObjective> Objectives;
        public int CurrentObjectiveIndex { get; private set; } = -1;

        public ObjectiveSet(params IObjective[] objectives)
        {
            Objectives = objectives;
            foreach (var objective in objectives)
            {
                objective.SetListener(this);
            }
        }

        public void CompleteObjective(IObjective objective)
        {
            if (CurrentObjective == objective)
            {
                CurrentObjectiveIndex++;
                ObjectiveCompleted?.Invoke(objective);
                CurrentObjective?.Activate();
            }
        }

        public IObjective CurrentObjective => CurrentObjectiveIndex >= 0 && CurrentObjectiveIndex < Objectives.Count
            ? Objectives[CurrentObjectiveIndex]
            : null;

        public void Start()
        {
            CurrentObjectiveIndex = 0;
            CurrentObjective?.Activate();
        }
    }
}