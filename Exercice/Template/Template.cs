namespace Template
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class Solver
    {
        public static int n;
        public static int[] ns;
        public static string s;
        public static string[] ss;

        public static void Solve()
        {

        }

        #region Main

        public static TextReader Reader;
        static void MainF(string[] args)
        {
#if true
            Reader = new StreamReader(@"test\test.txt");
#else
            Reader = new StreamReader(Console.OpenStandardInput());
#endif
            n = ReadInt();
            ns = ReadIntArray();
            s = ReadString();
            ss = ReadStringArray();
            ss = ReadLines(n);

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
    }
}