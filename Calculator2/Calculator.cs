using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator2
{
    public class Calculator
    {

        public Calculator()
        {

        }

        /// <summary>
        /// Add two decimal numbers
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <returns> decimal sum</returns>
        public decimal Add(decimal num1, decimal num2)
        {
            return Math.Round(((num1) + (num2)), 3);

        }

        public decimal Add(decimal[] multipleNumbers)
        {
            decimal sum = multipleNumbers.Sum();
            return sum;
        }

        /// <summary>
        /// It takes two or more numbers from user, and adds them
        /// </summary>
        /// <param name="num1"></param>
        /// <param name="num2"></param>
        /// <param name="moreNumbers"></param>
        /// <returns>decimal sum</returns>
        public decimal Add(decimal num1, decimal num2, params decimal[] moreNumbers)
        {
            decimal sum = 0;
            sum = num1 + num2;

            if (moreNumbers != null)
            {
                foreach (decimal num in moreNumbers)
                {
                    sum += num;
                }
            }
            return sum;
        }

        public decimal Subtract(decimal num1m, decimal num2m)
        {
            //return Math.Round(((num1) - (num2)), 3);
            return ((num1m) - (num2m));
        }

        //public decimal Subtract(decimal[] multipleNumbers)
        //{
        //    int i = 0;
        //    decimal difference = 0;
        //    for (i = 0; i < multipleNumbers.Length - 1; i++)
        //    {
        //        multipleNumbers[i + 1] = ((multipleNumbers[i]) - (multipleNumbers[i + 1]));
        //        Debug.WriteLine($"***********{multipleNumbers[i + 1]}");
        //        difference = multipleNumbers[i + 1];
        //    }

        //    return difference;
        //}

        public decimal Subtract( params decimal[] moreNumbers)
        {
            decimal difference = 0;
            int j;
            //difference = num1 - num2;
            if (moreNumbers != null)
            {
                for (j = 0; j < moreNumbers.Length - 1; j++)
                {
                    moreNumbers[j + 1] = ((moreNumbers[j]) - (moreNumbers[j + 1]));
                    Debug.WriteLine($"***********{moreNumbers[j + 1]}");
                    difference = moreNumbers[j + 1];
                }
            }
            return difference;
        }

        public decimal Divide(decimal num1, decimal num2)
        {
            if (num2 == 0)
            {
                DivideByZeroException divideByZero = new DivideByZeroException("You have divided by zero (0). It does not work...!");
                throw divideByZero;
            }
            return Math.Round((num1) / (num2), 5);

        }
        public decimal Multiply(decimal num1, decimal num2)
        {
            //return Math.Round(((num1) * (num2)), 3);
            return ((num1) * (num2));
        }
        private static void RaisTo()
        {
            throw new NotImplementedException();
        }
        private static void RootOf()
        {
            throw new NotImplementedException();
        }
        private static void Percent()
        {
            throw new NotImplementedException();
        }

    }
}
