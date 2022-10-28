using System;
using System.Collections.Generic;
using System.Diagnostics;

namespace NSomeWorks
{
    class ConsoleWriter
    {
        List<Product> _products;

        ShopBasket _shopBasket;

        public void ShowShop()
        {
            _products = ProcessProduct.GetProducts();

            _shopBasket = new ShopBasket();

            ShowProduct();

            ShowControlProduct();
        }

        void ShowProduct()
        {
            Console.Clear();
            Console.WriteLine("Количество товаров в корзине " + _shopBasket.GetProductInBasket().Count + ". Общая сумма в корзине " + _shopBasket.GetSummBasket() + "\n");
            for (int i = 0; i < _products.Count; i++)
            {
                Console.WriteLine(i + ".) " + _products[i].Name + " цена: " + _products[i].Prise);
            }

            Console.WriteLine("\nВведите номер товара и нажмите ENTER что бы добавить довар в корзину");
            Console.WriteLine("или * для того что бы перейти в корзину");
            Console.WriteLine("или exit что бы закрыть");
        }

        void ShowShopBasket()
        {
            Console.Clear();
            Console.WriteLine("Добро пожаловать в корзину\n Вы выбрали такой товар");
            Console.WriteLine("Общая сумма в корзине " + _shopBasket.GetSummBasket() + "\n");
            List<Product> productsChose = _shopBasket.GetProductInBasket();

            for (int i = 1; i < productsChose.Count + 1; i++)
            {
                Console.WriteLine(i + ".) " + productsChose[i - 1].Name + " цена: " + productsChose[i - 1].Prise);
            }
        }

        void ShowControlProduct()
        {
            while (true)
            {
                int numberChose = 0;
                string consoleWrite = Console.ReadLine();
                bool succesParseNumber = int.TryParse(consoleWrite, out numberChose);
                if (succesParseNumber)
                {
                    if (numberChose < _products.Count)
                    {
                        _shopBasket.AddProductToBasket(_products[numberChose]);
                        Console.Clear();
                        ShowProduct();
                        Console.WriteLine("\nTовар успешно добавлен " + _products[numberChose].Name);
                    }
                    else
                    {
                        Console.WriteLine("\nНету такого товара");
                    }
                }
                else
                {
                    if (consoleWrite == "*")
                    {
                        ShowShopBasket();
                        ControlPanelBasket();
                    }

                    if (consoleWrite == "exit")
                    {
                        Process.GetCurrentProcess().Kill();
                    }

                    Console.WriteLine("\nНе корректно введена команда");
                }
            }
        }

        void ControlPanelBasket()
        {
            while (true)
            {
                Console.WriteLine("Введите * что бы оформить заказ или + что бы выйти в магазин ");
                Console.WriteLine("или exit что бы закрыть");
                string userInput = Console.ReadLine();
                if (userInput == "*")
                {
                    if (_shopBasket.GetSummBasket() == 0)
                    {
                        Console.WriteLine("У вас пустая корзина\n");
                    }
                    else
                    {
                        Console.WriteLine("Вы оформили заказ на сумму " + _shopBasket.GetSummBasket());
                        Console.WriteLine("Ваш номер заказа " + _shopBasket.GetOrderId());
                        _shopBasket = new ShopBasket();
                    }
                }
                else if (userInput == "+")
                {
                    ShowProduct();
                    ShowControlProduct();
                }
                else if (userInput == "exit")
                {
                    Process.GetCurrentProcess().Kill();
                }
                else
                {
                    Console.WriteLine("Не корректное значение");
                }
            }
        }
    }
}
