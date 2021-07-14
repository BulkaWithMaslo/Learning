using UnityEngine;

namespace Enemies.Character
{
    public class CharacterBase : MonoBehaviour
    {
        [SerializeField] private MovementControllerBase _movementController;
        [SerializeField] private ShootControllerBase _shootController;

        private void Awake()
        {
            _movementController.Initialize();
        }

        private void Update()
        {
            _movementController.UpdateInput();
            
            transform.Translate(_movementController.MovementDirection);
            transform.Rotate(_movementController.Rotation);
            
            _shootController.TryShoot();
        }
    }
}
