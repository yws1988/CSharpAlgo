namespace Graph.Base
{
    using System;
    using System.Collections.Generic;

    public class AdjacencyList
    {
        public int V { get; set; }
        public List<int>[] G { get; set; }
        public bool[] Visited { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyList(int v, bool isDirected = false)
        {
            V = v;
            G = new List<int>[V];

            for (var i = 0; i < G.Length; i++)
            {
                G[i]=new List<int>();
            }

            Visited = new bool[V];
            IsDirected = isDirected;
        }

        public void Reset()
        {
            for (var i = 0; i < Visited.Length; i++)
            {
                Visited[i] = false;
            }
        }

        public void AddEdge(int src, int des)
        {
            G[src].Add(des);
            if (!IsDirected)
            {
                G[des].Add(src);
            }
        }

        public void DisplayGraphBFS()
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

        public void DisplayGraphDFS(int start)
        {
            Console.Write(start+" ");
            Visited[start] = true;

            foreach (int i in G[start])
            {
                if (Visited[i] != true)
                {
                    DisplayGraphDFS(i);
                    Visited[i] = true;
                }
            }
        }

        public List<int> this[int index]
        {
            get
            {
                return this.G[index];
            }
        }

        public void Print()
        {
            for (int i = 0; i < V; i++)
            {
                foreach (int item in G[i])
                {
                    Console.Write(item + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
