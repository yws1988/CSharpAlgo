namespace Graph.Connectivity
{
    using System;
    using System.Collections.Generic;

    public class BiConnected
    {
        public static bool[] Visited;
        public static int[] Parents;
        public static int[] Dist;
        public static int[] Low;
        public static int V;
        public static int Step=1;
        public static Stack<(int, int)> BiComponents;

        public static bool IsBiconnectedGraph(int[,] graph)
        {
            V = graph.GetLength(0);
            Visited = new bool[V];
            Parents = new int[V];
            Dist = new int[V];
            Low = new int[V];
            for (int i = 0; i < V; i++)
            {
                Parents[i] = -1;
            }

            Dist[0] = Step;
            Visited[0] = true;
            return DFS(0, graph);
        }

        public static bool DFS(int s, int[,] graph)
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
                        if (!DFS(i, graph)) return false;
                        Low[s] = Math.Min(Low[i], Low[s]);
                        if (Parents[s] == -1 && child > 1)
                        {
                            return false;
                        }

                        if (Parents[s] != -1 && Low[i] >= Dist[s])
                        {
                            return false;
                        }
                    }
                    else if (Parents[s] != i)
                    {
                        Low[s] = Math.Min(Dist[i], Low[s]);
                    }
                }
            }

            return true;
        }


        public static void PrintBiconnectedComponents(int[,] graph)
        {
            V = graph.GetLength(0);
            Visited = new bool[V];
            Parents = new int[V];
            Dist = new int[V];
            Low = new int[V];
            BiComponents = new Stack<(int, int)>();
            for (int i = 0; i < V; i++)
            {
                Parents[i] = -1;
            }

            Dist[0] = Step;
            Visited[0] = true;
            DFSComponents(0, graph);

            Console.WriteLine("------------------");

            while (BiComponents.Count>0)
            {
                var p = BiComponents.Pop();
                Console.WriteLine($"{p.Item1}=>{p.Item2}");
            }
        }

        public static void DFSComponents(int s, int[,] graph)
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
                        BiComponents.Push((s, i));
                        child++;
                        Parents[i] = s;
                        DFSComponents(i, graph);
                        Low[s] = Math.Min(Low[i], Low[s]);
                        if (Parents[s] == -1 && child > 1)
                        {
                            PrintComponenent(s, i);
                        }

                        if (Parents[s] != -1 && Low[i] >= Dist[s])
                        {
                            PrintComponenent(s, i);
                        }
                    }
                    else if (Parents[s] != i)
                    {
                        if (Dist[s] > Dist[i])
                        {
                            BiComponents.Push((s, i));
                        }

                        Low[s] = Math.Min(Dist[i], Low[s]);
                    }
                }
            }
        }


        static void PrintComponenent(int s, int i)
        {
            Console.WriteLine("-----------------------");
            (int, int) p;
            do
            {
                p = BiComponents.Pop();
                Console.WriteLine($"{p.Item1}=>{p.Item2}");
            } while (s != p.Item1 || i != p.Item2);
        }
    }
}
