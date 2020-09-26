/*  Given a 3×3 board with 8 tiles(every tile has one number from 1 to 8) and
    one empty space.The objective is to place the numbers on tiles to match
    final configuration using the empty space.We can slide four adjacent
    (left, right, above and below) tiles into the empty space.

    Matrix from:
    1 2 3 
    5 6 0 
    7 8 4 

    To:
    1 2 3 
    5 8 6 
    0 7 4

    Output the movement:
    1 2 3 
    5 6 0 
    7 8 4 

    1 2 3 
    5 0 6 
    7 8 4 

    1 2 3 
    5 8 6 
    7 0 4 

    1 2 3 
    5 8 6 
    0 7 4 */

namespace CSharpAlgo.Excercise.Excercises.BranchAndBounds
{
    using CSharpAlgo.DataStructure.Heap;
    using System;

    public class EightPuzzles
    {
        public static int[,] Src;
        public static int[,] Des;
        public const int N = 3;
        public static int[] Xs = { -1, 0, 1, 0 };
        public static int[] Ys = { 0, 1, 0, -1 };

        public static void Start(int[,] src, int[,] des)
        {
            Src = src;
            Des = des;

            NodeP node = new NodeP(Src, 0);
            node.C = GetCost(node);

            PriorityQueue<NodeP> queue = new PriorityQueue<NodeP>();
            queue.Enqueue(node);

            while (queue.Count() > 0)
            {
                var n = queue.Dequeue();
                Console.WriteLine(n.C+":"+n.Level);
                if (n.C == 0)
                {
                    Print(n);
                    break;
                }
              
                for (int i = 0; i < 4; i++)
                {
                    int tx = Xs[i] + n.X;
                    int ty = Ys[i] + n.Y;

                    if (n.Parent != null && n.Parent.X == tx && n.Parent.Y == ty) continue;

                    if (IsSafe(tx, ty))
                    {
                        var nN = n.Clone();
                        nN.Level++;
                        nN.N[nN.X, nN.Y] = nN.N[tx, ty];
                        nN.N[tx, ty] = 0;
                        nN.X = tx;
                        nN.Y = ty;
                        nN.C = GetCost(nN);
                        queue.Enqueue(nN);
                    }
                }
            }
        }

        static bool IsSafe(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        static int GetCost(NodeP node)
        {
            int c = 0;
            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (Des[i, j] != 0 && Des[i, j] != node.N[i, j])
                    {
                        c++;
                    }
                }
            }

            return c;
        }


        static void Print(NodeP node)
        {
            while (node != null)
            {
                for (int i = 0; i < N; i++)
                {
                    for (int j = 0; j < N; j++)
                    {
                        Console.Write(node.N[i, j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();

                node = node.Parent;
            }
        }
    }

    class NodeP : IComparable<NodeP>
    {
        public int[,] N { get; set; }
        public int C { get; set; }
        public int Level { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public NodeP Parent { get; set; }
        public NodeP(int[,] n, int l)
        {
            N = n;
            Level = l;
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (N[i, j] == 0)
                    {
                        X = i;
                        Y = j;
                        break;
                    }
                }
            }
        }

        public int CompareTo(NodeP other)
        {
            return (this.C + this.Level) - (other.C + other.Level);
        }

        public NodeP Clone()
        {
            var nN = (NodeP)this.MemberwiseClone();
            nN.Parent = this;
            int[,] n = new int[3, 3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    n[i, j] = N[i, j];
                }
            }
            nN.N = n;
            return nN;
        }
    }
}
