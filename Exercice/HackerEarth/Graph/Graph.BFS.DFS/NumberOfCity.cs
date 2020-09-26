using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class NumberOfCity
{
    public static int n,m,a,b;
    public static int[] ns;
    public static string[] ss;
    public static int k;
    public static int[][] ps;
    public static List<int>[] g;


    public void Solve()
    {
        g = CreateListArray<int>(n*m);

        for (int i = 1; i <= n; i++)
        {
            for (int j = 1; j < 2*m; j++)
            {
                if(ss[i][j]==' ')
                {
                    int tj = j / 2;
                    int idx = m * (i-1) + tj;
                    if (j % 2 == 0)
                    {
                        g[idx-1].Add(idx);
                        g[idx].Add(idx-1);
                    }
                    else
                    {
                        g[idx].Add(idx+m);
                        g[idx+m].Add(idx);
                    }
                }
            }
        }

        Queue<int> queue = new Queue<int>();
        bool[] isr = new bool[n * m];

        for (int i = 0; i < k; i++)
        {
            int ti = (ps[i][0] - 1) * m + (ps[i][1] - 1);
            isr[ti] = true;
            queue.Enqueue(ti);
        }

        Queue<int> sq = new Queue<int>();
        int src = (a - 1) * m + b - 1;
        sq.Enqueue(src);
        bool[] mark = new bool[n * m];
        mark[src] = true;

        while (sq.Count() > 0)
        {
            int p = sq.Dequeue();
            foreach(int c in g[p])
            {
                if(!mark[c] && !isr[c])
                {
                    sq.Enqueue(c);
                    mark[c] = true;
                }
            }
        }

        int max = 0;
        bool[] vs = new bool[n * m];
        int[] dis = new int[n * m];

        while (queue.Count() > 0)
        {
            var p = queue.Dequeue();
            foreach (int c in g[p])
            {
                if (isr[c]) continue;

                if (!vs[c] && mark[c])
                {
                    queue.Enqueue(c);
                    vs[c] = true;
                    dis[c] = dis[p] + 1;
                    max = Math.Max(max, dis[c]);
                }
            }
        }

        Console.WriteLine(max);
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\NumberOfCity.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        ns = ReadIntArray();
        n = ns[0];
        m = ns[1];
        a = ns[2];
        b = ns[3];
        ss = ReadLines(n+1);
        k = ReadInt();
        ps = ReadIntMatrix(k);

        new NumberOfCity().Solve();
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
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}