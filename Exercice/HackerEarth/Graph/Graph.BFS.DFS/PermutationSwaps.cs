using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class PermutationSwaps
{
    public static int n, m, t;
    public static int[] ns, nd, gn;
    static List<int>[] g;

    public void Solve()
    {
        Queue<int> queue = new Queue<int>();

        gn = new int[n+1];
        bool[] vs = new bool[n+1];
        int num = 1;
        for (int i = 1; i <= n; i++)
        {
            if (!vs[i])
            {
                queue.Enqueue(i);
                while (queue.Count() > 0)
                {
                    int c = queue.Dequeue();
                    gn[c] = num;
                    vs[c] = true;
                    foreach (int cc in g[c])
                    {
                        if (!vs[cc])
                        {
                            queue.Enqueue(cc);
                        }
                    }
                }

                num++;
            }
        }

        for (int i = 0; i < n; i++)
        {
            if (ns[i] != nd[i] && gn[ns[i]] != gn[nd[i]])
            {
                Console.WriteLine("NO");
                return;
            }
        }

        Console.WriteLine("YES");
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\PermutationSwaps.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        t = ReadInt();

        for (int i = 0; i < t; i++)
        {
            var ts = ReadIntArray();
            n = ts[0];
            m = ts[1];
            ns = ReadIntArray();
            nd = ReadIntArray();
            g = CreateListArray<int>(n+1);

            for (int j = 0; j < m; j++)
            {
                var tn = ReadIntArray();
                var x=--tn[0];
                var y=--tn[1];

                g[ns[x]].Add(ns[y]);
                g[ns[y]].Add(ns[x]);
            }

            new PermutationSwaps().Solve();
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

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}