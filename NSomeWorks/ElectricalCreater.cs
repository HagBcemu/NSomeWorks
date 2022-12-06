using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ElectricalCreater
    {
        public static Electrical[] GetElectricals()
        {
            Electrical[] electricals =
            {
                new EntertainmentElectro("Компьютер", 500),
                new EntertainmentElectro("Монитор", 70),
                new EntertainmentElectro("Телевизор", 140),
                new EntertainmentElectro("Телефон", 40),
                new EntertainmentElectro("Ноутбук", 150),

                new KitchenElectro("Чайник", 2000),
                new KitchenElectro("Блендер", 1000),
                new KitchenElectro("Микроволновка", 700),
                new KitchenElectro("Холодильник", 150),

                new ActivWarmClimat("Кодиционер", 500),
                new ActivWarmClimat("Тепловентилятор", 2000),

                new PassivWarmClimat("Конвектор", 2000),
                new PassivWarmClimat("Керамическая панель", 700),
            };

            return electricals;
        }
    }
}
