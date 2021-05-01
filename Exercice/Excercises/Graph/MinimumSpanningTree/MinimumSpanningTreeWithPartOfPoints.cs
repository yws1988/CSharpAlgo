/*
 * Give a graph two dimension matrix, graph[u, v] represents the cost between vertex u and v.
 * Output the minimum cost of all the first k vertex in the graph.
 */

namespace CSharpAlgo.Excercise.Excercises.Graph.MinimumSpanningTree
{
    using System.Collections.Generic;
    using System.Linq;
    using CSharpAlgo.Graph.MinimumSpanningTree;
    using CSharpAlgo.Graph.Path.ShortestPath;

    public class MinimumSpanningTreeWithPartOfPoints
    {
        public static int GetMinimumCost(int[,] graph, int k)
        {
            var costs = WarshallShortestPath.GetShortestCostsAndPath(graph).Item1;

            var newGraph = Enumerable.Range(0, k).Select(e => new List<Pair>()).ToArray();

            for (int a = 0; a < k; a++)
            {
                for (int b = a + 1; b < k; b++)
                {
                    newGraph[a].Add(new Pair(a, b, costs[a, b]));
                    newGraph[b].Add(new Pair(b, a, costs[a, b]));
                }
            }

            List<Pair> path;
            return MinimumSpanningTree.GetMinimumSpanningTree(newGraph, out path);
        }
    }
}
