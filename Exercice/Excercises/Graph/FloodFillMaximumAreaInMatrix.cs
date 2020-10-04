namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class FloodFillMaximumAreaInMatrix
    {
        public static int n;
        public static char[][] cs;

        public static void Solve()
        {
            var queue = new Queue<(int, int)>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cs[i][j] >= '0' && cs[i][j] <= '9')
                    {
                        queue.Enqueue((i, j));
                    }
                }
            }

            int[] xMove = { 1, -1, 0, 0 };
            int[] yMove = { 0, 0, 1, -1 };

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

                    if (!IsSafe(tx, ty, n))
                    {
                        continue;
                    }

                    char cChar = cs[tx][ty];

                    if (cChar != '#' && cChar != '=' && cChar != pChar)
                    {
                        if (pChar == '=' && cChar == '.')
                        {
                            cs[tx][ty] = '=';
                            queue.Enqueue((tx, ty));
                        }
                        else if (pChar != '=' && cs[tx][ty] == '.')
                        {
                            cs[tx][ty] = pChar;
                            queue.Enqueue((tx, ty));
                        }
                        else if (pChar != '=' && cs[tx][ty] != '.')
                        {
                            cs[tx][ty] = '=';
                            queue.Enqueue((tx, ty));
                        }
                    }
                }
            }

            var dic = new Dictionary<char, int>();

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (cs[i][j] >= '0' && cs[i][j] <= '9')
                    {
                        if (dic.ContainsKey(cs[i][j]))
                        {
                            dic[cs[i][j]] += 1;
                        }
                        else
                        {
                            dic[cs[i][j]] = 1;
                        }
                    }
                }
            }

            Console.WriteLine(dic.Values.Max());
        }

        static bool IsSafe(int i, int j, int v)
        {
            return i >= 0 && i < v && j >= 0 && j < v;
        }

        #region Main

        protected static TextReader reader;
        static void MainF(string[] args)
        {
#if true
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
