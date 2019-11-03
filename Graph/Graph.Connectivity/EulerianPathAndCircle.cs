namespace Graph.Connectivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class EulerianPathAndCircle
    {
        public static bool[] Visited;
        public static int V;
        public static int[] degrees;

        public static void IsCircleOrPath(int[,] graph)
        {
            V = graph.GetLength(0);
            Visited = new bool[V];
            degrees = new int[V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if(i!=j && graph[i, j] != 0)
                    {
                        degrees[i]++;
                    }
                }
            }

            int src = -1;
            for (int i = 0; i < V; i++)
            {
                if (degrees[i] == 0)
                {
                    Visited[i] = true;
                }
                else
                {
                    src = i;
                }
            }

            if (src == -1)
            {
                Console.WriteLine("Eulerian Path no edges");
                return;
            }

            DFS(src, graph);

            if(Visited.Any(s => s == false))
            {
                Console.WriteLine("No Eulerian Path");
                return;
            }

            int evenNum = degrees.Where(s => s%2==0).Count();

            if(evenNum == V)
            {
                Console.WriteLine("Eulerian Circle");
                PrintPath(graph, 0);
                return;
            }

            if (evenNum == V-2)
            {
                Console.WriteLine("Eulerian Path");
                int start = degrees.Select((s, i) => new { S = s, I = i }).Where(s => s.S % 2 == 1).First().I;
                PrintPath(graph, start);
                return;
            }
        }

        static void DFS(int s, int[,] graph)
        {
            Visited[s] = true;
            for (int i = 0; i < V; i++)
            {
                if(graph[s, i]!=0 && !Visited[i])
                {
                    DFS(i, graph);
                }
            }
        }

        static void PrintPath(int[,] graph, int src)
        {
            int[,] newG = new int[V, V];
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    newG[i, j] = graph[i, j];
                }
            }

            Stack<int> stack = new Stack<int>();
            List<int> path = new List<int>();
            stack.Push(src);

            while (stack.Count() > 0)
            {
                while (degrees[src] == 0 && stack.Count()>0)
                {
                    src = stack.Pop();
                    path.Add(src);
                }

                for (int i = 0; i < V; i++)
                {
                    if(newG[src, i] == 1)
                    {
                        stack.Push(i);
                        newG[src, i] = 0;
                        newG[i, src] = 0;
                        degrees[src]--;
                        degrees[i]--;
                        src = i;
                        break;
                    }
                }
            }

            Console.WriteLine(string.Join("=>", path));
        }
    }
}
