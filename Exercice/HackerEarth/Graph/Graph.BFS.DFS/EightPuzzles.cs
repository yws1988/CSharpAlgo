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

namespace Graph.BFS.DFS
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Utils.Helper;
    using Utils.Helper.Math;

    public class EightPuzzles
    {
        static int[,] src = new int[3, 3], des = new int[3, 3];
        public static int x, y;
        static int[] dx = { -1, 0, 1, 0 };
        static int[] dy = { 0, 1, 0, -1 };

        static void Solve()
        {
            var queue = new Queue<Node>();

            var set = new HashSet<string>();
            var srcStr = MatrixHelper.GetHashString(src);
            var desStr = MatrixHelper.GetHashString(des);
            set.Add(srcStr);

            queue.Enqueue(new Node(src, x, y, new List<string> { srcStr }));

            while (queue.Count() > 0)
            {
                var p = queue.Dequeue();

                for (int i = 0; i < 4; i++)
                {
                    int tx = dx[i] + p.X;
                    int ty = dy[i] + p.Y;

                    if (IsSafe(tx, ty))
                    {
                        var newMatrix = ArrayHelper.Clone(p.Matrix);
                        var newList = new List<string>(p.Path);
                        var tmp = newMatrix[tx, ty];
                        newMatrix[tx, ty] = 0;
                        newMatrix[p.X, p.Y] = tmp;

                        var hashKey = MatrixHelper.GetHashString(newMatrix);
                        newList.Add(hashKey);
                        if (!set.Contains(hashKey))
                        {
                            queue.Enqueue(new Node(newMatrix, tx, ty, newList));
                        }

                        if (desStr == hashKey)
                        {
                            Print(newList);
                            return;
                        }
                    }
                }
            }
        }

        static void Print(List<string> path)
        {
            foreach (var item in path)
            {
                for (int i = 0; i < 3; i++)
                {
                    for (int j = 0; j < 3; j++)
                    {
                        Console.Write(item[i * 3 + j] + " ");
                    }
                    Console.WriteLine();
                }
                Console.WriteLine();
            }
        }

        static bool IsSafe(int x, int y)
        {
            return x >= 0 && x < 3 && y >= 0 && y < 3;
        }

        class Node
        {
            public int[,] Matrix { get; set; }
            public int X { get; set; }
            public int Y { get; set; }
            public List<string> Path { get; set; }

            public Node(int[,] matrix, int x, int y, List<string> path)
            {
                Matrix = matrix;
                X = x;
                Y = y;
                Path = path;
            }
        }

        #region Main

        protected static TextReader reader;
        static void MainF()
        {
#if true
            reader = new StreamReader(@"test\EightPuzzles.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
            for (int i = 0; i < 3; i++)
            {
                var tmp = ReadIntArray();
                for (int j = 0; j < tmp.Length; j++)
                {
                    src[i, j] = tmp[j];
                    if (tmp[j] == 0)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                var tmp = ReadIntArray();
                for (int j = 0; j < tmp.Length; j++)
                {
                    des[i, j] = tmp[j];
                }
            }

            Solve();
            reader.Close();
        }

        #endregion

        #region Read / Write
        private static Queue<string> currentLineTokens = new Queue<string>();
        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
        #endregion
    }
}
