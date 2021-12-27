using System.Collections.Generic;
using SlimeCraft.Models;
using SlimeCraft.Models.Objectives;
using UnityEngine;
using Zenject;

namespace SlimeCraft.Views.Objectives
{
    public class ObjectivesView : MonoBehaviour
    {
        [SerializeField] private ObjectiveView templateObjective;

        private ObjectiveSet _objectiveSet;
        private IDictionary<IObjective, ObjectiveView> _spawnedObjectives;

        [Inject]
        public void Initialize(IMissionManager missionManager)
        {
            _spawnedObjectives = new Dictionary<IObjective, ObjectiveView>();
            templateObjective.gameObject.SetActive(false);
            SetObjectiveSet(missionManager.ObjectiveSet);
        }

        private void SetObjectiveSet(ObjectiveSet objectiveSet)
        {
            if (_objectiveSet != null)
            {
                _objectiveSet.ObjectiveCompleted -= OnObjectiveCompleted;
            }
            _objectiveSet = objectiveSet;
            _objectiveSet.ObjectiveCompleted += OnObjectiveCompleted;
            foreach (var spawnedObjective in _spawnedObjectives)
            {
                Destroy(spawnedObjective.Value);
            }
            _spawnedObjectives.Clear();

            foreach (var objective in _objectiveSet.Objectives)
            {
                var objectiveView = Instantiate(templateObjective, templateObjective.transform.parent);
                objectiveView.gameObject.SetActive(true);
                objectiveView.Bind(objective);
                objectiveView.SetCompleted(objective.Completed);
                _spawnedObjectives[objective] = objectiveView;
            }
        }

        private void OnObjectiveCompleted(IObjective objective)
        {
            if (_spawnedObjectives.TryGetValue(objective, out var objectiveView))
            {
                objectiveView.SetCompleted(true);
            }
        }

        private void OnDestroy()
        {
            _objectiveSet.ObjectiveCompleted -= OnObjectiveCompleted;
        }
    }
}