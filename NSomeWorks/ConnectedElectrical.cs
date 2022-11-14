using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class ConnectedElectrical
    {
        private Electrical[] _electricals;

        public ConnectedElectrical()
        {
            _electricals = new Electrical[0];
        }

        public void AddElectrical(Electrical electrical)
        {
            Electrical[] tempElectrical = _electricals;

            _electricals = new Electrical[tempElectrical.Length + 1];

            for (int i = 0; i < tempElectrical.Length; i++)
            {
                _electricals[i] = tempElectrical[i];
            }

            _electricals[_electricals.Length - 1] = electrical;
        }

        public Electrical[] GetElectricals()
        {
            return _electricals;
        }

        public int GetAllPower()
        {
            int power = 0;

            foreach (var item in _electricals)
            {
                power += item.Power;
            }

            return power;
        }
    }
}
