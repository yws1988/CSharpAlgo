using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Program
{
    public static int n;
    static List<(int, int, int, int)> list = new List<(int, int, int, int)>();

    public static void Solve()
    {

        list.Add((0, 0, 0, 0));
        for (int i = 0; i < n; i++)
        {
            var tmp = ReadIntArray();
            list.Add((tmp[0], tmp[1], tmp[2], tmp[3]));
        }

        list = list.OrderBy(s => s.Item3).ToList();

        

        var isTops = new bool[n + 1];

        for (int i = 1; i <= n; i++)
        {
            bool isTop = true;
            for (int j = i + 1; j <= n; j++)
            {
                if (Incd(j, i))
                {
                    int weight = Math.Abs(list[j].Item4 - list[i].Item4);
                    graph[j].Add((i,weight));
                    isTop = false;
                    break;
                }
            }

            isTops[i] = isTop;
        }

        for (int i = 1; i <= n; i++)
        {
            if (isTops[i])
            {
                graph[0].Add((i, Math.Abs(list[i].Item4)));
            }
        }

        var graph = Enumerable.Range(0, n + 1).Select(s => new List<(int, int)>()).ToArray();

        var dp = new int[n + 1];
        CalMax(graph, 0, dp);

        var dpmax = new int[n + 1];
        CalMaxDifferent(graph, 0, dpmax, dp);

        Console.WriteLine(dpmax.Max());
    }

    static int CalMax(List<(int, int)>[] graph, int root, int[] dp)
    {
        if (graph[root].Count == 0)
        {
            return dp[root] = 0;
        }

        foreach (var child in graph[root])
        {
            dp[root] = Math.Max(dp[root], CalMax(graph, child.Item1, dp) + Math.Abs(child.Item2));
        }

        return dp[root];
    }

    static void CalMaxDifferent(List<(int,int)>[] graph, int root, int[] dpmax, int[] dp)
    {
        int max = 0;
        int smax = 0;

        foreach (var child in graph[root])
        {
            CalMaxDifferent(graph, child.Item1, dpmax, dp);

            int childSum = dp[child.Item1]+ Math.Abs(child.Item2);
            if (max <= childSum)
            {
                smax = max;
                max = childSum;
            }
        }

        dpmax[root] = max + smax;
    }

    

    static bool Incd(int i, int j)
    {
        var dis = Math.Sqrt(Math.Pow(list[i].Item1 - list[j].Item1, 2) + Math.Pow(list[i].Item2 - list[j].Item2, 2));
        if (dis+list[j].Item3 < list[i].Item3)
        {
            return true;
        }

        return false;
    }

    #region Main

    protected static TextReader reader;
    static void Main(string[] args)
    {
#if true
        reader = new StreamReader(@"IOFiles\test.txt");
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
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
    public static string ReadString() { return reader.ReadLine(); }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static double[][] ReadDoubleMatrix(int numberOfRows) { var matrix = new double[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadDoubleArray(); return matrix; }
    #endregion

}