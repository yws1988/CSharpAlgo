using System;
using System.Collections.Generic;
using Graph.Base;

namespace Graph.Connectivity
{
    public class StronglyConnectedComponentList
    {
        public void PrintSCC(List<int>[] graph)
        {
            var stack = new Stack<int>();
            int v = graph.Length;
            bool[] visited = new bool[v];

            for (int i = 0; i < v; i++)
            {
                if (!visited[i])
                {
                    DFSsearching(graph, i, visited, stack);
                }
            }

            ReverseAdjList = GetTransposeGraph();

            while (Stack.Count > 0)
            {
                int i = Stack.Pop();
                if (ReverseAdjList.Visited[i] == false)
                {
                    DFSPrint(i);
                    Console.Write(" :: ");
                }
            }
        }

        void DFSsearching(List<int>[] graph, int s, bool[] vs, Stack<int> stack)
        {
            vs[s] = true;

            foreach (int c in graph[s])
            {
                if (!vs[c])
                {
                    DFSsearching(graph, c, vs, stack);
                }
            }

            stack.Push(s);
        }

        void DFSPrint(int i)
        {
            ReverseAdjList.Visited[i] = true;

            foreach (int s in ReverseAdjList.G[i])
            {
                if (ReverseAdjList.Visited[s] == false)
                    DFSPrint(s);
            }


            Console.Write(i + " ");
        }
    }
}
