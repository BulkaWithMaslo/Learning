using System.Collections.Generic;
using UnityEngine;

namespace Shop_Thingy
{
    public class Warehouse : MonoBehaviour
    {

        [SerializeField] private List<WarehouseGood> _goods = new List<WarehouseGood>();

        // For buttons connectivity
        [SerializeField] private Good _good1;
        [SerializeField] private Good _good2;

        public void AddGood1(int amount = 1)
        {
            AddGood(_good1, amount);
        }

        public void AddGood2(int amount = 1)
        {
            AddGood(_good2, amount);
        }

        public bool RemoveGood1(int amount = 1)
        {
            return RemoveGood(_good1, amount);
        }

        public bool RemoveGood2(int amount = 1)
        {
            return RemoveGood(_good2, amount);
        }

        private bool RemoveGood(Good good, int amount)
        {
            foreach (var warehouseGood in _goods)
            {
                if (warehouseGood.IsThisGood(good))
                {
                    if (warehouseGood.Amount >= amount)
                    {
                        warehouseGood.RemoveSimilar(amount);
                        Debug.Log("Removed successfully " + amount + " of " + good.Name);
                        return true;
                    }
                    else
                    {
                        Debug.Log("Has not enough of " + good.Name);
                        return false;
                    }
                }
            }

            Debug.Log("Has no " + good.Name);
            return false;
        }

        public void AddGood(Good good, int amount)
        {
            foreach (var warehouseGood in _goods)
            {
                if (warehouseGood.IsThisGood(good))
                {
                    warehouseGood.AddSimilar(amount);
                    return;
                }
            }

            _goods.Add(new WarehouseGood(good, amount));
        }
        
        public void AddGood(WarehouseGood good)
        {
            foreach (var warehouseGood in _goods)
            {
                if (warehouseGood.IsThisGood(good))
                {
                    warehouseGood.AddSimilar(good.Amount);
                    return;
                }
            }

            _goods.Add(new WarehouseGood(good));
        }
    }
}