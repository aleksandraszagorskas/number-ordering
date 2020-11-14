using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NumberOrdering.API.Services
{
    public class NumberOrderingService
    {
        #region Properties
        public int[] Numbers { get; private set; }
        //public int[] Result { get; private set; }
        #endregion

        public NumberOrderingService(int[] numbers)
        {
            Numbers = numbers;
        }

        public void Order()
        {
            for (int i = 0; i < Numbers.Length - 1; i++)
            {
                for (int j = 0; j < Numbers.Length - 1; j++)
                {
                    var firstNum = Numbers[j];
                    var secondNum = Numbers[j + 1];

                    if (firstNum > secondNum)
                    {
                        Numbers[j] = secondNum;
                        Numbers[j + 1] = firstNum;
                    }
                }
            }
        }
    }
}
