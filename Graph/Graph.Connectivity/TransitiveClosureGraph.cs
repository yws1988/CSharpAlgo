namespace Graph.Connectivity
{
    using System;

    public class TransitiveClosureGraph
    {
        public static int V;
        public static bool[,] TransitiveGraph;

        // Warshall algorithme
        public static void PrintWarshallMethod(int[,] graph)
        {
            V = graph.GetLength(0);
            TransitiveGraph = new bool[V, V];
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if(graph[i, j] == 1)
                    {
                        TransitiveGraph[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    for (int k = 0; k < V; k++)
                    {
                        TransitiveGraph[j, k] = TransitiveGraph[j, k] || (TransitiveGraph[j, i] && TransitiveGraph[i, k]);
                    }
                }
            }

            PrintTransitiveMatrix();
        }

        public static void PrintDFSMethod(int[,] graph)
        {
            V = graph.GetLength(0);
            TransitiveGraph = new bool[V, V];
            for (int i = 0; i < V; i++)
            {
                bool[] vs = new bool[V];
                DFS(i, graph, vs, i);
            }

            PrintTransitiveMatrix();
        }

        static void DFS(int i, int[,] graph, bool[] vs, int src)
        {
            vs[i] = true;
            TransitiveGraph[src, i] = true;
            for (int j = 0; j < V; j++)
            {
                if (graph[i, j]!=0 && !vs[j])
                {
                    DFS(j, graph, vs, src);
                }
            }
        }

        static void PrintTransitiveMatrix()
        {
            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    Console.Write(TransitiveGraph[i, j] ? "1 ":"0 ");
                }

                Console.WriteLine();
            }
        }
    }
}
