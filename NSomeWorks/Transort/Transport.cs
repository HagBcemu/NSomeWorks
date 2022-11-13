using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    public abstract class Transport
    {
        private int _mileage;

        private string _name;

        public Transport(string name, int mileage)
        {
            _name = name;
            _mileage = mileage;
        }

        public int Mileage
        {
            get { return _mileage; }
            set { _mileage = Mileage; }
        }

        public string Name
        {
            get { return _name; }
        }

        public abstract void Move();
    }
}
