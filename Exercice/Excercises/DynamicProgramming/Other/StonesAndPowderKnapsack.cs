namespace CSharpAlgo.Excercise.Excercises.DynamicProgramming.Other
{
    using CSharpAlgo.DynamicProgramming.Other;
    using System;
    using System.IO;
    using System.Linq;

    public class StonesAndPowderKnapsack
    {
        public static int n, m, c;
        public static int[][] ss;
        public static int[][] ps;
        private static int[,] dp;

        public static void Solve()
        {
            var arr = ss.Select(s => (s[1], s[0])).ToArray();
            MaximumValueSubsetOfKnapsack.GetMaxValue(arr, c, out dp);

            ps = ps.OrderByDescending(s => s[0]).ToArray();
            int result = 0;
            for (int i = 0; i < c + 1; i++)
            {
                result = Math.Max(result, dp[i, n - 1] + GetMaxValue(c - i));
            }

            Console.WriteLine(result);
        }

        static int GetMaxValue(int p)
        {
            int value = 0;
            for (int i = 0; i < m; i++)
            {
                if (p >= ps[i][1])
                {
                    value += ps[i][0] * ps[i][1];
                    p -= ps[i][1];
                }
                else
                {
                    value += ps[i][0] * p;
                    break;
                }
            }

            return value;
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
            var tmp = ReadIntArray();
            n = tmp[0];
            m = tmp[1];
            c = tmp[2];
            ss = ReadIntMatrix(n);
            ps = ReadIntMatrix(m);

            Solve();
            reader.Close();
        }

        #endregion

        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
    }
}

