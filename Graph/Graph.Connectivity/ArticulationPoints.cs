using System;
using System.Collections.Generic;
using System.Linq;

namespace Graph.Connectivity
{
    public class ArticulationPoints
    {
        public static int Step;

        public static bool[] GetAllArticulationPoints(List<int>[] graph)
        {
            Step = 0;
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] parents = new int[v];
            int[] dist = new int[v];
            int[] low = new int[v];
            bool[] isArticulationPoints = new bool[v];
            for (int i = 0; i < v; i++)
            {
                parents[i] = -1;
            }

            DFS(0, graph, visited, dist, low, parents, isArticulationPoints);

            return isArticulationPoints;
        }

        public static void DFS(int s, List<int>[] graph, bool[] vs, int[] dist, int[] low, int[] parents, bool[] isArticulationPoints)
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
                    DFS(c, graph, vs, dist, low, parents, isArticulationPoints);
                    low[s] = Math.Min(low[c], low[s]);
                    if (parents[s] == -1 && child > 1)
                    {
                        isArticulationPoints[s] = true;
                    }

                    if (parents[s] != -1 && low[c] >= dist[s])
                    {
                        isArticulationPoints[s] = true;
                    }
                }
                else if (parents[s] != c)
                {
                    low[s] = Math.Min(dist[c], low[s]);
                }
            }
        }

        public static bool[] GetAllArticulationPointsWithStack(List<int>[] graph)
        {
            Step = 0;
            int v = graph.Length;
            bool[] visited = new bool[v];
            int[] parents = new int[v];
            int[] dist = new int[v];
            int[] low = new int[v];
            bool[] isArticulationPoints = new bool[v];
            for (int i = 0; i < v; i++)
            {
                parents[i] = -1;
            }

            DfsWithStack(0, graph, visited, dist, low, parents, isArticulationPoints);

            return isArticulationPoints;
        }

        public static void DfsWithStack(int root, List<int>[] graph, bool[] visited, int[] dist, int[] low, int[] parents, bool[] isArticulationPoints)
        {
            Stack<int> stack = new Stack<int>();
            stack.Push(root);

            while (stack.Count > 0)
            {
                var p = stack.Peek();

                if (!visited[p])
                {
                    visited[p] = true;
                    dist[p] = ++Step;
                    low[p] = Step;
                }

                bool isPop = true;

                foreach (var c in graph[p])
                {
                    if (!visited[c])
                    {
                        isPop = false;
                        stack.Push(c);
                        parents[c] = p;
                    }
                }

                if (isPop)
                {
                    p = stack.Pop();
                    int child = 0;
                    foreach (var c in graph[p])
                    {
                        if (c!=parents[c])
                        {
                            child++;
                            low[p] = Math.Min(dist[c], low[p]);
                        }
                    }

                    if(p == root && child > 1)
                    {
                        isArticulationPoints[p] = true;
                    }

                    if(p != root && child > 0 && low[p]>=dist[p])
                    {
                        isArticulationPoints[p] = true;
                    }
                }
            }
        }

    }
}
