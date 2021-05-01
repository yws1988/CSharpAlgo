using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CSharpAlgo.DataStructure.Heap;

namespace CSharpAlgo.Excercise.HackerEarth.Graph.Graph.MST
{
    public class QuantitativeCoefficient
    {
        public static int t, n, m;
        public static int[] ns;
        public static double[,] dis;

        #region Main

        public static TextReader Reader;
        static void MainF(string[] args)
        {
#if false
            Reader = new StreamReader(@"Graph\MST\test\test.txt");
#else
            Reader = new StreamReader(Console.OpenStandardInput());
#endif
            t = ReadInt();

            for (int i = 0; i < t; i++)
            {
                ns = ReadIntArray();
                n = ns[0];
                m = ns[1];

                dis = new double[n, n];
                for (int k = 0; k < n; k++)
                {
                    for (int h = k + 1; h < n; h++)
                    {
                        dis[k, h] = double.MaxValue;
                    }
                }

                List<Pair>[] graph = Enumerable.Range(0, n).Select(s => new List<Pair>()).ToArray(); ;

                for (int k = 0; k < m; k++)
                {
                    ns = ReadIntArray();
                    var s = ns[0] - 1;
                    var d = ns[1] - 1;
                    var weight = Math.Log10(ns[2]);
                    graph[s].Add(new Pair(s, d, weight) { We = ns[2] });
                    graph[d].Add(new Pair(d, s, weight) { We = ns[2] });
                }

                List<Pair> path;

                MinimumSpanningTree.GetMinimumSpanningTree(graph, out path);

                long result = 1;

                foreach (var item in path)
                {
                    result = (result * item.We) % 1000000007;
                }

                Console.WriteLine(result);
            }

            Reader.Close();
        }

        public class Pair : IComparable<Pair>
        {
            public int Src { get; set; }
            public int Des { get; set; }
            public double Weight { get; set; }

            public int We { get; set; }

            public Pair(int s, int d, double w)
            {
                Src = s;
                Des = d;
                Weight = w;
            }

            public int CompareTo(Pair other)
            {
                return this.Weight.CompareTo(other.Weight);
            }
        }

        public class MinimumSpanningTree
        {
            public static double GetMinimumSpanningTree(List<Pair>[] graph, out List<Pair> path)
            {
                path = new List<Pair>();
                int v = graph.Length;
                double minCost = 0;
                bool[] visited = new bool[v];

                var queue = new PriorityQueue<Pair>();
                foreach (var item in graph[0])
                {
                    queue.Enqueue(item);
                }
                visited[0] = true;
                while (queue.Count() > 0)
                {
                    var p = queue.Dequeue();

                    if (!visited[p.Des])
                    {
                        path.Add(p);
                        minCost += p.Weight;
                        visited[p.Des] = true;
                        foreach (var item in graph[p.Des])
                        {
                            queue.Enqueue(item);
                        }
                    }
                }

                return minCost;
            }
        }


        #endregion

        private static Queue<string> currentLineTokens = new Queue<string>();
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadStringArray()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static int[] ReadIntArray() { return ReadStringArray().Select(int.Parse).ToArray(); }
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
    }
}
