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
        #endregion

        public NumberOrderingService(int[] numbers)
        {
            if (numbers == null)
            {
                throw new ArgumentNullException();
            }

            if (!numbers.Any())
            {
                throw new ArgumentException();
            }

            Numbers = numbers;
        }

        /// <summary>
        /// Order numbers
        /// </summary>
        public void Order()
        {
            BubbleSort();
        }

        private void BubbleSort()
        {
            //going through array
            for (int i = 0; i < Numbers.Length - 1; i++)
            {
                bool numChanged = false;

                //bubbling max value and not going through ordered values
                for (int j = 0; j < Numbers.Length - (i + 1); j++)
                {
                    var firstNum = Numbers[j];
                    var secondNum = Numbers[j + 1];

                    if (firstNum > secondNum)
                    {
                        Numbers[j] = secondNum;
                        Numbers[j + 1] = firstNum;

                        numChanged = true;
                    }
                }

                //if numbers didn't change, array is ordered
                if (!numChanged)
                {
                    break;
                }

                numChanged = false;
            }
        }
    }
}
