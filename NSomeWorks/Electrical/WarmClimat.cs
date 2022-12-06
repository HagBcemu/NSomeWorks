using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class WarmClimat : ClimatElectro
    {
        public WarmClimat(string name, int power)
            : base(name, power)
        {
        }

        public virtual void MakeWarm()
        {
            Console.WriteLine("Делаю тепло");
        }
    }
}
