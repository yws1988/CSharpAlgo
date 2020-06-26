namespace CSharpAlgo.Graph.Flow
{
    using System.Collections.Generic;

    // based on max-flow min-cut theorem

    public class STMinCutMaximumFlow
    {
        public static List<(int, int)> GetMinCutEdges(int[,] rGraph, int s, int d)
        {
            var graph = (int[,])rGraph.Clone();

            int v = rGraph.GetLength(0);
            FordFulkersonMaximumFlow.GetMaximunFlow(rGraph, s, d);

            bool[] vs = new bool[v];
            Dfs(rGraph, s, vs, v);

            List<int> sVetex = new List<int>();
            List<int> dVetex = new List<int>();

            for (int i = 0; i < v; i++)
            {
                if (vs[i]) sVetex.Add(i);
                else dVetex.Add(i);
            }

            var edges = new List<(int, int)>();
            for (int i = 0; i < sVetex.Count; i++)
            {
                for (int j = 0; j < dVetex.Count; j++)
                {
                    if(graph[sVetex[i], dVetex[j]] != 0)
                    {
                        edges.Add((sVetex[i], dVetex[j]));
                    }
                }
            }

            return edges;
        }

        static void Dfs(int[,] rGraph, int s, bool[] vs, int v)
        {
            vs[s] = true;
            for (int i = 0; i < v; i++)
            {
                if(rGraph[s, i]!=0 && !vs[i])
                {
                    Dfs(rGraph, i, vs, v);
                }
            }
        }
    }
}
