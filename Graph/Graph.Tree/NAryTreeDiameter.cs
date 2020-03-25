using System;
using System.Collections.Generic;

namespace graph.Tree
{
    public class NAryTreeDiameter
    {
        static List<int>[] Tree { get; set; }
        static int n;
        static int[] depth;
        static bool[] vs;

        public static int GetNAryTreeDiameter(List<int>[] tree)
        {
            Tree = tree;
            n = tree.Length;
            depth = new int[n];
            CalDepth();
            vs = new bool[n];
            return GetDiameter(0);
        }

        private static int GetDiameter(int root)
        {
            vs[root] = true;
            int max1 = 0, max2 = 0, max=0;
            foreach (var c in Tree[root])
            {
                if (!vs[c])
                {
                    max = Math.Max(max, GetDiameter(c));
                    if (max1 < depth[c])
                    {
                        max2 = max1;
                        max1 = depth[c];
                    }
                }
            }

            return Math.Max(max, max1 + max2 + 1);
        }

        private static void CalDepth()
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            vs = new bool[n];
            vs[0] = true;

            while (queue.Count > 0)
            {
                int p = queue.Dequeue();
                vs[p] = true;
                stack.Push(p);
                foreach (var c in Tree[p])
                {
                    if (!vs[c])
                    {
                        queue.Enqueue(c);
                    }
                }
            }

            vs = new bool[n];
            
            while (stack.Count > 0)
            {
                int p = stack.Pop();
                vs[p] = true;

                int d = 1;
                foreach (var c in Tree[p])
                {
                    d = Math.Max(d, 1+depth[c]);
                }

                depth[p] = d;
            }
        }
    }
}
