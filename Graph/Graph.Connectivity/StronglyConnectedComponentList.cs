using System.Collections.Generic;
using Utils.Graph.Helper;

namespace Graph.Connectivity
{
    public class StronglyConnectedComponentList
    {
        public static int[] GetSCC(List<int>[] graph)
        {
            var stack = new Stack<int>();
            int v = graph.Length;

            bool[] visited = new bool[v];

            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                {
                    DFS(i, visited, stack, graph);
                }
            }

            var rGraph = GraphListHelper.GetTransposeGraph(graph);
            
            int[] scc = new int[v];
            for (int i = 0; i < v; i++)
            {
                scc[i] = -1;
            }

            int numCompoents = 0;
            while (stack.Count > 0)
            {
                int i = stack.Pop();
                if (scc[i]==-1)
                {
                    DFSComponents(i, scc, graph, numCompoents);
                }
                numCompoents++;
            }

            return scc;
        }

        static void DFS(int s, bool[] vs, Stack<int> stack, List<int>[] graph)
        {
            vs[s] = true;

            foreach (int c in graph[s])
            {
                if (!vs[c])
                {
                    DFS(c, vs, stack, graph);
                }
            }

            stack.Push(s);
        }

        static void DFSComponents(int s, int[] scc, List<int>[] graph, int num)
        {
            scc[s] = num;

            foreach (int c in graph[s])
            {
                if (scc[c]==-1)
                {
                    DFSComponents(c, scc, graph, num);
                }
            }
        }
    }
}
