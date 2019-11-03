using System;

namespace Graph.Connectivity
{
    public class NumConnectedGraphInMatrix
    {
        public static int[,] Graph { get; set; }
        public static int V { get; set; }

        public static void PrintConnectedGraphNum(int[,] graph)
        {
            Graph = graph;
            V = graph.GetLength(0);

            bool[,] vs = new bool[V, V];

            int count = 0;

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if(graph[i, j]==1 && !vs[i, j])
                    {
                        count++;
                        DFSUtil(i, j, vs);
                    }
                }
            }

            Console.WriteLine($"Connected Graph Num {count}");
        }

        static void DFSUtil(int i, int j, bool[,] vs)
        {
            vs[i, j] = true;

            for (int m = -1; m <= 1; m++)
            {
                for (int h = -1; h <= 1; h++)
                {
                    if (m == 0 && h == 0) continue;
                    int tI = i + m;
                    int tJ = j + h;
                    if(IsSafe(tI, tJ) && !vs[tI, tJ] && Graph[tI, tJ]==1)
                    {
                        DFSUtil(tI, tJ, vs);
                    }
                }
            }
        }

        static bool IsSafe(int i, int j)
        {
            return i >= 0 && i < V && j >= 0 && j < V;
        }
    }
}
