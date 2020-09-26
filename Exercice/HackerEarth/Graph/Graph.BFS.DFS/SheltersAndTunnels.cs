using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class SheltersAndTunnels
{
    public static int n, max;
    public static List<int>[] g;

    public void Solve()
    {
        max = g.Max(s => s.Count());
        var parents = g.Select((value, idx) => new { value, idx }).Where(s => s.value.Count() == max).Select(s => s.idx).ToList();

        Console.WriteLine(parents.Count());
        Console.WriteLine(string.Join(" ", parents.Select(s => s + 1).ToArray()));
    }

    #region Main

    protected static TextReader reader;

    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\SheltersAndTunnels.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        n = ReadInt();
        g = CreateListArray<int>(n);

        for (int i = 1; i < n; i++)
        {
            var ns = ReadIntArray();
            g[ns[0] - 1].Add(ns[1] - 1);
            g[ns[1] - 1].Add(ns[0] - 1);
        }

        new SheltersAndTunnels().Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    #endregion

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}