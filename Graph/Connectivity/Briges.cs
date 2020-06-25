namespace Graph.Connectivity
{
    using DataStructure.Graph;
    using System;
    using System.Collections.Generic;

    public class Briges
    {
        public static int Step;

        public static List<Edge> GetAllBriges(List<int>[] graph)
        {
            var briges = new List<Edge>();
            Step = 0;
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] parents = new int[v];
            int[] dist = new int[v];
            int[] low = new int[v];
            
            for (int i = 0; i < v; i++)
            {
                parents[i] = -1;
            }

            DFS(0, graph, visited, dist, low, parents, briges);

            return briges;
        }

        public static void DFS(int s, List<int>[] graph, bool[] vs, int[] dist, int[] low, int[] parents, List<Edge> briges)
        {
            vs[s] = true;
            dist[s] = ++Step;
            low[s] = Step;

            int child = 0;
            foreach (var c in graph[s])
            {
                if (!vs[c])
                {
                    child++;
                    parents[c] = s;
                    DFS(c, graph, vs, dist, low, parents, briges);
                    low[s] = Math.Min(low[c], low[s]);

                    if (low[c] > dist[s])
                    {
                        briges.Add(new Edge(s, c));
                    }
                }
                else if (parents[s] != c)
                {
                    low[s] = Math.Min(dist[c], low[s]);
                }
            }
        }

    }
}
