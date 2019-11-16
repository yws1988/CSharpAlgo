namespace Graph.Model
{
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
