namespace DataStructure.Models.Graph
{
    public class Node
    {
        public Node Left, Right;
        public int Value;

        public Node(int v)
        {
            Value = v;
        }
    }
}
