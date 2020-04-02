namespace Algorithmne.Graph.Graph.Path.LongestPath
{
    //Given a Weighted Directed Acyclic Graph(DAG) and a source vertex s in it,
    //find the longest distances from s to all other vertices in the given graph.

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class LongestPathInDirectedAcyclicGraph
    {
        /// <summary>
        /// Get all the longest path from source s to all the other paths
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s">Source vertex</param>
        /// <returns></returns>
        public static int[] GetLongestPath(List<Node>[] graph, int s, int[] parents = null)
        {
            var stack = new Stack<int>();
            int n = graph.Length;
            TopologicalSorting(graph, stack);
            int[] weights = Enumerable.Range(0, n).Select(i => int.MinValue).ToArray();
            weights[s] = 0;
            parents = Enumerable.Range(0, n).Select(i => -1).ToArray();

            do
            {
                int p = stack.Pop();
                if (weights[p] != int.MinValue)
                {
                    foreach (Node node in graph[p])
                    {
                        if (weights[p] + node.Weight > weights[node.Des])
                        {
                            weights[node.Des] = weights[p] + node.Weight;
                            parents[node.Des] = p;
                        }
                    }
                }
            } while (stack.Count > 0);

            return weights;
        }

        static void TopologicalSorting(List<Node>[] graph, Stack<int> stack)
        {
            int n = graph.Length;
            var vs = new bool[n];
            for (int i = 0; i < n; i++)
            {
                if (!vs[i])
                {
                    TopologicalSortingUtil(graph, i, vs, stack);
                }
            }
        }

        static void TopologicalSortingUtil(List<Node>[] graph, int i, bool[] vs, Stack<int> stack)
        {
            vs[i] = true;

            foreach (Node node in graph[i])
            {
                if (!vs[node.Des])
                {
                    TopologicalSortingUtil(graph, node.Des, vs, stack);
                }
            }

            stack.Push(i);
        }

        public class Node
        {
            public int Des { get; set; }
            public int Weight { get; set; }
        }
    }
}