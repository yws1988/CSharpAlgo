using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam
{
    class CruiseCotnrol
    {
        static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[][] Ns = new int[t][];
            int[][][] numss = new int[t][][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                numss[i] = new int[Ns[i][1]][];
                for (int j = 0; j < Ns[i][1]; j++)
                {
                    numss[i][j] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                }
            }

            for (int i = 0; i < t; i++)
            {
                int D = Ns[i][0];
                int[][] nums = numss[i];
                List<double> ts = new List<double>();
                for (int m = 0; m < nums.GetLength(0); m++)
                {
                    ts.Add((double)(D-nums[m][0])/nums[m][1]);
                }

                double result = D / ts.Max();
                PrintResult(i, result);
            }

            Console.Read();
        }

        private static void PrintResult(int i, double result)
        {
            Console.WriteLine("Case #" + (i + 1) + ": " + "{0:F6}", result);
        }

    }
}
