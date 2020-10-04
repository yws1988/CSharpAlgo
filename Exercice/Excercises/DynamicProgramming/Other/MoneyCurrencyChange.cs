namespace CSharpAlgo.Excercise.Excercises.DynamicProgramming.Other
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public class MoneyCurrencyChange
    {
        static int n, m;
        public static double[][] fs;

        public static void Solve()
        {
            var dp = new double[m + 1, n + 1];

            for (int i = 0; i < n; i++)
            {
                dp[1, i] = fs[0][i];
            }

            for (int i = 1; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    for (int k = 0; k < n; k++)
                    {
                        dp[i, j] = Math.Max(dp[i, j], dp[i - 1, k] * fs[k][j]);
                    }
                }
            }

            for (int k = 0; k < n; k++)
            {
                dp[m, 0] = Math.Max(dp[m, 0], dp[m - 1, k] * fs[k][0]);
            }

            Console.WriteLine(dp[m, 0] * 10000);
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
            var tmp = ReadIntArray();
            n = tmp[0];
            m = tmp[1];
            fs = ReadDoubleMatrix(n);

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
        public static double[][] ReadDoubleMatrix(int numberOfRows) { double[][] matrix = new double[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadDoubleArray(); return matrix; }
        public static string ReadString() { return reader.ReadLine(); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
        public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
        public static char[] ReadChars() { return reader.ReadLine().ToCharArray(); }
        public static char[][] ReadCharMatrix(int numberOfRows) { char[][] matrix = new char[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadChars(); return matrix; }
        #endregion

    }

}
