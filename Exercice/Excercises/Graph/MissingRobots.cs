namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class MissingRobots
    {
        public static int m, n, sr, dr;
        static List<string> direction = new List<string>() { "D", "G", "T" };

        public static void Solve()
        {
            var dic = new Dictionary<(int, string), List<int>>();
            for (int i = 0; i < m; i++)
            {
                var tmp = ReadAndSplitLine();
                var key = (int.Parse(tmp[0]), tmp[1]);
                if (dic.ContainsKey(key))
                {
                    dic[key].Add(int.Parse(tmp[2]));
                }
                else
                {
                    dic.Add(key, new List<int>() { int.Parse(tmp[2]) });
                }
            }

            var vs = new HashSet<(int, int, string)>();
            var path = new List<string>();

            var queue = new Queue<Node>();

            foreach (var d in direction)
            {
                if (dic.ContainsKey((sr, d)) && dic.ContainsKey((dr, d)))
                {
                    var node = new Node(sr, dr, d);
                    node.Path.Add(d);
                    queue.Enqueue(node);

                    vs.Add((sr, dr, d));
                    vs.Add((dr, sr, d));
                }
            }

            bool found = false;
            List<string> res = null;

            while (queue.Count > 0)
            {
                var cNode = queue.Dequeue();

                var key1 = (cNode.s1, cNode.Dir);
                var key2 = (cNode.s2, cNode.Dir);

                if (dic[key1].Intersect(dic[key2]).Any())
                {
                    res = cNode.Path;
                    found = true;
                    break;
                }

                foreach (var csr1 in dic[key1])
                {
                    foreach (var csr2 in dic[key2])
                    {
                        foreach (var d in direction)
                        {
                            if (!vs.Contains((csr1, csr2, d)) && dic.ContainsKey((csr1, d)) && dic.ContainsKey((csr2, d)))
                            {
                                var node = new Node(csr1, csr2, d);
                                node.Path = new List<string>(cNode.Path);
                                node.Path.Add(d);
                                queue.Enqueue(node);

                                vs.Add((csr1, csr2, d));
                                vs.Add((csr2, csr1, d));
                            }
                        }
                    }
                }
            }

            if (found)
            {
                Console.WriteLine(string.Join("", res));
            }
            else
            {
                Console.WriteLine("fail");
            }
        }

        class Node
        {
            public int s1 { get; set; }
            public int s2 { get; set; }
            public string Dir { get; set; }
            public List<string> Path { get; set; } = new List<string>();

            public Node(int pso, int pst, string sdir)
            {
                s1 = pso;
                s2 = pst;
                Dir = sdir;
            }
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
            sr = tmp[0];
            dr = tmp[1];

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

        #endregion

    }
}


