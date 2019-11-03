namespace Graph.Connectivity
{
    using System.Linq;

    public class IsStronglyConnectedMatrix
    {
        public int[,] Graph { get; set; }
        public int V { get; set; }

        public IsStronglyConnectedMatrix(int[,] graph)
        {
            Graph = graph;
            V = graph.GetLength(0);
        }

        public bool IsSC()
        {
            bool[] vs = new bool[V];

            DFSUtil(Graph, 0, vs);

            if (vs.Any(v => v == false)) return false;

            int[,] TGraph = GetTransposeGraph();

            for (int i = 0; i < V; i++)
            {
                vs[i] = false;
            }

            DFSUtil(TGraph, 0, vs);

            if (vs.Any(v => v == false)) return false;

            return true;
        }

        void DFSUtil(int[,] g, int i, bool[] vs)
        {
            vs[i] = true;

            for (int j = 0; j < V; j++)
            {
                if(!vs[j] && g[i, j] != 0)
                {
                    DFSUtil(g, j, vs);
                }
            }
        }

        int[,] GetTransposeGraph()
        {
            int[,] TGraph = new int[V, V];

            for (int i = 0; i < V; i++)
            {
                for (int j = 0; j < V; j++)
                {
                    if(Graph[i, j] != 0)
                    {
                        TGraph[j, i] = Graph[i, j];
                    }
                }
            }

            return TGraph;
        }
    }
}
