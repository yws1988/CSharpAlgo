
namespace CSharpAlgo.Excercise.Excercises.DivideAndConquer
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class ClassementBattle
    {
        public static int n;

        public static void Solve()
        {
            List<Node> ns = new List<Node>();

            for (int i = 0; i < n; i++)
            {
                var tmp = ReadIntArray();
                ns.Add(new Node(i + 1, tmp[0], tmp[1], tmp[2]));
            }

            var res = new List<int>();
            Divide(ns, res);

            Console.WriteLine(string.Join(" ", res));
        }

        static void Divide(List<Node> list, List<int> res)
        {
            if (list.Count == 0)
            {
                return;
            }

            var lList = new List<Node>();
            var rList = new List<Node>();


            for (int i = 1; i < list.Count; i++)
            {
                if (list[0].CompareTo(list[i]) <= 0)
                {
                    rList.Add(list[i]);
                }
                else
                {
                    lList.Add(list[i]);
                }
            }

            Divide(lList, res);
            res.Add(list[0].idx);
            Divide(rList, res);
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
            n = ReadInt();


            Solve();
            reader.Close();
        }

        #endregion

        #region Read / Write

        private static Queue<string> currentLineTokens = new Queue<string>();

        private static string[] ReadAndSplitLine()
        {
            return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries);
        }

        public static string ReadToken()
        {
            while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine());
            return currentLineTokens.Dequeue();
        }

        public static int ReadInt()
        {
            return int.Parse(ReadToken());
        }

        public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }



        #endregion
    }

    class Node : IComparable<Node>
    {
        public int idx { get; set; }
        public int a { get; set; }
        public int b { get; set; }
        public int c { get; set; }

        public Node(int tidx, int ta, int tb, int tc)
        {
            idx = tidx;
            a = ta;
            b = tb;
            c = tc;
        }

        public int CompareTo(Node other)
        {
            return Math.Sign(a - other.a) + Math.Sign(b - other.b) + Math.Sign(c - other.c);
        }
    }
}
