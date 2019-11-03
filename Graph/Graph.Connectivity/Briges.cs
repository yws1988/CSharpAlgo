using System;
using System.Collections.Generic;

namespace Graph.Connectivity
{
    public class Briges
    {
        public static bool[] Visited;
        public static int[] Parents;
        public static int[] Dist;
        public static int[] Low;
        public static int V;
        public static int Step=1;
        public static List<(int, int)> Bs;

        public static void PrintBriges(int[,] graph)
        {
            V = graph.GetLength(0);
            Visited = new bool[V];
            Parents = new int[V];
            Dist = new int[V];
            Low = new int[V];
            Bs = new List<(int, int)>();

            for (int i = 0; i < V; i++)
            {
                Parents[i] = -1;
            }

            DFS(0, graph);

            Console.WriteLine("All briges : ");
            foreach (var item in Bs)
            {
                Console.WriteLine(item.Item1+" : "+item.Item2);
            }
        }

        public static void DFS(int s, int[,] graph)
        {
            Visited[s] = true;
            Dist[s] = ++Step;
            Low[s] = Step;

            int child = 0;
            for (int i = 0; i < V; i++)
            {
                if (graph[s, i] == 1)
                {
                    if (!Visited[i])
                    {
                        child++;
                        Parents[i] = s;
                        DFS(i, graph);
                        Low[s] = Math.Min(Low[i], Low[s]);

                        if (Low[i] > Dist[s])
                        {
                            Bs.Add((s, i));
                        }
                    }
                    else if (Parents[s] != i)
                    {
                        Low[s] = Math.Min(Dist[i], Low[s]);
                    }
                }
            }
        }

    }
}
