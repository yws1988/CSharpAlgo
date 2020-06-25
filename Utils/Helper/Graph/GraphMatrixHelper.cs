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

        /// <summary>
        /// Get the vertex which contains the most common neighbours of the
        /// specified vertex
        /// </summary>
        /// <param name="graph">matrix graph with n vertex</param>
        /// <param name="vertex">the specified Vertex</param>
        /// <returns>index of the vertex, the number of the common neighbours</returns>
        public static (int, int) GetVertexWithMaxNumberOfCommonNeighbours(int[,] graph, int vertex)
        {
            int n = graph.GetLength(0);
            int max = 0;
            int idx = -1;

            for (int vd = 0; vd < n; vd++)
            {
                if (vertex != vd)
                {
                    int num = 0;
                    for (int j = 0; j < n; j++)
                    {
                        if (j != vertex && j != vd && graph[vertex, j] == 1 && graph[vd, j] == 1)
                        {
                            num++;
                        }
                    }

                    if (num >= max)
                    {
                        idx = vd;
                        max = num;
                    }
                }
            }

            return (idx, max);
        }
    }
}
