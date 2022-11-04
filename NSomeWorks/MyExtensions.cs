using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    static class MyExtensions
    {
        public static Transport[] SortByMealeAge(this Transport[] transportArray)
        {
            Transport[] tempArray = new Transport[transportArray.Length - 1];

            for (int i = tempArray.Length; i > 0; i--)
            {
                tempArray[i - 1] = transportArray[i];
            }

            for (int i = 0; i <= tempArray.Length - 2; i++)
            {
                for (int j = i + 1; j <= tempArray.Length - 1; j++)
                {
                    if (tempArray[i].Mileage > tempArray[j].Mileage)
                    {
                        Transport temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }

            return tempArray;
        }
    }
}
