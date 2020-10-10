namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FloodFillFromSourceToDestinationInMatrix
    {
        public static int n;
        public static char[][] cs;

        public static void Solve()
        {
            int srcx = 0, srcy = 0;
            var queue = new Queue<(int, int, int)>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cs[i][j] == 'M')
                    {
                        queue.Enqueue((i, j, 0));
                    }
                    else if (cs[i][j] == 'C')
                    {
                        srcx = i;
                        srcy = j;
                    }
                }
            }

            int[] xMove = { 1, 0, -1, 0 };
            int[] yMove = { 0, -1, 0, 1 };

            queue.Enqueue((srcx, srcy, 0));

            while (queue.Any())
            {
                var p = queue.Dequeue();
                int x = p.Item1;
                int y = p.Item2;
                char pChar = cs[x][y];

                for (int u = 0; u < 4; u++)
                {
                    int tx = xMove[u] + x;
                    int ty = yMove[u] + y;

                    tx = tx == -1 ? n - 1 : tx;
                    tx = tx == n ? 0 : tx;
                    ty = ty == -1 ? n - 1 : ty;
                    ty = ty == n ? 0 : ty;

                    char cChar = cs[tx][ty];

                    if (pChar == 'C')
                    {
                        if (cChar == '.')
                        {
                            cs[tx][ty] = 'C';
                            queue.Enqueue((tx, ty, p.Item3 + 1));
                        }
                        else if (cChar == 'O')
                        {
                            Console.WriteLine(p.Item3 + 1);
                            return;
                        }
                    }
                    else
                    {
                        if (cChar == 'O')
                        {
                            Console.WriteLine(0);
                            return;
                        }
                        else if (cChar != '#')
                        {
                            cs[tx][ty] = '#';
                            queue.Enqueue((tx, ty, p.Item3 + 1));
                        }
                    }
                }
            }
        }

        #region Main

        protected static TextReader reader;
        static void MainF(string[] args)
        {
#if false
            reader = new StreamReader(@"test\test.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
            n = ReadInt();
            cs = ReadCharMatrix(n);

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
        public static string ReadString() { return reader.ReadLine(); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }

        public static char[] ReadChars() { return reader.ReadLine().ToCharArray(); }
        public static char[][] ReadCharMatrix(int numberOfRows) { char[][] matrix = new char[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadChars(); return matrix; }
        #endregion
    }

}
