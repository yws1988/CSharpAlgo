namespace CSharpAlgo.Graph.Flow
{
    using System;
    using System.Collections.Generic;

    public class FordFulkersonMaximumFlow
    {
        public static int GetMaximunFlow(int[,] rGraph, int s, int d)
        {
            //rGraph is residual graph

            int v = rGraph.GetLength(0);

            int maxFlow = 0;
            int[] parent = new int[v];
            while (IsReachableByBFS(rGraph, s, d, parent))
            {
                int p = parent[d];
                int c = d;
                int minFlow = rGraph[p, c];
                while (p != s)
                {
                    c = p;
                    p = parent[c];
                    minFlow = Math.Min(minFlow, rGraph[p, c]);
                }

                p = parent[d];
                c = d;
                do
                {
                    rGraph[p, c] -= minFlow;
                    rGraph[c, p] += minFlow;
                    c = p;
                    p = parent[c];
                } while (p != s);

                maxFlow += minFlow;
            }

            return maxFlow;
        }

        static bool IsReachableByBFS(int[,] graph, int s, int d, int[] parent)
        {
            int v = graph.GetLength(0);
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(s);
            bool[] visited = new bool[v];
            visited[s] = true;

            while (queue.Count > 0)
            {
                int p = queue.Dequeue();
                for (int i = 0; i < v; i++)
                {
                    if (!visited[i] && graph[p, i] > 0)
                    {
                        queue.Enqueue(i);
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
    }
}