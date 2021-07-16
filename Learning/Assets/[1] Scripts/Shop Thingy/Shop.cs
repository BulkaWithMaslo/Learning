using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

namespace Shop_Thingy
{
    public class Shop : MonoBehaviour
    {
        // For buttons connectivity
        [SerializeField] private Good _good1;
        [SerializeField] private Good _good2;

        [SerializeField] private Warehouse _wh;
        [SerializeField] private Button _c1;
        [SerializeField] private Button _c2;
        [SerializeField] private Button _clear;
        [SerializeField] private Button _out;

        private Cart _cart;

        // button
        public void GenerateCart()
        {
            var go = new GameObject();
            var cart = go.AddComponent<Cart>();
            cart.Initialize(this, _good1, _good2);
            // link buttons
            AddCallbacks(cart);
            if (_cart != null)
            {
                _cart.ClearCart();
                DestroyCart(_cart);
            }
            _cart = cart;
        }

        private void AddCallbacks(Cart cart)
        {
            _c1.onClick.AddListener(cart.AddGood1ToCart);
            _c2.onClick.AddListener(cart.AddGood2ToCart);
            _clear.onClick.AddListener(cart.ClearCart);
            _out.onClick.AddListener(cart.ConfirmCart);
        }

        private void RemoveCallbacks(Cart cart)
        {
            _c1.onClick.RemoveListener(cart.AddGood1ToCart);
            _c2.onClick.RemoveListener(cart.AddGood2ToCart);
            _clear.onClick.RemoveListener(cart.ClearCart);
            _out.onClick.RemoveListener(cart.ConfirmCart);
        }

        // call
        public void DestroyCart(Cart cart)
        {
            RemoveCallbacks(cart);
            Destroy(cart.gameObject);
        }

        // call
        public bool AddGood1ToCart(int amount)
        {
            return _wh.RemoveGood1(amount);
        }

        // call
        public bool AddGood2ToCart(int amount)
        {
            return _wh.RemoveGood2(amount);
        }

        // call
        public void ReturnItems(List<WarehouseGood> items)
        {
            foreach (var warehouseGood in items)
            {
                _wh.AddGood(warehouseGood);
            }
        }
    }
}