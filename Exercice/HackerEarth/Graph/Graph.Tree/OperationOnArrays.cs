namespace CSharpAlgo.Excercise.HackerEarth.Graph.Graph.Tree
{
    using CSharpAlgo.Graph.Tree;
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class OperationOnArrays
    {
        public static int n, x, q;
        public static int[] ns;

        public static void Solve()
        { 
            var tmp = ReadIntArray();
            n = tmp[0];
            x = tmp[1];

            ns = ReadIntArray();
            q = ReadInt();

            BinaryIndexedTree binaryIndexedTree = new BinaryIndexedTree(n);

            for (int i = 0; i < n; i++)
            {
                if (ns[i] == x)
                {
                    binaryIndexedTree.update(i, 1);
                }
            }

            List<int> res = new List<int>();

            for (int i = 0; i < q; i++)
            {
                tmp = ReadIntArray();
                int type = tmp[0];
                if (type == 1)
                {
                    int l = tmp[1];
                    int r = tmp[2];
                    int k = tmp[3];

                    int low = 1;
                    int high = n;

                    int numL = binaryIndexedTree.query(l-1);
                    int numR = binaryIndexedTree.query(r-1);

                    if (numR < numL + k)
                    {
                        int sum = numL + k;

                        int mid=0;

                        while (low < high)
                        {
                            mid = (low + high) >> 1;

                            if (binaryIndexedTree.query(mid) >= sum)
                            {
                                high = mid;
                            }
                            else
                            {
                                low = mid + 1;
                            }
                        }

                        res.Add(mid+1);
                    }
                    else
                    {
                        res.Add(-1);
                    }
                }
                else
                {
                    int index = tmp[1];
                    int value = tmp[2];

                    if (ns[index] == x && value != x)
                    {
                        binaryIndexedTree.update(index, -1);
                    }

                    if (ns[index] != x && value == x)
                    {
                        binaryIndexedTree.update(index, 1);
                    }
                }
            }

            foreach (var i in res)
            {
                Console.WriteLine(i);
            }
        }

        #region Main

        public static TextReader Reader;
        static void Main(string[] args)
        {
#if true
            Reader = new StreamReader(@"test\test.txt");
#else
            Reader = new StreamReader(Console.OpenStandardInput());
#endif
            Solve();
            Reader.Close();
        }

        #endregion

        private static Queue<string> currentLineTokens = new Queue<string>();
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadStringArray()); return currentLineTokens.Dequeue(); }
        private static string[] ReadAndSplitLine() { return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadStringArray().Select(int.Parse).ToArray(); }
        public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
        public static string ReadString() { return Reader.ReadLine(); }
        public static string[] ReadStringArray() { return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = Reader.ReadLine().Trim(); return lines; }

        public static List<int>[] CreateListArray(int n, int[][] arr, bool isDirected = false)
        {
            var graph = Enumerable.Range(0, n).Select(s => new List<int>()).ToArray();
            foreach (var item in arr)
            {
                int src = item[0];
                int des = item[1];
                graph[src].Add(des);

                if (!isDirected)
                {
                    graph[des].Add(src);
                }
            }

            return graph;
        }

        public class Node
        {
            public int Num { get; set; }
            public int Parent { get; set; }
            public int Level { get; set; }
            public int Sibling { get; set; }
            public int Capacity { get; set; }

            public Node(int num, int parent, int level, int sibling, int capacity)
            {
                Num = num;
                Parent = parent;
                Level = level;
                Sibling = sibling;
                Capacity = capacity;
            }
        }
    }

}
