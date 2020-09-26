namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using CSharpAlgo.Maths;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using Utils.Helper.Math;

    public class MaximumCommonNeigboursAssignment
    {
        public static int n, m;
        public static int[] ns;
        public static int[][] relations;
        public static List<int> t0 = new List<int>();
        public static List<int> t1 = new List<int>();
        public static HashSet<int>[] friends;

        public static void Solve()
        {
            for (int i = 0; i < n; i++)
            {
                if (ns[i] == 0)
                {
                    t0.Add(i);
                }
                else
                {
                    t1.Add(i);
                }
            }

            friends = Enumerable.Range(0, n).Select(s => new HashSet<int>()).ToArray();
            foreach (var item in relations)
            {
                friends[item[0] - 1].Add(item[1] - 1);
                friends[item[1] - 1].Add(item[0] - 1);
            }

            int h = t0.Count;
            int w = t1.Count;
            int nn = Math.Max(h, w);

            var matrix = new int[nn, nn];
            int max = 0;

            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < nn; j++)
                {
                    if (i >= h || j >= w || friends[t0[i]].Contains(t1[j]))
                    {
                        matrix[i, j] = 0;
                    }
                    else
                    {
                        int common = friends[t0[i]].Intersect(friends[t1[j]]).Count();
                        matrix[i, j] = common;
                        max = Math.Max(max, common);
                    }
                }
            }

            var maxCostMatrix = MatrixHelper.GetMaxMatrixForHungarianMatching(matrix, max);

            var matches = HungarianMatching.GetAssignmentsWithMinimunCost(maxCostMatrix);

            List<string> res = new List<string>();
            for (int i = 0; i < nn; i++)
            {
                int j = matches[i];

                if (i < h && j < w)
                {
                    int a = t0[i];
                    int b = t1[j];

                    if (matrix[i, j] != 0)
                    {
                        res.Add((a + 1) + " " + (b + 1));
                    }
                }
            }

            Console.WriteLine(string.Join(",", res.ToArray()));
        }

        #region Main

        protected static TextReader reader;
        static void MainF(string[] args)
        {
#if true
            reader = new StreamReader(@"IOFiles\MaximumCommonNeigboursAssignmentInput.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
            var tmp = ReadIntArray();
            n = tmp[0];
            m = tmp[1];
            ns = ReadIntArray();
            relations = ReadIntMatrix(m);

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

        #endregion
    }
}
