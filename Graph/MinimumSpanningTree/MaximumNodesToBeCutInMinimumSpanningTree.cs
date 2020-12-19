/*
 * Get the maximum number of node separating from the tree after cutting one edge from spanning tree.
 * Take the minimum values of two parts.
 */
namespace CSharpAlgo.Graph.MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;


    public class MaximumNodesToBeCutInMinimumSpanningTree
    {
        public static int GetMinimumNode(List<int>[] graph)
        {
            int n = graph.Length;
            var numOfNodes = new int[n];
            var degrees = new int[n];
            var queue = new Queue<int>();

            for (int i = 0; i < n; i++)
            {
                var degree = g[i].Count;
                numOfNodes[i] = 1;

                if (degree == 1)
                {
                    queue.Enqueue(i);
                }

                degrees[i] = graph[i].Count;
            }

            int record = 0;

            while (queue.Count > 0)
            {
                var node = queue.Dequeue();
                int number = Math.Min(numOfNodes[node], n - numOfNodes[node]);
                record = Math.Max(number, record);
                degrees[node]--;

                foreach (var cnode in graph[node])
                {
                    if (degrees[cnode] > 1)
                    {
                        numOfNodes[cnode] += numOfNodes[node];
                        degrees[cnode]--;

                        if (degrees[cnode] == 1)
                        {
                            queue.Enqueue(cnode);
                        }
                    }
                }
            }

            return record;
        }
    }
}
