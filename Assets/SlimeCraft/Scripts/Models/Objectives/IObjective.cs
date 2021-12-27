using System;

namespace SlimeCraft.Models.Objectives
{
    public interface IObjective : IDisposable
    {
        string Id { get; }
        bool Completed { get; }
        void Activate();
        void SetListener(IObjectiveStatusListener statusListener);
    }
}