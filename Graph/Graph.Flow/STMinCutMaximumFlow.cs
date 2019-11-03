namespace Graph.Flow
{
    using System;
    using System.Collections.Generic;

    public class STMinCutMaximumFlow
    {
        static int V;
        
        public static void PrintMinCut(int[,] rGraph, int s, int d)
        {
            GetMaximunFlow(rGraph, s, d);

            bool[] vs = new bool[V];
            Dfs(rGraph, s, vs);

            List<int> sVetex = new List<int>();
            List<int> dVetex = new List<int>();

            for (int i = 0; i < V; i++)
            {
                if (vs[i]) sVetex.Add(i);
                else dVetex.Add(i);
            }

            for (int i = 0; i < sVetex.Count; i++)
            {
                for (int j = 0; j < dVetex.Count; j++)
                {
                    if(rGraph[sVetex[i], dVetex[j]] != 0)
                    {
                        Console.WriteLine($"{sVetex[i]} => {dVetex[j]}");
                    }
                }
            }
        }

        static void Dfs(int[,] rGraph, int s, bool[] vs)
        {
            vs[s] = true;
            for (int i = 0; i < V; i++)
            {
                if(rGraph[s, i]!=0 && !vs[i])
                {
                    Dfs(rGraph, i, vs);
                }
            }
        }

        static bool BFS(int[,] graph, int s, int d, int[] parent)
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

        static int GetMaximunFlow(int[,] rGraph, int s, int d)
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
