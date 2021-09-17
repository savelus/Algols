using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;

namespace Algols
{
    class Program
    {
        public static Stopwatch Watch = new Stopwatch();
        public static Algorithms algorithms = new Algorithms();
        static int[] CreateVector(int length)
        {
            var rnd = new Random(42);
            var Vector = new int[length];
            for (int i = 0; i < length; i++)
            {
                Vector[i] = rnd.Next();
            }
            return Vector;
        }

        public static void Main(string[] args)
        {
            
            List<int> timeResults = new List<int>();
            for (int i = 0; i < 2000; i++)
            {
                var vector = CreateVector(i);
                Watch.Reset();
                Watch.Start();
                algorithms.StandartCalculatePolynomial(vector);
                Watch.Stop();
                timeResults.Add((int)Watch.ElapsedTicks);
            }
            FillFile(timeResults);
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
