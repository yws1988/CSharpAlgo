namespace CSharpAlgo.Graph.Path.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class WarshallShortestPath
    {
        public static int GetShortestPath(int start, int end, int[,] graph)
        {
            int v = graph.GetLength(0);
            var path = new int[v, v];
            var costs = new int[v, v];

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (i != j)
                    {
                        costs[i, j] = graph[i, j] == 0 ? int.MaxValue : graph[i, j];
                    }

                    if (costs[i, j] != int.MaxValue)
                    {
                        path[i, j] = i;
                    }
                    else
                    {
                        path[i, j] = -1;
                    }
                }
            }

            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        if (costs[i, k] != int.MaxValue && costs[k, j] != int.MaxValue)
                        {
                            if (costs[i, j] > costs[i, k] + costs[k, j])
                            {
                                costs[i, j] = costs[i, k] + costs[k, j];
                                path[i, j] = path[k, j];
                            }
                        }
                    }

                    if (costs[i, i] < 0)
                    {
                        Console.WriteLine("There is a negative cycle");
                        return 0;
                    }
                }
            }

            return costs[start, end];
        }

        public static List<int> GetPath(int start, int end, int[,] path)
        {
            if (path[start, end] == -1)
            {
                Console.WriteLine("No Path");
                return null;
            }

            Stack<int> stack = new Stack<int>();
            stack.Push(end);
            while (end != start)
            {
                stack.Push(path[start, end]);
                end = path[start, end];
            }

            return stack.ToList();
        }
    }
}