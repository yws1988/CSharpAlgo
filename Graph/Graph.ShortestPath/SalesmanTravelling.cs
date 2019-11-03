using System;

namespace Graph.ShortestPath
{
    public class SalesmanTravelling
    {
        public static int[,] Graph { get; set; }
        public static int V { get; set; }

        public static void GetShortestDp(int[,] cost)
        {
            Graph = cost;
            V = Graph.GetLength(0);
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if(Graph[i, j] == 0)
                    {
                        Graph[i, j] = int.MaxValue;
                    }
                }
            }
            int max = (int)Math.Pow(2, V);
            int[,] dp = new int[V,(int)Math.Pow(2, V)];
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            for (int i = 1; i < V; i++)
            {
                if(cost[i, 0] != int.MaxValue)
                {
                    dp[i, 1 | (1 << i)] = cost[i, 0];
                }
            }

            for (int mask = 1; mask < max; mask++)
            {
                for (int m = 1; m < V; m++)
                {
                    for (int v = 1; v < V; v++)
                    {
                        if (Graph[m, v]!=int.MaxValue && (mask >> m & 1) == 1 && (mask >> v & 1) == 1 && dp[v, mask & ~(1 << m)] != int.MaxValue)
                        {
                            dp[m, mask] = Math.Min(dp[m, mask], dp[v, mask & ~(1<<m)] + Graph[m, v]);
                        }
                    }
                }
            }

            int result = int.MaxValue;
            for (int i = 1; i < V; i++)
            {
                if(Graph[0, i] != int.MaxValue && dp[i, max - 1]!=int.MaxValue)
                {
                    result = Math.Min(dp[i, max - 1]+Graph[0, i], result);
                }
            }

            Console.WriteLine(result);
        }
    }
}
