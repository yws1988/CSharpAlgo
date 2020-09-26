namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class SubwayStationIntersection
    {
        public static int n, m, s, d, num;

        public static void Solve()
        {
            var stations = Enumerable.Range(0, m + 1).Select(s => new List<int>()).ToList();
            for (int i = 0; i < n; i++)
            {
                var tmp = ReadIntArray();
                foreach (var item in tmp)
                {
                    stations[item].Add(i);
                }
            }

            var g = Enumerable.Range(0, n).Select(s => new HashSet<int>()).ToArray();
            for (int i = 1; i <= m; i++)
            {
                int num = stations[i].Count;
                if (stations[i].Count > 1)
                {
                    for (int j = 0; j < num; j++)
                    {
                        for (int k = j + 1; k < num; k++)
                        {
                            g[stations[i][j]].Add(stations[i][k]);
                            g[stations[i][k]].Add(stations[i][j]);
                        }
                    }
                }
            }

            var srcs = stations[s];
            var dess = stations[d];

            if (srcs.Intersect(dess).Any())
            {
                Console.WriteLine(1);
                return;
            }

            int min = int.MaxValue;

            var vs = new bool[n];
            foreach (var si in srcs)
            {
                vs[si] = true;
            }

            foreach (var si in srcs)
            {
                foreach (var di in dess)
                {
                    var cvs = new bool[n];
                    vs.CopyTo(cvs, 0);
                    min = Math.Min(min, Bfs(g, si, di, cvs));
                }
            }

            Console.WriteLine(min == int.MaxValue ? -1 : min);
        }

        static int Bfs(HashSet<int>[] g, int s, int d, bool[] vs)
        {
            var queue = new Queue<(int, int)>();
            queue.Enqueue((s, 1));

            while (queue.Count > 0)
            {
                var p = queue.Dequeue();
                foreach (var c in g[p.Item1])
                {
                    if (!vs[c])
                    {
                        if (c == d) return p.Item2 + 1;

                        vs[c] = true;
                        queue.Enqueue((c, p.Item2 + 1));
                    }
                }
            }

            return int.MaxValue;
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
            tmp = ReadIntArray();
            s = tmp[0];
            d = tmp[1];
            num = ReadIntArray().Length;

            Solve();
            reader.Close();
        }

        #endregion

        private static Queue<string> currentLineTokens = new Queue<string>();
        private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    }
}








