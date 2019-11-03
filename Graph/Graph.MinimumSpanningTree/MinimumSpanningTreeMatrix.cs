namespace Graph.MinimumSpanningTree
{
    using System;
    using System.Collections.Generic;
    using Collection;

    public class MinimumSpanningTreeMatrix
    {
        public static int[,] G;
        public static int V;
        public static List<Pair> Paths=new List<Pair>();
        
        public static int GetMinimumSpanningTree(int[,] g)
        {
            G = g;
            V = g.GetLength(0);
            
            int minCost = 0;
            bool[] visited = new bool[V];
            PriorityQueue<Pair> queue = new PriorityQueue<Pair>();
            for (int i = 1; i < V; i++)
            {
                if(G[0, i] != 0)
                {
                    queue.Enqueue(new Pair(i, G[0, i], 0));
                }
            }

            visited[0] = true;
            int m = 0;
            while (queue.Count()>0)
            {
                if (m == V-1) break;
                var p = queue.Dequeue();
                Paths.Add(p);
                minCost += p.W;
                int nI = p.I;
                
                for (int i = 0; i < V; i++)
                {
                    if (!visited[nI] && !visited[i] && G[nI, i] != 0)
                    {
                        queue.Enqueue(new Pair(i, G[nI, i], nI));
                    }
                }

                visited[nI] = true;
                m++;
            }

            foreach (var item in Paths)
            {
                Console.WriteLine(item.P + "=>" + item.I);
            }

            return minCost;
        }


        public class Pair : IComparable<Pair>
        {
            public int I { get; set; }
            public int W { get; set; }
            public int P { get; set; }

            public Pair(int i, int w, int p)
            {
                I = i;
                W = w;
                P = p;
            }

            public int CompareTo(Pair other)
            {
                return this.W.CompareTo(other.W);
            }
        }
    }
}
