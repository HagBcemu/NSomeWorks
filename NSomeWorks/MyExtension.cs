using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    static class MyExtension
    {
        public static (string, int)[] Add(this (string, int)[] array, (string, int) kort)
        {
            (string, int)[] tempArray = array;
            array = new (string, int)[array.Length + 1];

            for (int i = 0; i < tempArray.Length; i++)
            {
                array[i] = tempArray[i];
            }

            array[array.Length - 1] = kort;

            return array;
        }

        public static Animal[] SortByAge(this Animal[] animaltArray)
        {
            Animal[] tempArray = new Animal[animaltArray.Length];

            for (int i = 0; i < animaltArray.Length; i++)
            {
                tempArray[i] = animaltArray[i];
            }

            for (int i = 0; i <= tempArray.Length - 2; i++)
            {
                for (int j = i + 1; j <= tempArray.Length - 1; j++)
                {
                    if (tempArray[i].Age > tempArray[j].Age)
                    {
                        Animal temp = tempArray[i];
                        tempArray[i] = tempArray[j];
                        tempArray[j] = temp;
                    }
                }
            }

            return tempArray;
        }
    }
}
