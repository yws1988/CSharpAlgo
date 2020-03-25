namespace graph.ShortestPath
{
    using System;

    public class TravellingSalesmanTravelling
    {
        public static void GetShortestPath(int[,] graph)
        {
            int v = graph.GetLength(0);
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if(graph[i, j] == 0)
                    {
                        graph[i, j] = int.MaxValue;
                    }
                }
            }

            int max = (int)Math.Pow(2, v);
            int[,] dp = new int[v,(int)Math.Pow(2, v)];

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < max; j++)
                {
                    dp[i, j] = int.MaxValue;
                }
            }

            for (int i = 1; i < v; i++)
            {
                if(graph[i, 0] != int.MaxValue)
                {
                    dp[i, 1 | (1 << i)] = graph[i, 0];
                }
            }

            for (int mask = 1; mask < max; mask++)
            {
                for (int m = 1; m < v; m++)
                {
                    for (int v = 1; v < v; v++)
                    {
                        if (Graph[m, v]!=int.MaxValue && (mask >> m & 1) == 1 && (mask >> v & 1) == 1 && dp[v, mask & ~(1 << m)] != int.MaxValue)
                        {
                            dp[m, mask] = Math.Min(dp[m, mask], dp[v, mask & ~(1<< m)] + Graph[m, v]);
                        }
                    }
                }
            }

            int result = int.MaxValue;
            for (int i = 1; i < v; i++)
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
