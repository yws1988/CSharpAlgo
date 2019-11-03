namespace Graph.Base
{
    using System;

    public class AdjacencyMatrix
    {
        public int[,] Value;
        public int N { get; set; }
        public int E { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyMatrix(int[,] graph)
        {
            Value = graph;
            N = graph.GetLength(0);
        }

        public AdjacencyMatrix(int n, bool isDirected = false)
        {
            N = n;
            E = 0;
            Value = new int[N, N];
            IsDirected = isDirected;
        }

        public void AddEdge(int src, int des, bool isDirected = false)
        {
            Value[src, des] = 1;
            if (!IsDirected)
            {
                Value[des, src] = 1;
            }
            ++E;
        }

        public void Print()
        {
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Value[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
