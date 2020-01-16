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
                if (!vs[i] && DFSUtil(i, vs, graph))
                {
                    return true;
                }
            }
            return false;
        }

        static bool DFSUtil(int i, bool[] vs, List<int>[] graph)
        {
            vs[i] = true;

            foreach (int child in graph[i])
            {
                if (vs[child])
                {
                    return true;
                }

                if (!vs[child] && DFSUtil(child, vs, graph))
                {
                    return true;
                }
            }

            return false;
        }
    }
}
