using System;
using System.Collections.Generic;

namespace Graph.ShortestPath
{
    public class MultiStageShortestPath
    {
        public static int[,] Graph;
        public static int V;
        public static int[] Ws;

        // The below implementation assumes that nodes are numbered from 0 to N-1 from first stage (source) 
        //to last stage (destination). We also assume that the input graph is multistage.

        public MultiStageShortestPath(int[,] graph)
        {
            Graph = graph;
            V = Graph.GetLength(1);
            Ws = new int[V];
        }

        public void CalculateShortestPath(int src, int des)
        {
            for (int i = 0; i < V-1; i++)
            {
                Ws[i] = int.MaxValue;
            }

            for (int i = V-2; i >=0; i--)
            {
                for (int j = i; j < V; j++)
                {
                    if (Graph[i, j]!=int.MaxValue && Ws[i]>Graph[i, j]+Ws[j])
                    {
                        Ws[i] = Graph[i, j] + Ws[j];
                    }
                }
            }

            Console.WriteLine(Ws[0]);
        }
    }
}
