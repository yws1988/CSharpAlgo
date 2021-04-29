namespace CSharpAlgo.Excercise.HackerEarth.Graph.Graph.MST
{
        using System;
        using System.Collections.Generic;
        using System.IO;
        using System.Linq;
        using CSharpAlgo.DataStructure.Geometry;
        using CSharpAlgo.Graph.Tree;

        public class MarsTrip
        {
            public static int t, n, m;
            public static int[] ns;
            public static int[,] dis;

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


                    var points = new Point3D<int>[n];

                    for (int j = 0; j < n; j++)
                    {
                        ns = ReadIntArray();
                        points[j] = new Point3D<int>(ns[0], ns[1], ns[2]);
                    }

                    dis = new int[n, n];
                    for (int k = 0; k < n; k++)
                    {
                        for (int h = k + 1; h < n; h++)
                        {
                            dis[k, h] = Distance(points[k], points[h]);
                        }
                    }

                    Console.WriteLine(MaximumDistanceForNGroupsWithUnionFind.getMaxDistance(dis, m));
                }

                Reader.Close();
            }

            static int Distance(Point3D<int> x, Point3D<int> y)
            {
                return (int)(Math.Pow(x.X - y.X, 2) + Math.Pow(x.Y - y.Y, 2) + Math.Pow(x.Z - y.Z, 2));
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
