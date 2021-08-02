namespace CSharpAlgo.Excercise.HackerEarth.Graph.Graph.Tree
{
    using System;
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;

    public class PopulationOutburst
    {
        public static int n, rc0;

        public static void Solve()
        {
            var tmp = ReadIntArray();
            n = tmp[0];
            rc0 = tmp[1];

            var queue = new Queue<Node>();
            queue.Enqueue(new Node(0, -1, 0, 1, rc0));
            
            int numOfElement = 1;

            while (queue.Count() > 0)
            {
                var node = queue.Dequeue();

                if (node.Parent != -1)
                {
                    Console.WriteLine($"{node.Parent} {node.Level} {node.Sibling}");
                }

                int sibling = 1;
                while (sibling <= node.Capacity && numOfElement <= n)
                {
                    var temp = ReadIntArray();
                    queue.Enqueue(new Node(temp[0], node.Num, node.Level + 1, sibling, temp[1]));
                    sibling++;
                    numOfElement++;
                }
            }
        }

        #region Main

        public static TextReader Reader;
        static void MainF(string[] args)
        {
#if false
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
