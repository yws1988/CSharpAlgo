using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.ShortestPath
{
    public class MinimumMeanWeightCycle
    {
        public static double GetMinimumMeanWeightCycle(int[,] graph)
        {
            int v = graph.GetLength(0);
            var dp = new int[v + 1, v];
            var edges = new List<(int, int)>();

            for (int i = 0; i <= v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    dp[i, j] = int.MaxValue;

                    if (i != v && graph[i,j] != int.MaxValue)
                    {
                        edges.Add((i, j));
                    }
                }
            }

            dp[0, 0] = 0;

            for (int i = 1; i <= v; i++)
            {
                foreach (var e in edges)
                {
                    int s = e.Item1;
                    int d = e.Item2;
                    if (dp[i - 1, s] != int.MaxValue)
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

            return avg.Min();
        }
    }
}
