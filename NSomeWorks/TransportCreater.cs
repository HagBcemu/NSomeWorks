using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class TransportCreater
    {
        public static Transport[] GetTransports()
        {
            Transport[] transports =
            {
                new ICECar("Audi A8", 40000, TypeTires.AllSeason, 12),
                new ICECar("Omoda C5", 55000, TypeTires.Winter, 40),
                new ICECar("Renault Duster", 65000, TypeTires.AllSeason, 15),
                new ICECar("KIA K5", 35000, TypeTires.Summer, 40),
                new ICECar("Toyota Camry", 48000, TypeTires.AllSeason, 30),
                new ICECar("Mitsubishi Outlander", 15000, TypeTires.AllSeason, 15),
                new ICECar("Land Rover Defender 110", 40000, TypeTires.Summer, 40),

                new SportICECar("TOYOTA SUPRA BASE 2021", 12000, TypeTires.Summer, 30, 125),
                new SportICECar("DODGE CHALLENGER SXT", 12000, TypeTires.Slick, 40, 150),
                new SportICECar("BMW I8", 12000, TypeTires.Summer, 30, 100),
                new SportICECar("PORSCHE BOXSTER S", 12000, TypeTires.AllSeason, 40, 170),
                new SportICECar("JAGUAR XK", 12000, TypeTires.Summer, 30, 180),
                new SportICECar("FERRARI FF", 12000, TypeTires.AllSeason, 40, 90),

                new ElectroCar("TESLA MODEL Y", 80000, TypeTires.AllSeason, 100),
                new ElectroCar("TESLA MODEL X ", 60000, TypeTires.Summer, 100),
                new ElectroCar("Volkswagen ID", 80000, TypeTires.Summer, 90),
                new ElectroCar("KIA NIRO", 80000, TypeTires.Winter, 100),
                new ElectroCar("AUDI E-TRON PRESTIGE", 80000, TypeTires.AllSeason, 95),
                new ElectroCar("VOLKSWAGEN E-GOLF", 80000, TypeTires.Winter, 100),
            };
            return transports;
        }
    }
}
