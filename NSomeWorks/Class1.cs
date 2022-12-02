using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class Class1
    {
        public delegate void ShowHadler(bool boolStatus);

        public delegate int PowHadler(int x, int y);

        public static int Pow(int x, int y)
        {
            return x * y;
        }
    }
}
