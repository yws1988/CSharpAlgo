using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace HackerEarth.Graph.Base
{
    public class OptimalConnectivity
    {
        public static int n;
        public static List<Pair>[] tree;
        public static int q;
        public static int u, v, w;

        static int level;
        static int[,] ps;
        static int[,] ew;
        static int[] depth;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\OptimalConnectivity.txt");
#endif
            n = int.Parse(input.ReadLine()) + 1;
            tree = Enumerable.Range(0, n).Select(s => new List<Pair>()).ToArray();
            for (int i = 1; i < n-1; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                tree[tt[0]].Add(new Pair(tt[1], tt[2]));
                tree[tt[1]].Add(new Pair(tt[0], tt[2]));
            }

            Solve();

            q = int.Parse(input.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                u = tt[0];
                v = tt[1];
                w = tt[2];
                int emax = Lca(u, v);

                Console.WriteLine(emax > w ? "YES" : "NO");
            }

            Console.Read();
        }

        public static void Solve()
        {
            level = (int)Math.Ceiling(Math.Log(n, 2)) + 1;
            ps = new int[n, level];
            ew = new int[n, level];
            depth = new int[n];
            Dfs();
            CalDp();
        }

        private static void Dfs()
        {
            int node, p, d, w;
            bool[] vs = new bool[n];
            Stack<Tuple<int, int, int, int>> stack = new Stack<Tuple<int, int, int, int>>();
            stack.Push(new Tuple<int, int, int, int>(1, 0, 0, 0));
            while (stack.Count > 0)
            {
                var tuple = stack.Pop();
                node = tuple.Item1;
                p = tuple.Item2;
                d = tuple.Item3;
                w = tuple.Item4;
                vs[node] = true;
                ps[node, 0] = p;
                ew[node, 0] = w;
                depth[node] = d;

                foreach (var child in tree[node])
                {
                    if (!vs[child.d])
                    {
                        stack.Push(new Tuple<int, int, int, int>(child.d, node, d + 1, child.w));
                    }
                }
            } 
        }

        private static void CalDp()
        {
            for (int j = 1; j < level; j++)
            {
                for (int i = 1; i < n; i++)
                {
                    ps[i, j] = ps[ps[i, j - 1], j - 1];
                    ew[i, j] = Math.Max(ew[i, j - 1], ew[ps[i, j - 1], j - 1]);
                }
            }
        }

        private static int Lca(int u, int v)
        {
            int maxE = 0;
            if (depth[u] > depth[v])
            {
                int temp = u;
                u = v;
                v = temp;
            }

            int h = depth[v] - depth[u];

            for (int i = 0; i < level; i++)
            {
                if (((h >> i) & 1) == 1)
                {
                    maxE = Max(maxE, ew[v, i]);
                    v = ps[v, i];
                }
            }

            if (u == v) return maxE;

            for (int i = level - 1; i >= 0; i--)
            {
                if (ps[u, i] != ps[v, i])
                {
                    maxE = Max(maxE, ew[u, i], ew[v, i]);
                    u = ps[u, i];
                    v = ps[v, i];
                }
            }

            return Max(maxE, ew[u, 0], ew[v, 0]);
        }

        static int Max(params int[] ps)
        {
            return ps.Max();
        }
    }

    public struct Pair
    {
        public int d { get; set; }
        public int w { get; set; }

        public Pair(int i, int j)
        {
            d = i;
            w = j;
        }
    }
}
