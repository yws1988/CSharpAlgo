using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Connectivity
{
    public class ArticulationPoints
    {
        public static bool[] Visited;
        public static int[] Parents;
        public static int[] Dist;
        public static int[] Low;
        public static int V;
        public static int Step=0;
        public static bool[] Ap;

        public static void PrintAP(int[,] graph)
        {
            V = graph.GetLength(0);
            Visited = new bool[V];
            Parents = new int[V];
            Dist = new int[V];
            Low = new int[V];
            Ap = new bool[V];
            for (int i = 0; i < V; i++)
            {
                Parents[i] = -1;
            }

            DFS(0, graph);

            for (int i = 0; i < V; i++)
            {
                Console.Write(Dist[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < V; i++)
            {
                Console.Write(Low[i] + " ");
            }

            Console.WriteLine();

            for (int i = 0; i < V; i++)
            {
                Console.Write(Ap[i] + " ");
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
                        if (Parents[s] == -1 && child > 1)
                        {
                            Ap[s] = true;
                        }

                        if (Parents[s] != -1 && Low[i]>= Dist[s])
                        {
                            Ap[s] = true;
                        }
                    }
                    else if(Parents[s]!=i)
                    {
                        Low[s] = Math.Min(Dist[i], Low[s]);
                    }
                }     
            }
        }

        public static void DfsStack(int root, List<int>[] graph)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var p = stack.Pop();
                if (Visited[p])
                {
                    p = stack.Pop();

                    foreach (var c in graph[p])
                    {
                        if (c != Parents[p])
                        {
                            Low[p] = Math.Min(Low[c], Low[p]);
                        }
                    }

                    if (Parents[p] == root && stack.Any(s => !Visited[s]))
                    {
                        Ap[root] = true;
                    }

                    if (Parents[p] != -1 && Low[p] >= Dist[p])
                    {
                        Ap[p] = true;
                    }
                }
                else
                {
                    Visited[p] = true;
                    Dist[p] = ++Step;
                    Low[p] = Step;

                    foreach (var c in graph[p])
                    {
                        if (!Visited[c])
                        {
                            stack.Push(c);
                            Parents[c] = p;
                        }
                    }
                }
            }
        }

    }
}
