using System.Collections.Generic;
using UnityEngine;

namespace Shop_Thingy
{
    public class Cart : MonoBehaviour
    {
        [SerializeField] private Good _good1;
        [SerializeField] private Good _good2;

        private Shop _shop;
        [SerializeField] private List<WarehouseGood> _items = new List<WarehouseGood>();

        public void Initialize(Shop shop, Good good1, Good good2)
        {
            _shop = shop;
            _good1 = good1;
            _good2 = good2;
        }

        public void AddGood1ToCart()
        {
            if (_shop.AddGood1ToCart(1))
            {
                AddGood(_good1, 1);
            }
        }

        public void AddGood2ToCart()
        {
            if (_shop.AddGood2ToCart(1))
            {
                AddGood(_good2, 1);
            }
        }

        public void ConfirmCart()
        {
            foreach (var item in _items)
            {
                Debug.Log("Cart has " + item.ToString());
            }
            _shop.DestroyCart(this);
        }

        public void ClearCart()
        {
            _shop.ReturnItems(_items);
            _shop.DestroyCart(this);
        }

        private void AddGood(Good good, int amount)
        {
            foreach (var warehouseGood in _items)
            {
                if (warehouseGood.IsThisGood(good))
                {
                    warehouseGood.AddSimilar(amount);
                    return;
                }
            }

            _items.Add(new WarehouseGood(good, amount));
        }
    }
}