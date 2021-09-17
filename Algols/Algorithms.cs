using System;
using System.Collections.Generic;
using System.Text;

namespace Algols
{
    public class Algorithms
    {
        public void ConstantFunction(int[] vector)
        {
            Console.Write(' ');
        }

        public void SumOfElements(int[] vector)
        {
            int sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum += vector[i];
            }
        }

        public void ProductOfElements(int[] vector)
        {
            int sum = 0;
            for (int i = 0; i < vector.Length; i++)
            {
                sum *= vector[i];
            }
        }

        public void StandartCalculatePolynomial(int[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                sum += vector[i] * Math.Pow(1.5, i);
            }
        }

        public double GornerCalculatePolynomial(int[] vector)
        {
            double sum = 0;
            if (vector.Length != 0)
            {
                sum += vector[0] + 1.5 * GornerCalculatePolynomial();
            }
            else
            {
                return 0;
            }
        }
    }
}
