namespace CSharpContestProject
{

    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MagicFunction
    {
        static int n, k;
        static int[] fs;

        static void Solve()
        {
            var mapping = new int[n + 1, n + 1];

            for (int i = 0; i < n; i++)
            {
                int min = Math.Min(fs[i], fs[i + 1]);
                int max = Math.Max(fs[i], fs[i + 1]);

                for (int j = min; j < max; j++)
                {
                    // map from i to j
                    mapping[i, j] = 1;
                }
            }

            int[] timesToReachPoint = Enumerable.Repeat(1, n).ToArray();

            for (int ki = 0; ki < k; ki++)
            {
                int[] temp = new int[n];
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        temp[j] += mapping[i, j] * timesToReachPoint[i];
                        temp[j] %= 1000;
                    }
                }

                temp.CopyTo(timesToReachPoint, 0);
            }

            Console.WriteLine(timesToReachPoint[n/2]);
        }
        
        #region Main

        public static TextReader Reader;
        public static void MainF(string[] args)
        {
#if true
            Reader = new StreamReader(@"IOFiles\test.txt");
#else
            Reader = new StreamReader(Console.OpenStandardInput());
#endif
            n = ReadInt();
            fs = ReadIntArray();
            k = ReadInt();

            Solve();
            Reader.Close();
        }

        #endregion

        private static Queue<string> currentLineTokens = new Queue<string>();
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadStringArray()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadStringArray().Select(int.Parse).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
        public static string ReadString() { return Reader.ReadLine(); }
        public static string[] ReadStringArray() { return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = Reader.ReadLine().Trim(); return lines; }
    }
}