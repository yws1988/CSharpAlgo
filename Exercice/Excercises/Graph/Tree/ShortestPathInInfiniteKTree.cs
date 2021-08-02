/*
You're given a K-ary infinite tree rooted at a vertex numbered 1. All its edges are weighted 1 initially.
Any node  will have exactly  children numbered as:
K*X, K*X+1, ..., K*X+K-1
You are given q queries to answer which will be of the following two types:

: Print the shortest distance between nodes u and v.
: Increase the weight of all edges on the shortest path between u and v by w.

For each query of type 1 u v, print a single integer denoting the shortest distance between u and v.
*/

namespace CSharpAlgo.Excercise.Excercises.Graph.Tree
{
    using System;
    using System.Collections.Generic;

    public class ShortestPathInInfiniteKTree
    {
        public static int k, q;
        public static long[] ns;
        public static Dictionary<(long, long), long> weights;

        public static void Solve()
        {
            weights = new Dictionary<(long, long), long>();

            for (int i = 0; i < q; i++)
            {
                long qt = long.Parse(Console.ReadLine());
                long u = long.Parse(Console.ReadLine());
                long v = long.Parse(Console.ReadLine());

                long lca = GetLowestCommonAncestor(u, v);

                if (qt == 1)
                {
                    Console.WriteLine(GetCosts(lca, u) + GetCosts(lca, v));
                }
                else
                {
                    long w = ns[3];

                    UpdateCosts(lca, u, w);
                    UpdateCosts(lca, v, w);
                }
            }
        }

        static long GetCosts(long parent, long child)
        {
            if (parent == child) return 0;

            long cost = 0;

            while (child != parent)
            {
                long cparent = child / k;
                var path = (cparent, child);
                if (weights.ContainsKey(path))
                {
                    cost += weights[path];
                }
                else
                {
                    weights[path] = 1;
                    cost += weights[path];
                }

                child = cparent;
            }

            return cost;
        }

        static void UpdateCosts(long parent, long child, long weight)
        {
            if (parent == child) return;

            while (child != parent)
            {
                long cparent = child / k;
                var path = (cparent, child);

                if (!weights.ContainsKey(path))
                {
                    weights[path] = 1;
                }

                weights[path] += weight;

                child = cparent;
            }
        }

        static long GetLowestCommonAncestor(long u, long v)
        {
            long max = Math.Max(u, v);
            long min = Math.Min(u, v);

            int maxd = (int)Math.Log(max, k);
            int mind = (int)Math.Log(min, k);

            while (maxd != mind)
            {
                max = max / k;
                maxd--;
            }

            if (max == min)
            {
                return max;
            }

            while (max != min)
            {
                max /= k;
                min /= k;
            }

            return max;
        }
    }
}
