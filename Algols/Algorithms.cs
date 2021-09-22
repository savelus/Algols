using System;
using System.Collections.Generic;
using System.Linq;
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

        public double StandartCalculatePolynomial(int[] vector)
        {
            double sum = 0;
            for (int i = 0; i < vector.Length - 1; i++)
            {
                sum += vector[i + 1]
                    * Math.Pow(1.5, i);
            }
            return sum;
        }

        public double GornerCalculatePolynomial(List<int> vector)
        {
            double sum = 0;
            if (vector.Count != 0)
            {

                sum += vector[0];
                vector.RemoveAt(0);
                sum += 1.5 * GornerCalculatePolynomial(vector);
                return sum;
            }
            else
            {
                return 0;
            }
        }

        public void BubbleSort(int[] vector)
        {
            var vectorArr = vector.ToArray();
            for (int i = 0; i < vectorArr.Length; i++)
            {
                for (int j = 0; j < vectorArr.Length - 1; j++)
                {
                    if (vectorArr[j] <= vectorArr[j + 1])
                    {
                        int temp = vectorArr[j];
                        vectorArr[j] = vectorArr[j + 1];
                        vectorArr[j + 1] = temp;
                    }
                }
            }
        }

        #region QuickSort
        private void Swap(ref int x, ref int y)
        {
            var t = x;
            x = y;
            y = t;
        }

        //метод возвращающий индекс опорного элемента
        private int Partition(int[] array, int minIndex, int maxIndex)
        {
            var pivot = minIndex - 1;
            for (var i = minIndex; i < maxIndex; i++)
            {
                if (array[i] < array[maxIndex])
                {
                    pivot++;
                    Swap(ref array[pivot], ref array[i]);
                }
            }

            pivot++;
            Swap(ref array[pivot], ref array[maxIndex]);
            return pivot;
        }

        //быстрая сортировка
        private int[] QuickSort(int[] array, int minIndex, int maxIndex)
        {
            if (minIndex >= maxIndex)
            {
                return array;
            }

            var pivotIndex = Partition(array, minIndex, maxIndex);
            QuickSort(array, minIndex, pivotIndex - 1);
            QuickSort(array, pivotIndex + 1, maxIndex);

            return array;
        }

        public int[] QuickSort(int[] array)
        {
            return QuickSort(array, 0, array.Length - 1);
        }
        #endregion

    }
}
