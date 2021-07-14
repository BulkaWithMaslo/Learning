using UnityEngine;

namespace Enemies.Character
{
    public abstract class MovementControllerBase : MonoBehaviour
    {
        protected Vector3 _movementDirection;
        protected Vector3 _rotation;
        public Vector3 MovementDirection => _movementDirection;
        public Vector3 Rotation => _rotation;

        public abstract void UpdateInput();

        public abstract void Initialize();
    }
}