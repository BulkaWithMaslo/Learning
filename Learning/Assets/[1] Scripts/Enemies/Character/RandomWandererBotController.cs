using Extensions;
using UnityEngine;

namespace Enemies.Character
{
    public class RandomWandererBotController : MovementControllerBase
    {
        [SerializeField] private Vector3 _bottomLeftPoint;
        [SerializeField] private Vector3 _topRightPoint;
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _stopDistance;

        private Vector3 _targetPosition;

        public override void UpdateInput()
        {
            if (Vector3.Distance(_targetPosition, transform.position) < _stopDistance)
            {
                _targetPosition = VectorExtensions.RandomInsideBox(_bottomLeftPoint, _topRightPoint);
            }

            _rotation = Quaternion.LookRotation(_targetPosition - transform.position).eulerAngles
                        - transform.eulerAngles;
            _movementDirection = new Vector3(0, 0, _moveSpeed * Time.deltaTime);
        }

        public override void Initialize()
        {
            _targetPosition = VectorExtensions.RandomInsideBox(_bottomLeftPoint, _topRightPoint);
        }

        private void OnDrawGizmos()
        {
            if (Application.isPlaying)
            {
                Gizmos.DrawLine(transform.position, _targetPosition);
                Gizmos.DrawWireSphere(_targetPosition, 0.2f);
            }
        }
    }
}