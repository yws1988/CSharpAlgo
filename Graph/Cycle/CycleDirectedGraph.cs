namespace Graph.Cycle
{
    using System.Collections.Generic;

    public class CycleDirectedGraph
    {
        public static bool DoesGraphContainsCycle(List<int>[] graph)
        {
            int v = graph.Length;
            bool[] vs = new bool[v];

            for (int i = 0; i < v; i++)
            {
                
                if (!vs[i])
                {
                    bool[] currentVs = new bool[v];
                    vs.CopyTo(currentVs, 0);

                    if(DFSUtil(i, vs, currentVs, graph))
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        static bool DFSUtil(int i, bool[] vs, bool[] currentVs, List<int>[] graph)
        {
            vs[i] = true;

            foreach (int child in graph[i])
            {
                if (vs[child] && !currentVs[child])
                {
                    return true;
                }

                if (!vs[child] && DFSUtil(child, vs, currentVs, graph))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
