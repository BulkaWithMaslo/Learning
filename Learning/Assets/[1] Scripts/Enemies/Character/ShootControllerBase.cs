using UnityEngine;

namespace Enemies.Character
{
    public abstract class ShootControllerBase : ControllerBase
    {
        [SerializeField] private Weapon _weapon;
        
        public abstract void TryShoot();

        protected virtual void Shoot()
        {
            _weapon.Shoot();
        }
    }
}