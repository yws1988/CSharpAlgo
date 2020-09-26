using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class MancunianAndLiverbirdGoBarHopping
{
    public static int n, op;
    public static int[] ns;
    public static string[][] ss;
    static int[] gc;
    static int[] rgc;

    public void Solve()
    {
        gc = new int[n];
        Process(ns, gc);

        for (int i = 0; i < n-1; i++)
        {
            ns[i] = ns[i] == 1 ? 0 : 1;
        }
        rgc = new int[n];
        Process(ns, rgc);

        bool isG = true;
        for (int i = 0; i < op; i++)
        {
            if (ss[i][0] == "Q")
            {
                int val = int.Parse(ss[i][1]);
                if (isG)
                {
                    Console.WriteLine(gc[val-1]);
                }
                else
                {
                    Console.WriteLine(rgc[val-1]);
                }
            }
            else
            {
                isG = !isG;
            }
        }

        Console.Read();
    }

    static void Process(int[] os, int[] rs)
    {
        rs[0] = 1;

        int seed = 1;
        for (int i = 0; i < n - 1; i++)
        {
            if (os[i] == 0)
            {
                seed++;
            }
            else
            {
                seed = 1;
            }
            rs[i + 1] = seed;
        }

        seed = 0;
        for (int i = n - 2; i >= 0; i--)
        {
            if (os[i] == 1)
            {
                seed++;
            }
            else
            {
                seed = 0;
            }
            rs[i] += seed;
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\MancunianAndLiverbirdGoBarHopping.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        n = ReadInt();
        ns = ReadIntArray();
        op = ReadInt();
        ss = ReadStringMatrix(op);
 
        new MancunianAndLiverbirdGoBarHopping().Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static string[][] ReadStringMatrix(int numberOfRows) { string[][] matrix = new string[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadAndSplitLine(); return matrix; }
    #endregion
}