using System;
using System.Collections.Generic;

namespace Graph.ShortestPath
{
    public class BellmanFordShortestPath
    {
        public static int[,] Graph;
        public static int V;
        public static List<Edge> Edges=new List<Edge>();
        public static int[] Parents;
        public static int[] Weights;

        // Doesn't contain negative cycle
        public BellmanFordShortestPath(int[,] graph)
        {
            Graph = graph;
            V = Graph.GetLength(0);
            Parents = new int[V];
            Weights = new int[V];
        }

        public void CalculateShortestPath(int src)
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if (Graph[i, j] != 0)
                    {
                        Edges.Add(new Edge(i, j, Graph[i, j]));
                    }
                }
            }
            for (int i = 0; i < V; i++)
            {
                if (i == src)
                {
                    Weights[i] = 0;
                }
                else
                {
                    Weights[i] = int.MaxValue;
                }
            }
            
            Calculate(src);

            PrintShortestPathForEveryNode(src);
        }

        static void Calculate(int src)
        {
            for (int i = 1; i < V; i++)
            {
                foreach (var e in Edges)
                {
                    if (Weights[e.Src] != int.MaxValue && Weights[e.Des] > Weights[e.Src] + e.Weight)
                    {
                        Weights[e.Des] = Weights[e.Src] + e.Weight;
                        Parents[e.Des] = e.Src;
                    }
                }
            }
        }

        void PrintShortestPathForEveryNode(int src)
        {
            Stack<int> path = new Stack<int>();
            for (int i = 0; i < Weights.Length; i++)
            {
                Console.WriteLine($"Node {i}, shortest weight {Weights[i]}");
                int p = i;
                path.Push(p);
                do
                {
                    path.Push(Parents[p]);
                    p = Parents[p];
                } while (p != src);

                while (path.Count>0)
                {
                    Console.Write(path.Pop() + " => ");
                }
                Console.WriteLine();
            }
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
