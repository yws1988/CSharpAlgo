using System;
using System.Collections.Generic;

namespace Graph.ShortestPath
{
    public class WarshallShortestPath
    {
        public static int[,] Path;
        public static int[,] Costs;

        public static int GetShortestPath(int start, int end, int[,] graph)
        {
            int v = graph.GetLength(0);
            Path = new int[v,v];
            Costs = new int[v, v];

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (i != j)
                    {
                        Costs[i, j] = graph[i, j] == 0 ? int.MaxValue : graph[i, j];
                    }

                    if(Costs[i, j] != int.MaxValue)
                    {
                        Path[i, j] = i;
                    }
                    else
                    {
                        Path[i, j] = -1;
                    }
                    
                }
            }

            for (int k = 0; k < v; k++)
            {
                for (int i = 0; i < v; i++)
                {
                    for (int j = 0; j < v; j++)
                    {
                        if(Costs[i, k]!=int.MaxValue && Costs[k, j] != int.MaxValue)
                        {
                            if(Costs[i, j] > Costs[i, k] + Costs[k, j])
                            {
                                Costs[i, j] = Costs[i, k] + Costs[k, j];
                                Path[i, j] = Path[k, j];
                            }
                        }
                    }

                    if(Costs[i, i] < 0)
                    {
                        Console.WriteLine("There is a negative cycle");
                        return 0;
                    }
                }
            }

            PrintPath(start, end);
            return Costs[start, end];
        }

        public static void PrintPath(int start, int end)
        {
            if(Path[start, end] == -1)
            {
                Console.WriteLine("No Path");
                return;
            }

            Stack<int> s = new Stack<int>();
            s.Push(end);
            while(end != start)
            {
                s.Push(Path[start, end]);
                end = Path[start, end];
            }
            foreach(int i in s)
            {
                Console.Write($"{i}=>");
            }
        }
    }
}
