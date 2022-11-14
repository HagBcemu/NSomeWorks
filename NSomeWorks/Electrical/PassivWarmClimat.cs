using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class PassivWarmClimat : WarmClimat
    {
        public PassivWarmClimat(string name, int power)
            : base(name, power)
        {
        }

        public override void MakeWarm()
        {
            base.MakeWarm();
            Console.WriteLine("Я нагревательный элемент");
        }
    }
}
