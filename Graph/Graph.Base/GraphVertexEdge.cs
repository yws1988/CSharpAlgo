using System.Collections.Generic;

namespace Graph.Base
{
    public class Edge
    {
        public int Src { get; set; }
        public int Des { get; set; }
        public int Weight { get; set; }
    }
    public class GraphVertexEdge
    {
        public int V { get; set; }
        public List<Edge> edges { get; set; }

        public GraphVertexEdge(int v)
        {
            V = v;
            edges = new List<Edge>();
        }

        public void AddEdge(int x, int y)
        {
            edges.Add(new Edge {Src = x, Des = y});
        }
    }
}
