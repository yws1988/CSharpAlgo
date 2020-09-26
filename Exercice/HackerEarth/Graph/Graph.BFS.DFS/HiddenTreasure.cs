using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class HiddenTreasure
{
    public static int n;
    public static char[] cs;
    public static List<int>[] g;
    static int[] vowels = { 'a', 'e', 'i', 'o', 'u' };
    static int[] depth;
    static int res = 0;
    

    public static void Solve()
    {
        bool[] vs = new bool[n];
        Dfs();
    }

    static void Dfs()
    {
        bool[] vs = new bool[n];
        bool[] inStack = new bool[n];
        Stack<int> stack = new Stack<int>();
        stack.Push(0);
        inStack[0] = true;

        while (stack.Count > 0)
        {
            int p = stack.Peek();
            vs[p] = true;

            bool isPop = true;
            
            foreach (int c in g[p])
            {
                if (!vs[c])
                {
                    stack.Push(c);
                    inStack[c] = true;
                    isPop = false;
                }
            }

            if (isPop)
            {
                int s = stack.Pop();
                inStack[s] = false;
                int fm = 0, sm = 0;

                foreach (int c in g[s])
                {
                    if (!inStack[c])
                    {
                        if (depth[c] >= fm)
                        {
                            sm = fm;
                            fm = depth[c];
                        }
                        else if (depth[c] > sm)
                        {
                            sm = depth[c];
                        }
                    }
                }

                int addOne = vowels.Any(d => d == cs[s]) ? 1 : 0;
                depth[s] = fm + addOne;

                res = Math.Max(depth[s] + sm, res);
            }
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\HiddenTreasure.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        
        n = ReadInt();
        cs = ReadChars();
        g = CreateListArray<int>(n);

        int[] tmp = new int[2];

        for (int i = 0; i < n-1; i++)
        {
            tmp = ReadIntArray();
            g[tmp[0] - 1].Add(tmp[1] - 1);
            g[tmp[1] - 1].Add(tmp[0] - 1);
        }

        depth = InitNumberArray(n, -1);

        Solve();
        Console.WriteLine(res);
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static char[] ReadChars() { return reader.ReadLine().ToCharArray(); }
    private static T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }
    #endregion

    #region Functions
    private static T[] InitNumberArray<T>(int size, T value) { var arr = new T[size]; for (int i = 0; i < size; i++) arr[i] = value; return arr; }

    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}