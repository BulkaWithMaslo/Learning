using UnityEngine;

namespace Enemies.Character
{
    public class Weapon : MonoBehaviour
    {
        [SerializeField] private string _weaponName;

        public void Shoot()
        {
            Debug.Log(_weaponName + " makes PEW!");
        }
    }
}