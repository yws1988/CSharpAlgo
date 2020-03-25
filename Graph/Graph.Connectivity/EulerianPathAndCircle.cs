namespace graph.Connectivity
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class EulerianPathAndCircle
    {
        public static bool IsEulerianPathAndCircle(List<int>[] graph)
        {
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] degrees = graph.Select(s => s.Count).ToArray();

            int src = -1;
            for (int i = 0; i < v; i++)
            {
                if (degrees[i] == 0)
                {
                    visited[i] = true;
                }
                else
                {
                    src = i;
                }
            }

            //Eulerian Path no edges
            if (src == -1)
            {
                return true;
            }

            DFS(src, graph, visited);

            if(visited.Any(s => !s))
            {
                Console.WriteLine("No Eulerian Path");
                return false;
            }

            int evenNum = degrees.Count(s => s % 2==0);

            //Eulerian Circle
            if (evenNum == v)
            {
                return true;
            }

            // Eulerian Path
            if (evenNum == v-2)
            {
                int start = degrees.Select((s, i) => new { S = s, I = i }).Where(s => s.S % 2 == 1).First().I;
                return true;
            }

            return false;
        }

        static void DFS(int s, List<int>[] graph, bool[] vs)
        {
            vs[s] = true;
            foreach (var c in graph[s])
            {
                if (!vs[c])
                {
                    DFS(c, graph, vs);
                }
            }
        }
    }
}
