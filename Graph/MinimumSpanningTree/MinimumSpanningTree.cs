namespace CSharpAlgo.Graph.MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using DataStructure.Heap;

    public class Pair : IComparable<Pair>
    {
        public int Src { get; set; }
        public int Des { get; set; }
        public int Weight { get; set; }

        public Pair(int s, int d, int w)
        {
            Src = s;
            Des = d;
            Weight = w;
        }

        public int CompareTo(Pair other)
        {
            return this.Weight.CompareTo(other.Weight);
        }
    }

    public class MinimumSpanningTree
    {
        public static int GetMinimumSpanningTree(List<Pair>[] graph, List<Pair> path)
        {
            path = new List<Pair>();
            int v = graph.Length;
            int minCost = 0;
            bool[] visited = new bool[v];

            var queue = new PriorityQueue<Pair>();
            foreach (var item in graph[0])
            {
                queue.Enqueue(item);
            }
            visited[0] = true;
            while (queue.Count() > 0)
            {
                var p = queue.Dequeue();
                path.Add(p);

                if (!visited[p.Des])
                {
                    minCost += p.Weight;
                    visited[p.Des] = true;
                    foreach (var item in graph[p.Des])
                    {
                        queue.Enqueue(item);
                    }
                }
            }

            return minCost;
        }

        public static void InitialGraphWithOneEdge(int n, int s, int d, int w)
        {
            var graph = Enumerable.Range(0, n).Select(e => new List<Pair>()).ToArray();

            graph[s].Add(new Pair(s, d, w));
            graph[d].Add(new Pair(d, s, w));
        }
    }
}
