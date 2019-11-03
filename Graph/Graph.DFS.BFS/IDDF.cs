using System;
using System.Collections.Generic;
using Graph.Base;

namespace Algorithmne
{
    public class IDDF
    {
        public AdjacencyList AdjList { get; set; }
        public Stack<int> Stack { get; set; }

        public IDDF(AdjacencyList adjList)
        {
            AdjList = adjList;
            Stack = new Stack<int>();
        }

        public bool IDDFIterateSearch(int vertex, int target, int depth)
        {
            if (depth < 0) return false;

            Console.Write(vertex + " ");

            if (vertex == target) return true;

            --depth;

            foreach (int i in AdjList.G[vertex])
            {
                if (IDDFIterateSearch(i, target, depth)) return true;
            }

            return false;
        }

        public void IDDFIterate(int vertex, int depth)
        {
            if (depth < 0) return;

            Console.Write(vertex +" ");

            --depth;

            foreach (int i in AdjList.G[vertex])
            {
                IDDFIterate(i, depth);
            }
        }

        public void DisplayPath(int start, int limited)
        {
            for (int i = 0; i < limited; i++)
            {
                Console.WriteLine("Depth : " + i);
                IDDFIterate(start, i);
                Console.WriteLine();
            }
        }

        public bool Find(int start, int target, int limited)
        {
            for (int i = 0; i < limited; i++)
            {
                Console.WriteLine("Depth : " + i);
                if (IDDFIterateSearch(0, target, i)) return true;
                Console.WriteLine();
            }
            return false;
        }
    }
}
