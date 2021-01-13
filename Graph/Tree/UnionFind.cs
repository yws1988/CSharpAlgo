namespace CSharpAlgo.Graph.Tree
{
    public class UnionFind
    {
        public static Subset[] CreateSubsets(int n)
        {
            var subsets = new Subset[n];
            for (int v = 0; v < n; v++)
            {
                subsets[v] = new Subset();
                subsets[v].Parent = v;
                subsets[v].Rank = 0;
            }

            return subsets;
        }

        public static int Find(Subset[] subsets, int i)
        {
            if (subsets[i].Parent != i)
                subsets[i].Parent = Find(subsets, subsets[i].Parent);
            return subsets[i].Parent;
        }

        public static void Union(Subset[] subsets, int x, int y)
        {
            int xroot = Find(subsets, x);
            int yroot = Find(subsets, y);

            if (xroot != yroot)
            {
                if (subsets[xroot].Rank < subsets[yroot].Rank)
                    subsets[xroot].Parent = yroot;
                else if (subsets[yroot].Rank < subsets[xroot].Rank)
                    subsets[yroot].Parent = xroot;
                else
                {
                    subsets[xroot].Parent = yroot;
                    subsets[yroot].Rank++;
                }
            }
        }
    }

    public class Subset
    {
        public int Parent { get; set; }
        public int Rank { get; set; }
    }
}
