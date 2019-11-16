namespace Graph.Connectivity
{
    using DataStructure.Models;
    using System;
    using System.Collections.Generic;

    public class BiConnected
    {
        public static int Step;

        public static bool IsGraphBiConnected(List<int>[] graph)
        {
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

            return DFS(0, graph, visited, dist, low, parents);
        }

        public static bool DFS(int s, List<int>[] graph, bool[] vs, int[] dist, int[] low, int[] parents)
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
                    if (!DFS(c, graph, vs, dist, low, parents)) return false;
                    low[s] = Math.Min(low[c], low[s]);
                    if (parents[s] == -1 && child > 1)
                    {
                        return false;
                    }

                    if (parents[s] != -1 && low[c] >= dist[s])
                    {
                        return false;
                    }
                }
                else if (parents[s] != c)
                {
                    low[s] = Math.Min(dist[c], low[s]);
                }
            }

            return true;
        }

        static List<List<Edge>> BiConnectedCompenents = new List<List<Edge>>();
        public static void GetBiconnectedComponents(List<int>[] graph)
        {
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
            var edges = new Stack<Edge>();

            DFSComponents(edges, 0, graph, visited, dist, low, parents);
        }

        public static void PushComponent(int s, int d, Stack<Edge> edges)
        {
            List<Edge> biComponents = new List<Edge>();

            Edge edge;
            do
            {
                edge= edges.Pop();
                biComponents.Add(edge);
            } while (s != edge.Src || d != edge.Des);

            BiConnectedCompenents.Add(biComponents);
        }

        public static void DFSComponents(Stack<Edge> edges, int s, List<int>[] graph, bool[] visited, int[] dist, int[] low, int[] parents)
        {
            visited[s] = true;
            dist[s] = ++Step;
            low[s] = Step;

            int child = 0;
            foreach (var c in graph[s])
            {
                if (!visited[c])
                {
                    child++;
                    parents[c] = s;
                    edges.Push(new Edge(s, c));
                    DFSComponents(edges, c, graph, visited, dist, low, parents);
                    low[s] = Math.Min(low[c], low[s]);
                    if (parents[s] == -1 && child > 1)
                    {
                        PushComponent(s, c, edges);
                    }

                    if (parents[s] != -1 && low[c] >= dist[s])
                    {
                        PushComponent(s, c, edges);
                    }
                }
                else if (parents[s] != c)
                {
                    if (dist[s] < dist[c])
                    {
                        edges.Push(new Edge(s, c));
                    }

                    low[s] = Math.Min(dist[c], low[s]);
                }
            }
        }
    }
}
