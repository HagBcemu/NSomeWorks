using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ActivWarmClimat : WarmClimat
    {
        public ActivWarmClimat(string name, int power)
            : base(name, power)
        {
        }

        public override void MakeWarm()
        {
            base.MakeWarm();
            Console.WriteLine("Я обогреваю воздух и выдуваю его");
        }
    }
}
