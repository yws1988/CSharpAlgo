using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace HackerEarth.Graph.Base
{
    public class MinMaxWeightedEdge
    {
        public static int t;
        public static int n;
        public static int s;
        public static List<int>[] tree;
        static bool[] vs;
        static List<Node> nodes;
        static int diameter=0;
        static int start;
        static HashSet<int> set = new HashSet<int>();
        static int[] path;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\MinMaxWeightedEdge.txt");
#endif
            t = int.Parse(input.ReadLine());
            for (int i = 0; i < t; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                n = tt[0]+1;
                s = tt[1];
                tree = Enumerable.Range(0, n).Select(s => new List<int>()).ToArray();

                for (int j = 1; j < n-1; j++)
                {
                    tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    tree[tt[0]].Add(tt[1]);
                    tree[tt[1]].Add(tt[0]);
                }
                Solve();
            }

            Console.Read();
        }

        private static void Solve()
        {
            set.Clear();
            nodes = new List<Node>();
            vs = new bool[n];
            diameter = 0;
            start = 0;
            BFS1(1);
            var leafs = nodes.Where(s => s.IsLeaf).Select(s => s.Index).ToList();
            leafs.Add(1);
            diameter = 0;
            vs = new bool[n];
            BFS2(start);

            foreach (var i in leafs)
            {
                vs = new bool[n];
                path=new int[diameter+1];
                DFS(i, 0);
            }

            bool containsAll = true;

            for (int i = 1; i < n; i++)
            {
                if (!set.Contains(i))
                {
                    containsAll = false;
                }
            }

            if (containsAll)
            {
                Console.WriteLine((int)Math.Ceiling(s / ((double)n - 2)));
            }
            else
            {
                Console.WriteLine(0);
            }
        }

        private static void BFS1(int root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(new Node(root, 0, false));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                int pi = p.Index;
                int pd = p.Depth;
                if (pd > diameter)
                {
                    diameter = pd;
                    start = pi;
                }
                vs[pi] = true;

                bool leaf = true;
                foreach (var c in tree[pi])
                {
                    if (!vs[c])
                    {
                        leaf = false;
                        queue.Enqueue(new Node(c, pd+1, false));
                    }
                }

                p.IsLeaf= leaf;
                nodes.Add(p);
            }
        }

        private static void BFS2(int root)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(new Node(root, 0, false));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                int pi = p.Index;
                int pd = p.Depth;
                if (pd > diameter)
                {
                    diameter = pd;
                }
                vs[pi] = true;

                foreach (var c in tree[pi])
                {
                    if (!vs[c])
                    {
                        queue.Enqueue(new Node(c, pd + 1, false));
                    }
                }
            }
        }

        static void DFS(int s, int d)
        {
            path[d] = s;
            vs[s] = true;
            if (d == diameter)
            {
                for (int i = 0; i <= d; i++)
                {
                    set.Add(path[i]);
                }
            }

            foreach (var c in tree[s])
            {
                if (!vs[c])
                {
                    DFS(c, d+1);
                }
            }
        }



        class Node
        {
            public int Index { get; set; }
            public int Depth { get; set; }
            public bool IsLeaf { get; set; }

            public Node(int i, int d, bool leaf)
            {
                Index = i;
                Depth = d;
                IsLeaf = leaf;
            }
        }
    }
}
