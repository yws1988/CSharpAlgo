namespace Graph.Flow
{
    using System;
    using System.Collections.Generic;

    public class FordFulkersonMaximumFlow
    {
        public static int V;
        
        public static bool BFS(int[,] graph, int s, int d, int[] parent)
        {
            Queue<int> q = new Queue<int>();
            q.Enqueue(s);
            bool[] visited = new bool[V];
            visited[s] = true;

            while (q.Count > 0)
            {
                int p = q.Dequeue();
                for (int i = 0; i < V; i++)
                {
                    if (!visited[i] && graph[p, i]>0)
                    {
                        q.Enqueue(i);
                        visited[i] = true;
                        parent[i] = p;
                        if (i == d)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        public static int GetMaximunFlow(int[,] rGraph, int s, int d)
        {
            //rGraph is residual graph

            V = rGraph.GetLength(0);

            int maxFlow = 0;
            int[] parent = new int[V];
            while (BFS(rGraph, s, d, parent))
            {
                int u = parent[d];
                int v = d;
                int minFlow = rGraph[u, v];
                while (u != s)
                {
                    v = u;
                    u = parent[v];
                    minFlow = Math.Min(minFlow, rGraph[u, v]);
                }

                u = parent[d];
                v = d;
                do
                {
                    rGraph[u, v] -= minFlow;
                    rGraph[v, u] += minFlow;
                    v = u;
                    u = parent[v];
                } while (u != s);

                maxFlow += minFlow;
            }

            return maxFlow;
        }

    }
}
