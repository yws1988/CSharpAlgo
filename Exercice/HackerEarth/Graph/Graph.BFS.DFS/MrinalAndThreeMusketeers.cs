using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MrinalAndThreeMusketeers
{
    public static int n,m;
    public static List<int>[] g;
    static int min;

    public void Solve()
    {
        bool[] vs = new bool[n];
        min = int.MaxValue;

        List<int> res = new List<int>();
        for (int i = 0; i < n; i++)
        {
            res.Clear();
            Dfs(i, i, 0, vs, res);
            vs[i] = true;
        }

        if(min == int.MaxValue)
        {
            Console.WriteLine(-1);
        }
        else
        {
            Console.WriteLine(min);
        }
    }

    static int GetDegrees(List<int> res)
    {
        return g[res[0]].Count() + g[res[1]].Count() + g[res[2]].Count() - 6;
    }

    static void Dfs(int src, int root, int level, bool[] vs, List<int> res)
    {
        if (level == 3 && src == root)
        {
            min = Math.Min(min, GetDegrees(res));
            return;
        }

        if (level >= 3) return;

        foreach (int c in g[src])
        {
            if (!vs[c])
            {
                vs[c] = true;
                res.Add(c);

                Dfs(c, root, level + 1, vs, res);

                res.RemoveAt(res.Count() - 1);
                vs[c] = false;
            }
        }
    }

    #region Main

    protected static TextReader reader;

    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\MrinalAndThreeMusketeers.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        var ns = ReadIntArray();
        n = ns[0];
        m = ns[1];

        g = CreateListArray<int>(n);

        for (int i = 0; i < m; i++)
        {
            ns = ReadIntArray();
            g[ns[0] - 1].Add(ns[1] - 1);
            g[ns[1] - 1].Add(ns[0] - 1);
        }

        new MrinalAndThreeMusketeers().Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }

    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    #endregion

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}