using System;
using System.Collections.Generic;
using System.Text;

namespace NSomeWorks
{
    class DelegateExercise
    {
       public delegate int SumHandler(int x, int y);
       event SumHandler SumEvent;

       public void AddEventSum()
        {
            SumEvent += Sum;
            SumEvent += Sum;
        }

       public int Sum(int x, int y)
        {
            return x + y;
        }

       public void SumAllEvents(int x, int y)
        {
            Delegate[] arrayDelegate = SumEvent?.GetInvocationList();
            int sumDelegates = 0;
            if (SumEvent != null)
            {
                for (int i = 0; i < arrayDelegate.Length; i++)
                {
                    SumHandler sumHandler = WrapingMethod(i);
                    sumDelegates += sumHandler(x, y);
                }
            }

            Console.WriteLine(sumDelegates);
        }

       private SumHandler WrapingMethod(int numberDelegate)
        {
            try
            {
                Delegate[] arrayDelegate = SumEvent?.GetInvocationList();

                return (SumHandler)arrayDelegate[numberDelegate];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
