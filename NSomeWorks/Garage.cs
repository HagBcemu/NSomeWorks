using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Garage
    {
        private Transport[] _transportArray;

        public Garage()
        {
            _transportArray = new Transport[1];
        }

        public void AddProductToBasket(Transport transport)
        {
            Array.Resize(ref _transportArray, _transportArray.Length + 1);

            _transportArray[_transportArray.Length - 1] = transport;
        }

        public Transport[] GetTransprotInGarage()
        {
            return _transportArray;
        }

        public int GetSummMileage()
        {
            int summMileager = 0;
            foreach (var transport in _transportArray)
            {
                if (transport != null)
                {
                    summMileager += transport.Mileage;
                }
            }

            return summMileager;
        }
    }
}
