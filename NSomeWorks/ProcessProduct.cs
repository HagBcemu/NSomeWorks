using System.Collections.Generic;

namespace NSomeWorks
{
    class ProcessProduct
    {
        public static List<Product> GetProducts()
        {
            List<Product> products = new List<Product>
            {
                new Product("Ноутбук", 10000),
                new Product("Смартфон", 4000),
                new Product("Стиралка", 8000),
                new Product("Обогреватель", 3500),
                new Product("Корм для собаки", 400),
                new Product("Коляска", 7000),
                new Product("Дрель", 2500),
                new Product("Принтер", 5700),
                new Product("Рация", 1500),
                new Product("Одежда", 800),
            };
            return products;
        }
    }
}
