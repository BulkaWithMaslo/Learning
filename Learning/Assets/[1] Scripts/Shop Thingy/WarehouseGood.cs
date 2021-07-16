using System;
using UnityEngine;

namespace Shop_Thingy
{
    [Serializable]
    public class WarehouseGood
    {
        [SerializeField] private Good _good;
        [SerializeField] private int _amount;
    
        public int Amount => _amount;
    
        public WarehouseGood(Good good, int amount)
        {
            _good = good;
            _amount = amount;
        }
        
        public WarehouseGood(WarehouseGood good)
        {
            _good = good._good;
            _amount = good._amount;
        }
    
        public bool IsThisGood(Good good)
        {
            return _good.Compare(good);
        }
        
        public bool IsThisGood(WarehouseGood good)
        {
            return _good.Compare(good._good);
        }
    
        public void AddSimilar(int amount)
        {
            _amount += amount;
        }
    
        public void RemoveSimilar(int amount)
        {
            _amount -= amount;
        }

        public override string ToString()
        {
            return _amount + " of " + _good.Name;
        }
    }
}