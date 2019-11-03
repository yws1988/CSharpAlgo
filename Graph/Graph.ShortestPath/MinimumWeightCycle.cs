namespace Graph.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Collection;

    public class MinimumWeightCycle
    {
        public static int V;
        public static List<(int, int)> Edges=new List<(int, int)>();

        public static void PrintShortestWeightCycle(int[,] graph)
        {
            V = graph.GetLength(0);
            int result = int.MaxValue;
            for (int i = 0; i < V; i++)
            {
                for (int j = i+1; j < V; j++)
                {
                    if (graph[i, j] > 0)
                    {
                        int temp = graph[i, j];
                        graph[i, j] = 0;
                        result=Math.Min(result, DijkastraShortest(graph, i, j)+temp);
                        graph[i, j] = temp;
                    }
                }
            }

            Console.WriteLine(result);
        }

        static int DijkastraShortest(int[,] g, int src, int des)
        {
            bool[] vs = new bool[V];
            int[] ws = new int[V];
            for (int i = 0; i < V; i++)
            {
                ws[i] = int.MaxValue;
            }

            ws[src] = 0;

            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node(0, src));    

            while (pq.Count() > 0)
            {
                var node = pq.Dequeue();
                int s = node.Index;
                if (des == s) return ws[des];
                if (vs[s]) continue;
                vs[s] = true;

                for (int i = 0; i < V; i++)
                {
                    if (!vs[i] && g[s, i] > 0)
                    {
                        if (ws[i] > ws[s] + g[s, i])
                        {
                            ws[i] = ws[s] + g[s, i];
                        }

                        pq.Enqueue(new Node(ws[i], i));
                    }
                }
            }

            return ws[des];
        }

        public class Node : IComparable<Node>
        {
            public int Weight { get; set; }

            public int Index { get; set; }

            public Node(int weight, int index)
            {
                Weight = weight;
                Index = index;
            }

            public int CompareTo(Node other)
            {
                return this.Weight.CompareTo(other.Weight);
            }
        }
    }
}
