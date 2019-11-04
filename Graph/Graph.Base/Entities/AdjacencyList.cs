namespace Graph.Base
{
    using System;
    using System.Collections.Generic;

    public class AdjacencyList<T>
    {
        public int V { get; set; }
        public List<T>[] G { get; set; }

        public AdjacencyList(int v)
        {
            V = v;
            G = new List<T>[V];

            for (var i = 0; i < G.Length; i++)
            {
                G[i]=new List<T>();
            }
        }

        public List<T> this[int index]
        {
            get
            {
                return G[index];
            }
            set
            {
                G[index] = value;
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
    }
}
