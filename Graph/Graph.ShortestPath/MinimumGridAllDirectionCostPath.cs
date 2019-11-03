using System;

namespace Graph.ShortestPath
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using Collection;

    public class MinimumGridAllDirectionCostPath
    {
        public static int R;
        public static int C;
        public static List<(int, int)> Edges=new List<(int, int)>();

        public static void PrintShortestPath(int[,] graph)
        {
            R = graph.GetLength(0);
            C = graph.GetLength(1);

            Console.WriteLine(DijkastraShortest(graph));
        }

        static int DijkastraShortest(int[,] g)
        {
            bool[,] vs = new bool[R,C];
            int[,] ws = new int[R,C];
            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    ws[i, j] = int.MaxValue;
                }
            }

            ws[0, 0] = g[0, 0];

            PriorityQueue<Node> pq = new PriorityQueue<Node>();
            pq.Enqueue(new Node(0, 0, ws[0, 0]));
            int[] dx = { -1, 0, 1, 0 };
            int[] dy = { 0, 1, 0, -1 };

            while (pq.Count() > 0)
            {
                var node = pq.Dequeue();
                int x = node.X;
                int y = node.Y;
                if (x == R-1 && y==C-1) return node.W;
                if (vs[x, y]) continue;
                vs[x, y] = true;

                for (int i = 0; i < 4; i++)
                {
                    int tX = x + dx[i];
                    int tY = y + dy[i];
                    if (IsSafe(tX, tY) && !vs[tX, tY])
                    {
                        if (ws[tX, tY] > ws[x, y] + g[tX, tY])
                        {
                            ws[tX, tY] = ws[x, y] + g[tX, tY];
                        }

                        pq.Enqueue(new Node(tX, tY, ws[tX, tY]));
                    }
                }
            }

            return ws[R-1, C-1];
        }

        static bool IsSafe(int x, int y)
        {
            return x >= 0 && x < R && y >= 0 && y < C;
        }

        public class Node : IComparable<Node>
        {
            public int X { get; set; }

            public int Y { get; set; }

            public int W { get; set; } 

            public Node(int x, int y, int w)
            {
                X = x;
                Y = y;
                W = w;
            }

            public int CompareTo(Node other)
            {
                return this.W.CompareTo(other.W);
            }
        }
    }
}
