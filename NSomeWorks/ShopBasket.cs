using System;
using System.Collections.Generic;

namespace NSomeWorks
{
    class ShopBasket
    {
        private Product[] _productsArray;

        private int _idShopBasket;

        private int _summPriseBasket = 0;

        public ShopBasket()
        {
            _productsArray = new Product[1];

            _idShopBasket = new Random().Next(1, 1000000);

            _summPriseBasket = 0;
        }

        public void AddProductToBasket(Product product)
        {
            Array.Resize(ref _productsArray, _productsArray.Length + 1);

            _productsArray[_productsArray.Length - 1] = product;

            _summPriseBasket += product.Prise;
        }

        public Product[] GetProductInBasket()
        {
            return _productsArray;
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
