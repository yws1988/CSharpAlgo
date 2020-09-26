namespace CSharpAlgo.Excercise.Excercises.BitMasking
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using Utils.Helper;

    public class CommonSequenceInStrings
    {
        public static int n;
        public static string[] ss;

        public static void Solve()
        {
            int len = (int)Math.Pow(2, 10) - 1;
            int max = 0;
            string str = "";

            for (int i = len; i >= 0; i--)
            {
                List<char> cs = new List<char>();
                for (int j = 0; j < 10; j++)
                {
                    if (Check(j, i) == 1)
                    {
                        cs.Add(ss[0][j]);
                    }

                    if (cs.Count > max)
                    {
                        var tstr = new string(cs.ToArray());

                        bool isValid = true;
                        for (int k = 1; k < n; k++)
                        {
                            if (!StringHelper.IsSequenceInString(tstr, ss[k]))
                            {
                                isValid = false;
                                break;
                            }
                        }

                        if (isValid)
                        {
                            str = tstr;
                            max = str.Length;
                        }
                    }
                }
            }

            Console.WriteLine(str == "" ? "KO" : str);
        }

        static int Check(int i, int value)
        {
            return 1 & value >> i;
        }

        #region Main

        protected static TextReader reader;
        static void MainF()
        {
#if true
            reader = new StreamReader(@"test.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
            n = ReadInt();
            ss = ReadLines(n);

            Solve();
            reader.Close();
        }

        #endregion

        #region Read / Write
        private static Queue<string> currentLineTokens = new Queue<string>();
        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
        #endregion
    }
}
