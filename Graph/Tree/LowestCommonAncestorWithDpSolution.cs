namespace CSharpAlgo.Graph.Tree
{
    using System;
    using System.Collections.Generic;

    public class LowestCommonAncestorWithDpSolution
    {
        static List<int>[] tree;
        static int n;
        static int level;
        static int[,] dp;
        static int[] depth;

        public static int GetLowestCommonAncestor(int u, int v, List<int>[] treeP, int root)
        {
            tree = treeP;
            n = tree.Length;
            level = (int)Math.Ceiling(Math.Log(n, 2)) + 1;
            dp = new int[n, level];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < level; j++)
                {
                    dp[i, j] = -1;
                }
            }

            bool[] vs = new bool[n];
            depth = new int[n];
            Dfs(root, -1, 0, vs);
            CalDp();

            return Lca(u, v);
        }

        private static void Dfs(int node, int p, int d, bool[] vs)
        {
            vs[node] = true;
            dp[node, 0] = p;
            depth[node] = d;

            foreach (var child in tree[node])
            {
                if (!vs[child])
                {
                    Dfs(child, node, d+1, vs);
                }
            }
        }

        private static void CalDp()
        {
            for (int j = 1; j < level; j++)
            {
                for (int i = 1; i < n; i++)
                {
                    if (dp[i, j - 1] != -1)
                    {
                        dp[i, j] = dp[dp[i, j - 1], j - 1];
                    }
                }
            }
        }

        private static int Lca(int u, int v)
        {
            if (depth[u] > depth[v])
            {
                int temp = u;
                u = v;
                v = temp;
            }

            int h = depth[v] - depth[u];

            for (int i = 0; i < level; i++)
            {
                if(((h>>i) & 1) == 1)
                {
                    v = dp[v, i];
                }
            }

            if (u == v) return u;

            for (int i = level-1; i >= 0; i--)
            {
                if(dp[u, i]!=dp[v, i])
                {
                    u = dp[u, i];
                    v = dp[v, i];
                }
            }

            return dp[u, 0];
        }
    }
}
