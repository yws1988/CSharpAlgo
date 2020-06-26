namespace CSharpAlgo.DataStructure.Graph
{
    public class AdjacencyMatrix
    {
        public int[,] Value;
        public int N { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyMatrix(int[,] graph)
        {
            Value = graph;
            N = graph.GetLength(0);
        }

        public AdjacencyMatrix(int n, bool isDirected = false)
        {
            N = n;
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
        }

        public int this[int src, int des]
        {
            get
            {
                return Value[src, des];
            }
            set
            {
                Value[src, des] = value;
            }
        }
    }
}
