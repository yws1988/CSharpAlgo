using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class StrangeCity
{
    public static int n,q,d,dis=0;
    public static string s;
    public static List<int>[] g;
    public static int[] ins;
    public static int[] outs;
    public static long[] cs, ncs;
    public static List<long>[] tree;

    public static void Dfs(int s, bool[] vs)
    {
        vs[s] = true;
        ins[s] = dis++;

        foreach (int c in g[s])
        {
            if (!vs[c])
            {
                Dfs(c, vs);
            }
        }

        outs[s] = dis-1;
    }

    static List<long> MergeLists(List<long> lf, List<long> ls)
    {
        List<long> res = new List<long>();
        int lfs = lf.Count();
        int lss = ls.Count();

        int i = 0, j = 0;

        while(i<lfs && j < lss)
        {
            if (lf[i] > ls[j])
            {
                res.Add(ls[j]);
                j++;
            }
            else
            {
                res.Add(lf[i]);
                i++;
            }
        }

        while (i < lfs)
        {
            res.Add(lf[i]);
            i++;
        }

        while (j < lss)
        {
            res.Add(ls[j]);
            j++;
        }

        return res;
    }

    static List<long> BuildTree(int s, int e, int idx)
    {
        if (s == e)
        {
            tree[idx].Add(ncs[s]);
            return tree[idx];
        }

        int mid = (s + e) / 2;

        return tree[idx] = MergeLists(BuildTree(s, mid, 2*idx+1), BuildTree(mid+1, e, 2*idx+2));
    }

    public static long Solve(long r, long x, long y)
    {
        r--;

        x = x - ncs[ins[r]] - ncs[ins[d]];
        y = y - ncs[ins[r]] - ncs[ins[d]]+1;
        return Query(0, n-1, ins[r]+1, outs[r], 0, x, y);
    }

    static long Query(int s, int e, int qs, int qe, int idx, long x, long y)
    {
        if (qs > qe || s > qe || e < qs) return 0;
        if(s>=qs && e <= qe)
        {
            int tdy = tree[idx].BinarySearch(y);
            if (tdy < 0)
            {
                tdy = ~tdy - 1;
            }
            else
            {
                tdy--;
            }

            if (tdy < 0) return 0;

            int tdx = tree[idx].BinarySearch(x);
            if (tdx < 0)
            {
                tdx = ~tdx;
            }

            return tdy - tdx + 1;
        }

        int mid = (s + e) / 2;
        return Query(s, mid, qs, qe, idx * 2 + 1, x, y) + Query(mid+1, e, qs, qe, idx * 2 + 2, x, y);
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\StrangeCity.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        var ns = ReadIntArray();
        n = ns[0];
        q = ns[1];
        d = ns[2]-1;
        cs = ReadLongArray();

        g = CreateListArray<int>(n);
        int[] tt;
        for (int i = 0; i < n-1; i++)
        {
            tt = ReadIntArray();
            g[tt[0] - 1].Add(tt[1] - 1);
            g[tt[1] - 1].Add(tt[0] - 1);
        }

        ins = new int[n];
        outs = new int[n];
        bool[] vs = new bool[n];

        Dfs(d, vs);

        ncs = new long[n];
        for (int i = 0; i < n; i++)
        {
            ncs[ins[i]] = cs[i];
        }

        int tsize = (int)Math.Pow(2, Math.Ceiling(Math.Log(n, 2))) * 2;
        tree = CreateListArray<long>(tsize);
        BuildTree(0, n-1, 0);

        long last=0;
        long[] tmp;
        for (int i = 0; i < q; i++)
        {
            tmp = ReadLongArray();

            last = Solve(tmp[0] ^ last, tmp[1] ^ last, tmp[2] ^ last);
            Console.WriteLine(last);
        }
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static long[] ReadLongArray() { return ReadAndSplitLine().Select(long.Parse).ToArray(); }
   
    #endregion

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}