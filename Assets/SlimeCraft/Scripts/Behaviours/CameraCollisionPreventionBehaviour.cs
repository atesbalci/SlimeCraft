using UnityEngine;

namespace SlimeCraft.Behaviours
{
    public class CameraCollisionPreventionBehaviour : MonoBehaviour
    {
        private const float ShiftOffset = 0.75f;
        
        [SerializeField] private LayerMask _layerMask;
        
        private Vector3 _defaultLocalPos;
        private float _defaultDistanceFromRoot;

        private void Awake()
        {
            _defaultLocalPos = transform.localPosition;
            _defaultDistanceFromRoot = _defaultLocalPos.magnitude;
        }

        private void Update()
        {
            var parent = transform.parent;
            var parentPos = parent.position;
            var pos = transform.position;
            var projectedPos = parent.TransformPoint(_defaultLocalPos);
            if (Physics.Raycast(new Ray(parentPos, projectedPos - parentPos), out var hitInfo, _defaultDistanceFromRoot + ShiftOffset, _layerMask))
            {
                transform.position = Vector3.MoveTowards(hitInfo.point, parentPos, ShiftOffset);
            }
            else
            {
                transform.localPosition = _defaultLocalPos;
            }
        }
    }
}