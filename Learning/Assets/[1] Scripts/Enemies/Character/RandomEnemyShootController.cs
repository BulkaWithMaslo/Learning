using UnityEngine;

namespace Enemies.Character
{
    public class RandomEnemyShootController : ShootControllerBase
    {
        [SerializeField] private float _minReloadTime;
        [SerializeField] private float _maxReloadTIme;

        private float _nextShootTime;
        
        public override void TryShoot()
        {
            if (Time.time > _nextShootTime)
            {
                Shoot();
                UpdateNextShoot();
            }
        }

        public override void Initialize()
        {
            UpdateNextShoot();
        }

        private void UpdateNextShoot()
        {
            _nextShootTime = Time.time + Random.Range(_minReloadTime, _maxReloadTIme);
        }
    }
}