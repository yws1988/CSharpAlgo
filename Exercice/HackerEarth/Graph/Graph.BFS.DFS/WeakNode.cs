using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class WeakNode
{
    public static int n, m;
    public static int[] ns;
    public static List<int>[] g;
    public static List<int> nums = new List<int>();

    public static void Solve()
    {

    }

    public static void DfsStack(int root, List<int>[] graph, bool[] vs)
    {
        var ps = InitNumberArray<int>(n, -1);
        var low = new int[n];
        var dist = new int[n];
        var ap = new bool[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(root);
        int step = 0;

        while (stack.Count > 0)
        {
            var p = stack.Pop();
            if (vs[p])
            {
                p = stack.Pop();

                foreach (var c in graph[p])
                {
                    if (c != ps[p])
                    {
                        low[p] = Math.Min(low[c], low[p]);
                    }
                }

                if (ps[p] == root && stack.Any(s => !vs[s]))
                {
                    ap[root] = true;
                }

                if (ps[p] != -1 && low[p] >= dist[p])
                {
                    ap[p] = true;
                }
            }
            else
            {
                vs[p] = true;
                dist[p] = ++step;
                low[p] = step;

                foreach (var c in graph[p])
                {
                    if (!vs[c])
                    {
                        stack.Push(c);
                        ps[c] = p;
                    }
                }
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (ap[i]) nums.Add(ns[i]);
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\WeakNode.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        
        ns = ReadIntArray();
        n = ns[0];
        m = ns[1];
        ns = ReadIntArray();
        g = CreateListArray<int>(n);
        int[] tns;
        for (int i = 0; i < m; i++)
        {
            tns = ReadIntArray();
            g[tns[0] - 1].Add(tns[1] - 1);
            g[tns[1] - 1].Add(tns[0] - 1);
        }

        Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static long ReadLong() { return long.Parse(ReadToken()); }
    public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
    public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
    {
        int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
        for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
        return ret;
    }
    public static string ReadString() { return reader.ReadLine(); }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
    public static string[][] ReadStringMatrix(int numberOfRows) { string[][] matrix = new string[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadAndSplitLine(); return matrix; }
    public static char[] ReadChars() { return reader.ReadLine().ToCharArray(); }
    private class SDictionary<TKey, TValue> : Dictionary<TKey, TValue>
    {
        public new TValue this[TKey key]
        {
            get { return ContainsKey(key) ? base[key] : default(TValue); }
            set { base[key] = value; }
        }
    }

    #endregion

    #region Functions
    private static T[] InitObjectArray<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }

    private static T[] InitNumberArray<T>(int size, T value) { var arr = new T[size]; for (int i = 0; i < size; i++) arr[i] = value; return arr; }

    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }

    private static void OutputArrayMatrix<T>(int[,] g, string sep = " ")
    {
        int m = g.GetLength(0);
        int n = g.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(g[i, j]+ (j==n-1 ? string.Empty : sep));
            }

            Console.WriteLine();
        }
    }

    private static void OutputArrayMatrix<T>(int[][] g, string sep = " ")
    {
        int n = g.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(string.Join(sep, g[i]));
        }
    }
    #endregion
}