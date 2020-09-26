namespace CSharpAlgo.Excercise.Excercises.Other
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Solution
    {
        public static int[] ns;

        public static void Solve()
        {
            var rs = new int[4];
            int res = 0;

            for (int i = 0; i < 7; i++)
            {
                var nn = ReadIntArray();
                var sumNn = new int[4];

                for (int j = 0; j < 4; j++)
                {
                    sumNn[j] = nn[j] + rs[j];
                }

                int min = sumNn.Select((v, idx) => v/ns[idx]).Min();

                res += min;

                for (int j = 0; j < 4; j++)
                {
                    int consumedNum = min * ns[j];

                    rs[j] = consumedNum > rs[j] ?  sumNn[j] - consumedNum : nn[j] ;
                }
            }

            Console.WriteLine(res);
        }

        #region Main

        public static TextReader Reader;
        public static void MainF(string[] args)
        {
#if false
            Reader = new StreamReader(@"test\test.txt");
#else
            Reader = new StreamReader(Console.OpenStandardInput());
#endif
            ns = ReadIntArray();
            

            Solve();
            Reader.Close();
        }

        #endregion


        private static Queue<string> currentLineTokens = new Queue<string>();
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadStringArray()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadStringArray().Select(int.Parse).ToArray(); }
        public static string ReadString() { return Reader.ReadLine(); }
        public static string[] ReadStringArray() { return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = Reader.ReadLine().Trim(); return lines; }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }

    }
}