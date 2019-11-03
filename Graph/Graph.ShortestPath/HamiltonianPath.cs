using System;
using System.Collections.Generic;
using Collection;

namespace Graph.ShortestPath
{
    public class HamiltonianPath
    {
        public static int[,] Graph { get; set; }
        public static int V { get; set; }
        public static int[] Ps;
        public static int Src;
        public static bool Found = false;

        public static void GetPath(int[,] graph)
        {
            Graph = graph;
            V = Graph.GetLength(0);
            Ps = new int[V];

            for (int i = 0; i < V; i++)
            {
                bool[] vs = new bool[V];
                int[] ps = new int[V];
                for (int h = 0; h< V; h++)
                {
                    ps[h] = -1;
                }
                vs[i] = true;
                if (DfsPathUntil(vs, i, 1, ps))
                {
                    Found = true;
                    ps.CopyTo(Ps, 0);
                    Src = i;
                    break;
                }
            }

            if (Found)
            {
                int t = Src;
                Console.Write(t);
                while (Ps[t] != -1)
                {
                    Console.Write("=>" + Ps[t]);
                    t = Ps[t];
                }

            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public static bool DfsPathUntil(bool[] vs, int src, int level, int[] ps)
        {
            if (level == V) return true;

            for (int i = 0; i < V; i++)
            {
                if (!vs[i] && Graph[src, i] == 1)
                {
                    vs[i] = true;
                    ps[src] = i;
                    if (DfsPathUntil(vs, i, level + 1, ps))
                    {
                        return true;
                    }
                    vs[i] = false;
                    ps[src] = -1;
                }
            }

            return false;
        }

        public static void GetCircle(int[,] graph)
        {
            Graph = graph;
            V = Graph.GetLength(0);
            Ps = new int[V];

            bool[] vs = new bool[V];
            for (int h = 0; h < V; h++)
            {
                Ps[h] = -1;
            }
            vs[0] = true;
            if (DfsCircleUtil(vs, 0, 1, Ps))
            {
                Found = true;
                Src = 0;
            }

            if (Found)
            {
                int t = Src;
                Console.Write(t);
                while (Ps[t] != -1)
                {
                    Console.Write("=>" + Ps[t]);
                    t = Ps[t];
                }

            }
            else
            {
                Console.WriteLine("no");
            }
        }

        public static bool DfsCircleUtil(bool[] vs, int src, int level, int[] ps)
        {
            if (level == V && Graph[src, Src] == 1) return true;

            for (int i = 0; i < V; i++)
            {
                if (!vs[i] && Graph[src, i] == 1)
                {
                    vs[i] = true;
                    ps[src] = i;
                    if (DfsCircleUtil(vs, i, level + 1, ps))
                    {
                        return true;
                    }
                    vs[i] = false;
                    ps[src] = -1;
                }
            }

            return false;
        }
    }
}
