using System;
using System.Collections.Generic;
using System.Text;
using static NSomeWorks.Class1;

namespace NSomeWorks
{
    public delegate bool ResultHadler(int x);

    class Class2
    {
        private ResultHadler _resultHadler;

        private int _temPow;
        public ResultHadler Calc(PowHadler powHadler, int x, int y)
        {
            _temPow = powHadler(x, y);
            _resultHadler = Result;
            return _resultHadler;
        }

        public bool Result(int x)
        {
            if (_temPow % x > 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }
    }
}
