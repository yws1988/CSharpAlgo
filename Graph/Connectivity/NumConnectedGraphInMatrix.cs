namespace CSharpAlgo.Graph.Connectivity
{
    public class NumConnectedGraphInMatrix
    {
        // Following matrix have 4 connected components
        //{1, 1, 0, 0, 0},
        //{0, 1, 0, 0, 1},
        //{1, 0, 0, 1, 1},
        //{0, 0, 0, 0, 0},
        //{1, 0, 1, 0, 0} 

        public static int GetConnectedGraphNum(int[,] graph)
        {
            int v = graph.GetLength(0);
            bool[,] vs = new bool[v, v];

            int count = 0;

            for (int i = 0; i < v; i++)
            {
                for (int j = 0; j < v; j++)
                {
                    if(graph[i, j]==1 && !vs[i, j])
                    {
                        count++;
                        DFSUtil(graph, i, j, vs, v);
                    }
                }
            }

            return count;
        }

        static void DFSUtil(int[,] graph, int i, int j, bool[,] vs, int v)
        {
            vs[i, j] = true;

            for (int m = -1; m <= 1; m++)
            {
                for (int h = -1; h <= 1; h++)
                {
                    if (m == 0 && h == 0) continue;
                    int tI = i + m;
                    int tJ = j + h;
                    if(IsSafe(tI, tJ, v) && !vs[tI, tJ] && graph[tI, tJ]==1)
                    {
                        DFSUtil(graph, tI, tJ, vs, v);
                    }
                }
            }
        }

        static bool IsSafe(int i, int j, int v)
        {
            return i >= 0 && i < v && j >= 0 && j < v;
        }
    }
}
