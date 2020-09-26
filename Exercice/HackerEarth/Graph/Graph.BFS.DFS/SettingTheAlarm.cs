using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class SettingTheAlarm
{
    public static int t;
    public static int[] s;
    public static int[] d;

    public void Solve()
    {
        int sh = s[0];
        int sm = s[1];
        int sd = s[2];

        int dh = d[0];
        int dm = d[1];
        int dd = d[2];

        List<int> res = new List<int>();

        for (int i = 0; i < 2; i++)
        {
            int sum = 0;
            int ah = 0;

            sum = Minute(sm, dm, i==0 ? true:false, ref ah);

            for (int j = 0; j < 2; j++)
            {
                int hsum = 0;
                int rd = sd;
                int rh = sh;

                rh += ah;

                if ((ah == 1 && rh == 12) || (ah == -1 && rh == 11))
                {
                    rd = rd == 0 ? 1 : 0;
                }

                if (rh == 13) {
                    rh = 1;
                }else if (rh == 0)
                {
                    rh = 12;
                }

                hsum = Hour(rh, dh, j==0 ? true:false, ref rd);

                if (rd != dd)
                {
                    hsum += 1;
                }

                res.Add(sum+hsum);
            }
        }

        Console.WriteLine(res.Min());
    }

    static int Minute(int ss, int dd, bool add, ref int ah)
    {
        if (ss == dd) return 0;
        if (add)
        {
            if (dd > ss) return dd - ss;

            ah = 1;
            return 60-ss+dd;
        }
        else
        {
            if (dd < ss) return ss - dd;

            ah = -1;
            return 60 - dd + ss;
        }
    }

    static int Hour(int ss, int dd, bool add, ref int rd)
    {
        if (ss == dd) return 0;
        if (add)
        {
            if (dd > ss)
            {
                if (dd == 12)
                {
                    rd = rd == 0 ? 1 : 0;
                }

                return dd - ss;
            }

            if (ss != 12)
            {
                rd = rd == 0 ? 1 : 0;
            }

            return 12 - ss + dd;
        }
        else
        {
            if (dd < ss)
            {
                if (ss == 12)
                {
                    rd = rd == 0 ? 1 : 0;
                }

                return ss - dd;
            }

            if (dd != 12)
            {
                rd = rd == 0 ? 1 : 0;
            }

            return 12 - dd + ss;
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\SettingTheAlarm.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        t = ReadInt();
        s = new int[t];
        d = new int[t];
        var instance = new SettingTheAlarm();
        for (int i = 0; i < t; i++)
        {
            var ss = reader.ReadLine().Split(new char[] { ':', ' ' });
            s = new int[] { int.Parse(ss[0]), int.Parse(ss[1]), ss[2] == "am" ? 0 : 1 };
            ss = reader.ReadLine().Split(new char[] { ':', ' ' });
            d = new int[] { int.Parse(ss[0]), int.Parse(ss[1]), ss[2] == "am" ? 0 : 1 };
            instance.Solve();
        }
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
    private static T[] Init<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }
    #endregion

    #region Functions
    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }
    #endregion
}