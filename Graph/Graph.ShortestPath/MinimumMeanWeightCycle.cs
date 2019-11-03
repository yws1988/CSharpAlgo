using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.ShortestPath
{
    public class MinimumMeanWeightCycle
    {
        public static int[,] Graph;
        public static int V;
        public static int[,] Dp;
        public static List<(int, int)> Edges=new List<(int, int)>();

        public static void PrintShortestAverageWeightCycle(int[,] cost)
        {
            Graph = cost;
            V = Graph.GetLength(0);
            Dp = new int[V + 1, V];

            for (int i = 0; i <= V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Dp[i, j] = int.MaxValue;
                    if (i != V && Graph[i,j]!=int.MaxValue)
                    {
                        Edges.Add((i, j));
                    }
                }
            }

            Dp[0, 0] = 0;

            for (int i = 1; i <= V; i++)
            {
                foreach (var e in Edges)
                {
                    int s = e.Item1;
                    int d = e.Item2;
                    if (Dp[i - 1, s] != int.MaxValue)
                    {
                        Dp[i, d] = Math.Min(Dp[i, d], Dp[i-1, s]+Graph[s, d]);
                    }
                }
            }

            double[] avg = new double[V];
            for (int i = 0; i < V; i++)
            {
                avg[i] = double.MaxValue;
            }

            for (int j = 0; j < V; j++)
            {
                if (Dp[V, j] != int.MaxValue)
                {
                    int minI = -1;
                    int min = int.MaxValue;
                    for (int i = 0; i < V; i++)
                    {
                        if (Dp[i, j] < min)
                        {
                            minI = i;
                            min = Dp[i, j];
                        }
                    }

                    if (minI != -1)
                    {
                        avg[j] = (double)(Dp[V, j] - Dp[minI, j]) / (V - minI);
                    }
                }
            }

            Console.WriteLine(avg.Min());
        }
    }
}
