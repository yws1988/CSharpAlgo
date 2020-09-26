using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class ConnectedHorses
{
    public static int n, m, t, q;
    public static int[] ns;
    static HashSet<int> set=new HashSet<int>();
    static List<int>[] g;
    static int[] dx = { 1, 2, 2, 1, -1, -2, -2, -1 };
    static int[] dy = { 2, 1, -1, -2, -2, -1, 1, 2 };
    long mod = (long)Math.Pow(10, 9)+7;

    public void Solve()
    {
        g = Enumerable.Range(0, n*m).Select(s=>new List<int>()).ToArray();

        foreach (var p in set)
        {
            int tx = p/m;
            int ty = p%m;

            for (int j = 0; j < 8; j++)
            {
                int cx = tx + dx[j];
                int cy = ty + dy[j];
                int pa = cx * m + cy;
                if (IsSafe(cx, cy) && set.Contains(pa))
                {
                    g[p].Add(pa);
                }
            }
        }

        List<int> res = new List<int>();
        bool[] vs = new bool[n*m];

        foreach (var p in set)
        {
            if (!vs[p])
            {
                res.Add(Bfs(p, vs));
            }
        }

        long sum = 1;

        foreach (int r in res)
        {
            for (int i = 2; i <= r; i++)
            {
                sum = ((sum % mod )* i) % mod ;
            }
        }

        Console.WriteLine(sum);
    }

    static int Bfs(int r, bool[] vs)
    {
        vs[r] = true;
        Queue<int> queue = new Queue<int>();
        queue.Enqueue(r);
        int res = 0;
        while (queue.Count > 0)
        {
            res++;
            int p=queue.Dequeue();
            foreach (var c in g[p])
            {
                if (!vs[c])
                {
                    queue.Enqueue(c);
                    vs[c] = true;
                }
            }
        }

        return res;
    }

    static bool IsSafe(int x, int y)
    {
        return x >= 0 && x < n && y >= 0 && y < m;
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\ConnectedHorses.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        t = ReadInt();

        for (int i = 0; i < t; i++)
        {
            ns = ReadIntArray();
            n = ns[0];
            m = ns[1];
            q = ns[2];
            set.Clear();
            for (int j = 0; j < q; j++)
            {
                var tn = ReadIntArray();
                --tn[0];
                --tn[1];
                set.Add(tn[0] * m+tn[1]);
            }

            new ConnectedHorses().Solve();
        }
        
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
    #endregion
}