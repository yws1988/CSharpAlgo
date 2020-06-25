namespace Graph.Tree
{
    using System;
    using System.Collections.Generic;

    public class NAryTreeDiameter
    {
        public static int GetNAryTreeDiameter(List<int>[] tree)
        {
            int n = tree.Length;
            var depth = new int[n];
            
            return GetDiameter(tree, n, depth);
        }

        private static int GetDiameter(List<int>[] tree, int n, int[] depth)
        {
            Stack<int> stack = new Stack<int>();
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(0);
            var vs = new bool[n];
            vs[0] = true;

            while (queue.Count > 0)
            {
                int p = queue.Dequeue();
                vs[p] = true;
                stack.Push(p);
                foreach (var c in tree[p])
                {
                    if (!vs[c])
                    {
                        queue.Enqueue(c);
                    }
                }
            }

            vs = new bool[n];
            int diameter = 0;
            
            while (stack.Count > 0)
            {
                int p = stack.Pop();
                vs[p] = true;

                int d = 1;
                foreach (var c in tree[p])
                {
                    if (vs[c])
                    {
                        d = Math.Max(d, 1 + depth[c]);
                    }
                }

                depth[p] = d;
                diameter = Math.Max(diameter, GetSumOfTowGreatestChildDepth(tree, n, depth, p));
            }

            return diameter;
        }

        private static int GetSumOfTowGreatestChildDepth(List<int>[] tree, int n, int[] depth, int root)
        {
            int max1 = 0, max2 = 0;
            foreach (var c in tree[root])
            {
                if (max1 < depth[c])
                {
                    max2 = max1;
                    max1 = depth[c];
                }
            }

            return max1 + max2 + 1;
        }
    }
}
