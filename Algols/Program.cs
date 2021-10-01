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
        public static Random rnd = new Random();

        private static int[] CreateVector(int length)
        {
            var Vector = new int[length];
            for (int i = 0; i < length; i++)
            {
                Vector[i] = rnd.Next(0,2000);
            }
            return Vector;
        }

        private static int[,] CreateMatrix(int height, int width)
        {
            var matrix = new int[height, width];
            for (int i = 0; i < height; i++)
            {
                for (int j = 0; j < width; j++)
                {
                    matrix[i, j] = rnd.Next(1, 10);
                }
            }
            return matrix;
        }
        public static void Main(string[] args)
        {

            List<int>[] timeResultsList = new List<int>[5];
            for (int k = 0; k < timeResultsList.Length; k++)
            {
                List<int> timeResults = new List<int>();
                for (int i = 0; i < 500; i++)
                {
                    //var vector = CreateVector(i);
                    int[,] matrix1 = CreateMatrix(i, i);
                    int[,] matrix2 = CreateMatrix(i, i);
                    Watch.Reset();
                    Watch.Start();    
                    double x = algorithms.MultiplyMatrix(matrix1, matrix2);
                    Watch.Stop();
                    timeResults.Add((int)Watch.ElapsedTicks);
                }
                timeResultsList[k] = timeResults;
            }
            FillFile(RemoveEmissions(timeResultsList));
        }
        public static List<int> RemoveEmissions(List<int>[] timeResultsList)
        {
            var endVector = Enumerable.Repeat(int.MaxValue, timeResultsList[0].Count).ToArray();
            for (int i = 0; i < timeResultsList[0].Count; i++)
            {
                for (int j = 0; j < timeResultsList.Length; j++)
                {
                    if (endVector[i] > timeResultsList[j][i])
                    {
                        endVector[i] = timeResultsList[j][i];
                    }
                }
            }
            return endVector.ToList();
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
