using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    static class MyExtension
    {
        public static Electrical[] SortByAge(this Electrical[] electricaltArray)
        {
            Electrical[] tempArray = new Electrical[electricaltArray.Length];

            for (int i = 0; i < electricaltArray.Length; i++)
            {
                tempArray[i] = electricaltArray[i];
            }

            for (int i = 0; i <= tempArray.Length - 2; i++)
            {
                for (int j = i + 1; j <= tempArray.Length - 1; j++)
                {
                    if (tempArray[i].Power > tempArray[j].Power)
                    {
                        Electrical temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }

            return tempArray;
        }
    }
}
