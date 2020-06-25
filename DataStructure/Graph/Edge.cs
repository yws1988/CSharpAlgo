namespace DataStructure.Graph
{
    public class Edge
    {
        public int Src;
        public int Des;

        public Edge(int s, int d)
        {
            Src = s;
            Des = d;
        }
    }

    public class EdgeNode
    {
        public int Des { get; set; }
        public int Weight { get; set; }

        public EdgeNode(int d, int w)
        {
            Des = d;
            Weight = w;
        }
    }

    public class EdgeWithWeight
    {
        public int Src { get; set; }
        public int Des { get; set; }
        public int Weight { get; set; }

        public EdgeWithWeight(int s, int d, int w)
        {
            Src = s;
            Des = d;
            Weight = w;
        }
    }
}
