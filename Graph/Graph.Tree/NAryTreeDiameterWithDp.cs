namespace graph.Tree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class NAryTreeDiameterWithDp
    {
        static List<int>[] Tree { get; set; }
        static int n;
        static int[] dp1;
        static int[] dp2;
        static bool[] vs;

        public static int GetNAryTreeDiameter(List<int>[] tree)
        {
            Tree = tree;
            n = tree.Length;
            dp1 = new int[n];
            dp2 = new int[n];
            vs = new bool[n];
            Dfs1(0);
            vs = new bool[n];
            Dfs2(0);
            return dp2.Max();
        }

        private static int Dfs1(int root)
        {
            if (dp1[root] != 0) return dp1[root];

            vs[root] = true;
            int v = 1;
            foreach (var c in Tree[root])
            {
                if (!vs[c])
                {
                    v = Math.Max(v, 1+Dfs1(c));
                }
            }

            return dp1[root] = v;
        }

        private static int Dfs2(int root)
        {
            if (dp2[root] != 0) return dp2[root];

            vs[root] = true;
            int max1 = 0, max2 = 0;
            foreach (var c in Tree[root])
            {
                if (!vs[c])
                {
                    Dfs2(c);
                    if (max1 < dp1[c])
                    {
                        max2 = max1;
                        max1 = dp1[c];
                    }
                }
            }

            return dp2[root] = 1+max1+max2;
        }
    }
}
