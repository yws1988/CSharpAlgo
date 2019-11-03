using System;

namespace Graph.Cycle
{
    public class CycleNLengthUnDirectedGraph
    {
        static int[,] Graph;
        static int V;
        static int Num=0;
        static int N;

        public static void Count(int[,] graph, int n)
        {
            Graph = graph;
            V = graph.GetLength(0);
            N = n;
            bool[] vs = new bool[V];
            for (int i = 0; i < V-(n-1); i++)
            {
                DFSUtil(i, vs, n-1, i);
                vs[i] = true;
            }
            
            Console.WriteLine(Num/2);
        }

        static void DFSUtil(int s, bool[] vs, int n, int src)
        {
            if (n == 0)
            {
                if (Graph[s, src] == 1)
                {
                    Num++;
                    return;
                }
                return;
            }

            vs[s] = true;

            for (int i = 0; i < V; i++)
            {
                if(Graph[s, i]==1 && !vs[i])
                {
                    DFSUtil(i, vs, n-1, src);
                }
            }

            vs[s] = false;
        }
    }
}
