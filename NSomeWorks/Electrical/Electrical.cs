using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    abstract class Electrical
    {
        private string _name;

        private int _power;
        public Electrical(string name, int power)
        {
            _name = name;
            _power = power;
        }

        public string Name
        {
            get { return _name; }
        }

        public int Power
        {
            get { return _power; }
        }
    }
}
