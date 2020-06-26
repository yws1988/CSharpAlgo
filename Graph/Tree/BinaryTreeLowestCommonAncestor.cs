namespace CSharpAlgo.Graph.Tree
{
    public class BinaryTreeLowestCommonAncestor
    {
        public static Node Root;
        static int Val1, Val2;
        static bool existVal1, existVal2;

        public static int GetLowestCommonAncestor(int val1, int val2)
        {
            Val1 = val1;
            Val2 = val2;
            Node result = Search(Root);
            if (result != null && existVal1 && existVal2) return result.Value;
            return -1;
        }

        static Node Search(Node node)
        {
            if (node == null) return null;

            Node temp = null;
            if(node.Value == Val1)
            {
                existVal1 = true;
                temp = node;
            }

            if(node.Value == Val2)
            {
                existVal2 = true;
                temp = node;
            }

            var searchLeft = Search(node.Left);
            var searchRight = Search(node.Right);

            if (temp != null) return temp;
            
            if (searchLeft != null && searchRight != null) return node;
            return searchLeft != null ? searchLeft : searchRight;
        }


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
}
