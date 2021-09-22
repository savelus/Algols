using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;

namespace Algols
{
    class Program
    {
        public static Stopwatch Watch = new Stopwatch();
        public static Algorithms algorithms = new Algorithms();
        static int[] CreateVector(int length)
        {
            var Vector = new int[length];
            for (int i = 0; i < length; i++)
            {
                Vector[i] = 2;
            }
            return Vector;
        }

        public static void Main(string[] args)
        {
            double x1 = 0;
            double x = 0;
            List<int> timeResults = new List<int>();
            for (int i = 0; i < 1980; i++)
            {
                var vector = CreateVector(i);

                //List<int> temp = new List<int>();
                //for (int j = 0; j < 5; j++)
                //{
                //    Watch.Reset();
                //    Watch.Start();
                //    algorithms.SumOfElements(vector);
                //    Watch.Stop();
                //    temp.Add((int)Watch.ElapsedTicks);
                //}
                //timeResults.Add(temp.Min());

                Watch.Reset();
                Watch.Start();
                int[] xs = algorithms.QuickSort(vector);
                Watch.Stop();
                timeResults.Add((int)Watch.ElapsedTicks);

            }
            //FillFile(timeResults);
            FillFile(RemoveEmissions(timeResults));
        }
        public static List<int> RemoveEmissions(List<int> vector)
        {
            var vectorArr = vector.ToArray();
            for (int i = 1; i < vectorArr.Length - 1; i++)
            {
                if (vectorArr[i] >= vectorArr[i - 1] * 1.5 && vectorArr[i] >= vectorArr[i + 1] * 1.5)
                    vectorArr[i] = vectorArr[i - 1];
            }
            return vectorArr.ToList();
        }
        public static void FillFile(List<int> timeResults)
        {
            File.WriteAllText("Data.csv", CreateLine(timeResults));
        }

        public static string CreateLine (List<int> timeResults)
        {
            StringBuilder sb = new StringBuilder();

            foreach (var result in timeResults)
            {
                sb.Append(result + ";");
            }

            return sb.ToString();
        }
    }
}
