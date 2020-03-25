namespace graph.Connectivity
{
    using System.Collections.Generic;
    using System.Linq;
    using Utils.Graph.Helper;

    public class StronglyConnectedGraph
    {
        public bool IsStronglyConnected(List<int>[] graph)
        {
            int v = graph.Length;
            bool[] vs = new bool[v];

            DFSUtil(graph, 0, vs);

            if (vs.Any(s => !s)) return false;

            var tGraph = GraphListHelper.GetTransposeGraph(graph);

            for (int i = 0; i < v; i++)
            {
                vs[i] = false;
            }

            DFSUtil(tGraph, 0, vs);

            if (vs.Any(s => !s)) return false;

            return true;
        }

        void DFSUtil(List<int>[] g, int i, bool[] vs)
        {
            vs[i] = true;

            foreach (var c in g[i])
            {
                if (!vs[c])
                {
                    DFSUtil(g, c, vs);
                }
            }
        }
    }
}
