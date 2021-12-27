using SlimeCraft.Models.Objectives;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SlimeCraft.Views.Objectives
{
    public class ObjectiveView : MonoBehaviour
    {
        [SerializeField] private Toggle toggle;
        [SerializeField] private TMP_Text text;

        public void Bind(IObjective objective)
        {
            text.text = objective.Id;
        }

        public void SetCompleted(bool completed)
        {
            toggle.isOn = completed;
        }
    }
}