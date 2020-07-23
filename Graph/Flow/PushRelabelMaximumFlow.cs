namespace CSharpAlgo.Graph.Flow
{
    using System;
    using System.Collections.Generic;

    public class PushRelabelMaximumFlow
    {
        public static int GetMaximunFlow(int[,] rGraph, int s, int d)
        {
            //rGraph is residual graph

            int v = rGraph.GetLength(0);
            var edges = new List<Edge>();

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {

                }
            }
            
            int maxFlow = 0;
            int[] parent = new int[v];
            

            return maxFlow;
        }

        static bool PreFlow(int[,] graph, int s)
        {
           
        }

        struct Vetex
        {
            public int H { get; set; }
            public int ExcessFlow { get; set; }
        }

        struct Edge
        {
            public int U { get; set; }
            public int V { get; set; }
            public int Flow { get; set; }
            
            public Edge(int u, int v, int flow)
            {
                U = u;
                V = v;
                Flow = flow;
            }
        }
    }
}