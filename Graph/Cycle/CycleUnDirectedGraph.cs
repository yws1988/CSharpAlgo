namespace CSharpAlgo.Graph.Cycle
{
    using System.Collections.Generic;

    public class CycleUnDirectedGraph
    {
        public static bool DoesGraphContainCycle(List<int>[] graph)
        {
            int v = graph.Length;

            bool[] vs = new bool[v];

            for (int i = 0; i < v; i++)
            {
                if (!vs[i] && DFSUtilDetectCycle(i, i, vs, graph))
                {
                    return true;
                }
            }

            return false;
        }

        private static bool DFSUtilDetectCycle(int i, int parent, bool[] vs, List<int>[] graph)
        {
            vs[i] = true;

            foreach (int child in graph[i])
            {
                if (child!=parent && vs[child])
                {
                    return true;
                }

                if (!vs[child] && DFSUtilDetectCycle(child, i, vs, graph))
                {
                    return true;
                }
            }

            return false;
        }

        // Count all the cyle with length n in an undirected graph

        public static int CountNLengthCycle(List<int>[] graph, int n)
        {
            int v = graph.Length;
            bool[] vs = new bool[v];
            int num = 0;
            for (int i = 0; i < v - (n - 1); i++)
            {
                DFSUtilCountCycle(i, vs, n - 1, i, graph, ref num);
                vs[i] = true;
            }

            return (num / 2);
        }

        private static void DFSUtilCountCycle(int s, bool[] vs, int n, int src, List<int>[] graph, ref int num)
        {
            if (n == 0)
            {
                if (graph[s].Contains(src))
                {
                    num++;
                }
                return;
            }

            vs[s] = true;

            foreach (var child in graph[s])
            {
                if (!vs[child])
                {
                    DFSUtilCountCycle(child, vs, n - 1, src, graph, ref num);
                }
            }

            vs[s] = false;
        }
    }
}
