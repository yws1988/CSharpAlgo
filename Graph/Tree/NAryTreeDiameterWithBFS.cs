namespace Graph.Tree
{
    using System;
    using System.Collections.Generic;

    public class NAryTreeDiameterWithBFS
    {
        public static void PrintNAryTreeDiameter(List<int>[] tree)
        {
            int n = tree.Length;
            var distance = new int[n];
            var vs = new bool[n];
            int max;
            int src = BFS(tree, distance, vs, 0, out max);
            distance = new int[n];
            vs = new bool[n];
            max = 0;
            int des = BFS(tree, distance, vs, src, out max);
            Console.WriteLine($"Longest path from vertex {src} to vertex {des} with diameter {max+1}");
        }

        private static int BFS(List<int>[] tree, int[] distance, bool[] vs, int src, out int max)
        {
            Queue<int> queue = new Queue<int>();
            queue.Enqueue(src);
            int vertex=0;
            max = 0;

            while (queue.Count > 0)
            {
                int p = queue.Dequeue();
                vs[p] = true;
                if (distance[p] > max)
                {
                    max = distance[p];
                    vertex = p;
                }

                foreach (var c in tree[p])
                {
                    if (!vs[c])
                    {
                        distance[c] = distance[p] + 1;
                        queue.Enqueue(c);
                    }
                }
            }

            return vertex;
        }
    }
}
