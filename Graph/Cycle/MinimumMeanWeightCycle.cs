namespace CSharpAlgo.Graph.Cycle
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    /// <summary>
    /// Karp’s minimum mean (or average) weight cycle algorithm
    /// </summary>
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

                    if (i != v && graph[i, j] != int.MaxValue)
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
                        dp[i, d] = Math.Min(dp[i, d], dp[i-1, s]+graph[s, d]);
                    }
                }
            }

            double[] avg = new double[v];
            for (int i = 0; i < v; i++)
            {
                avg[i] = double.MaxValue;
            }

            for (int j = 0; j < v; j++)
            {
                if (dp[v, j] != int.MaxValue)
                {
                    int minIndex = -1;
                    int min = int.MaxValue; 
                    for (int i = 0; i < v; i++)
                    {
                        if (dp[i, j] < min)
                        {
                            minIndex = i;
                            min = dp[i, j];
                        }
                    }

                    if (minIndex != -1)
                    {
                        avg[j] = (double)(dp[v, j] - dp[minIndex, j]) / (v - minIndex);
                    }
                }
            }

            return avg.Min();
        }
    }
}
