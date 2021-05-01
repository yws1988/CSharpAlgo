/*
 Given a graph with n vetex, the cost between vetex u and v is costs[u, v],
 if costs[u, v] is 0, it means it is impossible to establish a connection between u and v.
 Give a edge (s, d), check if this edge is in the minimum spanning tree of this graph.
 */
namespace CSharpAlgo.Graph.MinimumSpanningTree
{
    using System.Collections.Generic;

    public class EdgeBelongsToMinimumSpanningTree
    {
        public static bool IsEdgeInMST(int s, int d, List<int>[] graph, int[,] costs)
        {
            int n = graph.Length;
            var vs = new bool[n];
            return costs[s, d] != 0 && Dfs(s, costs[s, d], vs, d, costs, graph);
        }

        static bool Dfs(int u, int cost, bool[] vs, int des, int[,] costs, List<int>[] graph)
        {
            vs[u] = true;
            if (u == des)
            {
                return false;
            }

            foreach (var c in graph[u])
            {
                if (!vs[c] && costs[u, c] < cost)
                {
                    if (!Dfs(c, cost, vs, des, costs, graph))
                    {
                        return false;
                    }
                }
            }

            return true;
        }
    }
}
