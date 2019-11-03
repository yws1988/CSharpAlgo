namespace Graph.MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using Collection;

    public class Pair:IComparable<Pair>
    {
        public int Des { get; set; }
        public int Weight { get; set; }

        public Pair(int d, int w)
        {
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
        public static List<Pair>[] Graph;

        public static void Set(int n)
        {
            Graph = new List<Pair>[n];
            for (int i = 0; i < n; i++)
            {
                Graph[i] = new List<Pair>();
            }
        }
        
        public static int GetMinimumSpanningTree()
        {
            int minCost = 0;
            bool[] visited = new bool[Graph.Length];
            PriorityQueue<Pair> queue = new PriorityQueue<Pair>();
            foreach (var item in Graph[0])
            {
                queue.Enqueue(item);
            }
            visited[0] = true;
            while (queue.Count()>0)
            {
                var p = queue.Dequeue();
                if (!visited[p.Des])
                {
                   minCost+=p.Weight;
                   visited[p.Des] = true;
                   foreach(var item in Graph[p.Des])
                   {
                        queue.Enqueue(item);
                   }
                }
            }

            return minCost;
        }

        public static void AddEdge(int s, int d, int w)
        {
            Graph[s].Add(new Pair(d, w));
            Graph[d].Add(new Pair(s, w));
        }

        
    }
}
