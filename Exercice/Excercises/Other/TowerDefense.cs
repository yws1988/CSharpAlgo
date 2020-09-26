namespace CSharpAlgo.Excercise.Excercises.Other
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    // Chess game problem
    public class TowerDefense
    {
        private static readonly int n = 8;
        public static string[] ss;

        public static void Solve()
        {
            var ts = new List<(int, int)>();
            var rr = 0;
            var cc = 0;

            for (var i = 0; i < n; i++)
                for (var j = 0; j < n; j++)
                    if (ss[i][j] == 'T')
                    {
                        ts.Add((i, j));
                    }
                    else if (ss[i][j] == 'R')
                    {
                        rr = i;
                        cc = j;
                    }

            var isEchec = ts.Any(s => s.Item1 == rr || s.Item2 == cc);

            for (var i = -1; i < 2; i++)
                for (var j = -1; j < 2; j++)
                {
                    if (i == 0 && j == 0) continue;
                    var tr = rr + i;
                    var tc = cc + j;
                    if (IsSafe(tr, tc))
                    {
                        var isStepOk = true;
                        foreach (var item in ts)
                            if (!(item.Item1 == tr && item.Item2 == tc))
                                if (item.Item1 == tr || item.Item2 == tc)
                                    isStepOk = false;

                        if (isStepOk)
                        {
                            Console.WriteLine("still-in-game");
                            return;
                        }
                    }
                }

            Console.WriteLine(isEchec ? "check-mat" : "pat");
        }

        private static bool IsSafe(int r, int c)
        {
            if (r >= 0 && r < 8 && c >= 0 && c < 8) return true;

            return false;
        }

        #region Main

        protected static TextReader reader;

        public static void MainF(string[] args)
        {
#if false
        reader = new StreamReader(@"test\test.txt");
#else
            reader = new StreamReader(Console.OpenStandardInput());
#endif
            ss = ReadLines(n);

            Solve();
            reader.Close();
        }

        #endregion

        #region Read / Write

        public static string[] ReadLines(int quantity)
        {
            var lines = new string[quantity];
            for (var i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim();
            return lines;
        }

        #endregion
    }
}
