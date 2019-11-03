using System;
using System.Collections.Generic;
using System.Linq;
using Graph.Base;

namespace Algorithmne
{
    public class FindMotherVertex
    {
        public AdjacencyList AdjList { get; set; }
        public Stack<int> Stack { get; set; }

        public FindMotherVertex(AdjacencyList adjList)
        {
            AdjList = adjList;
            Stack = new Stack<int>();
        }

        public void DFSsearching(int i)
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

        public void Print()
        {
            for (int i = 0; i < AdjList.V; i++)
            {
                if (AdjList.Visited[i] == false)
                {
                    DFSsearching(i);
                }       
            }

            AdjList.Reset();

            int topVertex = Stack.Pop();
            DFSsearching(topVertex);
            if (!AdjList.Visited.Any(s => s == false))
            {
                Console.WriteLine(topVertex + " is a mother vertex!");
            }
        }
    }
}
