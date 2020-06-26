namespace CSharpAlgo.Graph.Path.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class BellmanFordShortestPath
    {
        public int[] GetShortestPath(int[,] graph, int src)
        {
            int v = graph.GetLength(0);
            var edges = new List<Edge>();
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if (graph[i, j] != 0)
                    {
                        edges.Add(new Edge(i, j, graph[i, j]));
                    }
                }
            }

            var weights = new int[v];
            var parents = new int[v];

            for (int i = 0; i < v; i++)
            {
                if (i == src)
                {
                    weights[i] = 0;
                }
                else
                {
                    weights[i] = int.MaxValue;
                }
            }

            Calculate(v, weights, parents, edges);

            if (ContainsNegativeCycle(weights, edges))
            {
                Console.WriteLine("Graph contains negative cycle");
            }

            return weights;
        }

        static void Calculate(int v, int[] weights, int[] parents, List<Edge> edges)
        {
            for (int i = 1; i < v; i++)
            {
                foreach (var e in edges)
                {
                    if (weights[e.Src] != int.MaxValue && weights[e.Des] > weights[e.Src] + e.Weight)
                    {
                        weights[e.Des] = weights[e.Src] + e.Weight;
                        parents[e.Des] = e.Src;
                    }
                }
            }
        }

        public static bool ContainsNegativeCycle(int[] weights, List<Edge> edges)
        {
            foreach (var edge in edges)
            {
                if (weights[edge.Des] > weights[edge.Src] + edge.Weight)
                {
                    return true;
                }
            }

            return false;
        }

        public List<int> GetShortestPathForEveryNode(int src, int des, int[] parents)
        {
            Stack<int> path = new Stack<int>();

            int p = des;
            path.Push(p);
            do
            {
                path.Push(parents[p]);
                p = parents[p];
            } while (p != src);

            return path.ToList();
        }

        public class Edge
        {
            public int Src { get; set; }
            public int Des { get; set; }
            public int Weight { get; set; }

            public Edge(int s, int d, int w)
            {
                Src = s;
                Des = d;
                Weight = w;
            }
        }
    }
}