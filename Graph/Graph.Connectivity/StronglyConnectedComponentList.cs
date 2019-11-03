using System;
using System.Collections.Generic;
using Graph.Base;

namespace Graph.Connectivity
{
    public class StronglyConnectedComponentList
    {
        public AdjacencyList AdjList { get; set; }
        public AdjacencyList ReverseAdjList { get; set; }
        public Stack<int> Stack { get; set; }

        public StronglyConnectedComponentList(AdjacencyList adjList)
        {
            AdjList = adjList;
            Stack = new Stack<int>();
        }

        public void PrintSCC()
        {
            // DFS over the adjacencyList$
            for (int i = 0; i < AdjList.V; i++)
            {
                if (AdjList.Visited[i] == false)
                {
                    DFSsearching(i);
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

        void DFSsearching(int i)
        {
            AdjList.Visited[i] = true;

            foreach (int s in AdjList.G[i])
            {
                if (AdjList.Visited[s] == false)
                {
                    DFSsearching(s);
                }
            }

            Stack.Push(i);
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

        AdjacencyList GetTransposeGraph()
        {
            AdjacencyList reversGraph = new AdjacencyList(AdjList.V);

            for (int i = 0; i < AdjList.V; i++)
            {
                foreach (int des in AdjList.G[i])
                {
                    reversGraph.G[des].Add(i);
                }
            }

            return reversGraph;
        }
    }
}
