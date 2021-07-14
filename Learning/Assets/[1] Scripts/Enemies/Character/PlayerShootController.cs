using UnityEngine;

namespace Enemies.Character
{
    public class PlayerShootController : ShootControllerBase
    {
        public override void Initialize() { }

        public override void TryShoot()
        {
            if (Input.GetMouseButtonDown(0))
                Shoot();
        }
    }
}