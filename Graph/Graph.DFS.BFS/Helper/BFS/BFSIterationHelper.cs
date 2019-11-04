namespace Algorithmne.Helper.BFS
{
    using Graph.Base;
    using System;
    using System.Collections.Generic;


    public class BFSIterationHelper
    {
        public IList<int> DisplayGraphBFS(AdjacencyList graph)
        {
            bool[] visited = new bool[V];

            Queue<int> queue = new Queue<int>();
            Console.Write("Please enter the start point : ");
            int start = int.Parse(Console.ReadLine());
            queue.Enqueue(start);
            visited[start] = true;

            while (queue.Count > 0)
            {
                int next = queue.Dequeue();
                Console.Write(next + " ");
                foreach (int i in G[next])
                {
                    if (visited[i] != true)
                    {
                        queue.Enqueue(i);
                        visited[i] = true;
                    }
                }
            }
        }
    }
}
