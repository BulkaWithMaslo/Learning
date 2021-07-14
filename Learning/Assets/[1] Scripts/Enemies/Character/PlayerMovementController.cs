using UnityEngine;

namespace Enemies.Character
{
    public class PlayerMovementController : MovementControllerBase
    {
        [SerializeField] private float _moveSpeed;
        [SerializeField] private float _rotateSpeed;
        
        public override void UpdateInput()
        {
            float moveX = Time.deltaTime * _moveSpeed * Input.GetAxis("Horizontal");
            float moveZ = Time.deltaTime * _moveSpeed * Input.GetAxis("Vertical");
            _movementDirection = new Vector3(moveX, 0, moveZ);

            if (Input.GetKey(KeyCode.Q))
                _rotation = new Vector3(0, -_rotateSpeed * Time.deltaTime, 0);
            else if (Input.GetKey(KeyCode.E))
                _rotation = new Vector3(0, _rotateSpeed * Time.deltaTime, 0);
            else
                _rotation = Vector3.zero;
        }

        public override void Initialize() { }
    }
}