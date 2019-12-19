namespace Utils.Graph.Helper
{
    public class GraphMatrixHelper
    {
        public static int[,] GetTransposeGraph(int[,] graph)
        {
            int n = graph.GetLength(0);

            var rGraph = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    rGraph[i, j] = graph[j, i];
                }
            }

            return rGraph;
        }
    }
}
