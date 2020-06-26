namespace CSharpAlgo.DataStructure.Graph
{
    using System.Collections.Generic;

    public struct Node
    {
        public int Index { get; set; }
        public int Weight { get; set; }
    }

    public class AdjacencyListWithEdgeWeight
    {
        public int V { get; set; }
        public List<Node>[] AdjList { get; set; }
        public bool[] Visited { get; set; }
        public bool IsDirected { get; set; }

        public AdjacencyListWithEdgeWeight(int v, bool isDirected = false)
        {
            V = v;
            AdjList = new List<Node>[V];

            for (var i = 0; i < AdjList.Length; i++)
            {
                AdjList[i]=new List<Node>();
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

        public void AddEdge(int src, int des, int weight)
        {
            AdjList[src].Add(new Node{Index = des, Weight = weight});
            if (!IsDirected)
            {
                AdjList[des].Add(new Node {Index = src, Weight = weight});
            }
        }

        public List<Node> this[int index]
        {
            get
            {
                return AdjList[index];
            }
        }
    }
}
