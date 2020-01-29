namespace Algorithmne.Graph.Graph.Path.LongestPath
{
    //Given a Weighted Directed Acyclic Graph(DAG) and a source vertex s in it,
    //find the longest distances from s to all other vertices in the given graph.

    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Node
    {
        public int Num { get; set; }
        public int Weight { get; set; }
    }

    public class LongestPathInDirectedAcyclicGraph
    {
        public const int INFI = int.MinValue;
        public int WeightMax = int.MinValue;

        /// <summary>
        /// Get all the longest path from source s to all the other paths
        /// </summary>
        /// <param name="graph"></param>
        /// <param name="s">Source vertex</param>
        /// <returns></returns>
        public static int[] CalculateLongestPathWithTopologicalOrder(List<Node>[] graph, int s)
        {
            var stack = new Stack<int>();
            int n = graph.Length;
            StartTopologicalSorting(graph, stack);
            int[] weights = Enumerable.Range(0, n).Select(i => INFI).ToArray();
            weights[s] = 0;

            do
            {
                int numVertix = stack.Pop();
                if (weights[numVertix] != INFI)
                {
                    foreach (Node node in graph[numVertix])
                    {
                        if (weights[numVertix] + node.Weight > weights[node.Num])
                        {
                            weights[node.Num] = weights[numVertix] + node.Weight;           
                        }
                    }
                }
            } while (stack.Count > 0);

            List<int> longestPath = new List<int>();
            for (int i = 1; i < weights.Length; i++)
            {
                if (weights[i] != INFI && weights[i]>weights[i-1])
                {
                    longestPath.Add(i);
                } 
            }

            return weights;
        }

        static void StartTopologicalSorting(List<Node>[] graph, Stack<int> stack)
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
                if (!vs[node.Num])
                {
                    TopologicalSortingUtil(graph, node.Num, vs, stack);
                }
            }

            stack.Push(i);
        }
    }
}
