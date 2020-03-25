namespace graph.Connectivity
{
    public class TransitiveClosureGraph
    {
        // Warshall algorithme
        public static bool[,] GetByWarshallMethod(int[,] graph)
        {
            int v = graph.GetLength(0);
            var TransitiveGraph = new bool[v, v];
            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if(graph[i, j] == 1)
                    {
                        TransitiveGraph[i, j] = true;
                    }
                }
            }

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    for (int k = 0; k < v; k++)
                    {
                        TransitiveGraph[j, k] = TransitiveGraph[j, k] || (TransitiveGraph[j, i] && TransitiveGraph[i, k]);
                    }
                }
            }

            return TransitiveGraph;
        }

        // DFS method to get transitive closure graph
        public static bool[,] GetTransitiveClosureGraphByDFS(int[,] graph)
        {
            int v = graph.GetLength(0);
            var transitiveGraph = new bool[v, v];
            for (int i = 0; i < v; i++)
            {
                bool[] vs = new bool[v];
                DFS(i, graph, transitiveGraph, v, vs, i);
            }

            return transitiveGraph;
        }

        static void DFS(int i, int[,] graph, bool[,] transiveGraph, int v, bool[] vs, int src)
        {
            vs[i] = true;
            transiveGraph[src, i] = true;
            for (int j = 0; j < v; j++)
            {
                if (graph[i, j]!=0 && !vs[j])
                {
                    DFS(j, graph, transiveGraph, v, vs, src);
                }
            }
        }
    }
}
