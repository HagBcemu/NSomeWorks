using System;
using System.Collections.Generic;

namespace NSomeWorks
{
    class ShopBasket
    {
        private List<Product> _products;

        private int _idShopBasket;

        private int _summPriseBasket = 0;

        public ShopBasket()
        {
            _products = new List<Product>();

            _idShopBasket = new Random().Next(1, 1000000);

            _summPriseBasket = 0;
        }

        public void AddProductToBasket(Product product)
        {
            _products.Add(product);
            _summPriseBasket += product.Prise;
        }

        public List<Product> GetProductInBasket()
        {
            return _products;
        }

        public int GetSummBasket()
        {
            return _summPriseBasket;
        }

        public int GetOrderId()
        {
            return _idShopBasket;
        }
    }
}
