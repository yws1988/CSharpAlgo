namespace Graph.Tree
{
    using System;
    using System.Collections.Generic;

    public class NAryTreeDiameterWithBFS
    {
        static List<int>[] Tree { get; set; }
        static int n;
        static int[] dis;
        static int s, e;
        static bool[] vs;

        public static void PrintNAryTreeDiameter(List<int>[] tree)
        {
            Tree = tree;
            n = tree.Length;
            dis = new int[n];
            vs = new bool[n];
            int max;
            s = BFS(0, out max);
            dis = new int[n];
            vs = new bool[n];
            max = 0;
            e = BFS(s, out max);
            Console.WriteLine($"Longest path from vertex {s} to vertex {e} with diameter {max+1}");
        }

        private static int BFS(int root, out int max)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(root);
            int e=0;
            max = 0;

            while (queue.Count > 0)
            {
                int p = queue.Dequeue();
                vs[p] = true;
                if (dis[p] > max)
                {
                    max = dis[p];
                    e = p;
                }

                foreach (var c in Tree[p])
                {
                    if (!vs[c])
                    {
                        dis[c] = dis[p] + 1;
                        queue.Enqueue(c);
                    }
                }
            }

            return e;
        }
    }
}
