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

        #region TimSort
        private const int RUN = 32;

        private static void insertionSort(int[] arr, int left, int right)
        {
            for (int i = left + 1; i <= right; i++)
            {
                int temp = arr[i];
                int j = i - 1;
                while (j >= left && arr[j] > temp)
                {
                    arr[j + 1] = arr[j];
                    j--;
                }
                arr[j + 1] = temp;
            }
        }
        private static void merge(int[] arr, int l, int m, int r)
        {
            int len1 = m - l + 1, len2 = r - m;
            int[] left = new int[len1];
            int[] right = new int[len2];
            for (int x = 0; x < len1; x++)
                left[x] = arr[l + x];
            for (int x = 0; x < len2; x++)
                right[x] = arr[m + 1 + x];

            int i = 0;
            int j = 0;
            int k = l;
            while (i < len1 && j < len2)
            {
                if (left[i] <= right[j])
                {
                    arr[k] = left[i];
                    i++;
                }
                else
                {
                    arr[k] = right[j];
                    j++;
                }
                k++;
            }
            while (i < len1)
            {
                arr[k] = left[i];
                k++;
                i++;
            }
            while (j < len2)
            {
                arr[k] = right[j];
                k++;
                j++;
            }
        }


        public void TimSort(int[] arr, int n)
        {
            for (int i = 0; i < n; i += RUN)
                insertionSort(arr, i, Math.Min((i + RUN - 1), (n - 1)));  
            for (int size = RUN; size < n;
                                     size = 2 * size)
            {
                for (int left = 0; left < n;
                                      left += 2 * size)
                {
                    int mid = left + size - 1;
                    int right = Math.Min((left +
                                        2 * size - 1), (n - 1));
                    if (mid < right)
                        merge(arr, left, mid, right);
                }
            }
        }
        #endregion

        #region Pow
        public void ElevateSimple(double numb, int degree)
        {
            double output = 1;
            while (degree > 0)
            {
                output *= numb;
                degree -= 1;
            }
        }

        public double ElevateRec(double numb, int degree)
        {
            double output;
            if (degree == 0)
                return 1;
            else
            {
                output = ElevateRec(numb, degree / 2);
                if (degree % 2 == 1)
                    return output * output * numb;
                else
                    return output * output;
            }
        }

        public void ElevateQuick(double numb, int degree)
        {
            double c = numb;
            int k = degree;
            double output;
            if (k % 2 == 1) output = c;
            else output = 1;
            while(k != 0)
            {
                k /= 2;
                c *= c;
                if(k % 2 == 1)
                    output *= c;

            }
        }

        public double ClassicElevateQuick(double numb, int degree)
        {
            double output = 1;
            while(degree != 0)
            {
                if (degree % 2 == 0)
                {
                    numb *= numb;
                    degree /= 2;
                }
                else
                {
                    output *= numb;
                    degree -= 1;
                }
            }
            return output;
        }
        #endregion

        public double MultiplyMatrix(int[,] matrix1, int[,] matrix2)
        {
            double output = 0;
            for (int i = 0; i < matrix1.GetLength(0); i++)
            {
                for (int j = 0; j < matrix1.GetLength(1); j++)
                {
                    output += matrix1[i, j] * matrix2[j, i];
                }
            }
            return output;
        }

        public bool SearchSubstring (string line, string substring)
        {
            int lengthSubstring = substring.Length;
            int lengthLine = line.Length;
            bool isSubstring = false;
            for (int i = 0; i < lengthLine - lengthSubstring + 1; i++)
            {
                for (int j = 0; j < lengthSubstring; j++)
                {
                    if (!(substring[j] == line[i + j]))
                    {
                        isSubstring = false;
                        break;
                    }
                    else
                    {
                        isSubstring = true;
                    }

                }
                if (isSubstring) return true;
            }
            return false;
        }
    }
}
