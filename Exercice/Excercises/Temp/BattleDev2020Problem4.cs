using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Problem4
{
    public static int n;
    public static string[] ns;
    public static string[] ss;
    static Dictionary<Tuple<string, string>, string> dic;

    public static void Solve()
    {
        dic = new Dictionary<Tuple<string, string>, string>
        {
            {new Tuple<string, string>("feu" , "eau"), "eau"},
            {new Tuple<string, string>("eau" , "eau"), "eau"},
            {new Tuple<string, string>("feu" , "plante"), "feu"},
            {new Tuple<string, string>("plante" , "feu"), "feu"},
            {new Tuple<string, string>("feu" , "glace"), "feu"},
            {new Tuple<string, string>("glace" , "feu"), "feu"},
            {new Tuple<string, string>("plante" , "eau"), "plante"},
            {new Tuple<string, string>("eau" , "plante"), "plante"},
            {new Tuple<string, string>("sol" , "eau"), "sol"},
            {new Tuple<string, string>("eau" , "sol"), "sol"},
            {new Tuple<string, string>("plante" , "poison"), "plante"},
            {new Tuple<string, string>("poison" , "plante"), "plante"},
            {new Tuple<string, string>("sol" , "plante"), "sol"},
            {new Tuple<string, string>("plante" , "sol"), "sol"},
            {new Tuple<string, string>("plante" , "vol"), "plante"},
            {new Tuple<string, string>("vol" , "plante"), "plante"},
        };

        IEnumerable<IEnumerable<int>> result =
    GetPermutations(Enumerable.Range(0, n), n);

        bool isOk = false;
        
        foreach (var item in result)
        {
            
        }

        if (isOk)
        {

        }
    }

    static IEnumerable<IEnumerable<T>>
    GetPermutations<T>(IEnumerable<T> list, int length)
    {
        if (length == 1) return list.Select(t => new T[] { t });

        return GetPermutations(list, length - 1)
            .SelectMany(t => list.Where(e => !t.Contains(e)),
                (t1, t2) => t1.Concat(new T[] { t2 }));
    }

    static bool isOk()
    {
        int id = 0;
        for (int i = 0; i < n; i++)
        {
            var key = new Tuple<string, string>(ns[i], ss[id]);
            if (dic.ContainsKey(key))
            {
                if (dic[key] == ns[i])
                {
                    id++;
                }
            }
            else
            {
                id++;
            }
        }

        if (id == n) return false;

        return true;
    }

    #region Main

    protected static TextReader reader;
    static void MainF(string[] args)
    {
#if false
        reader = new StreamReader(@"test\test.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        Console.WriteLine("dddd");
        n = ReadInt();
        ns = ReadAndSplitLine();
        ss = ReadAndSplitLine();

        Solve();
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

    #endregion

    #region Functions
    private static T[] InitObjectArray<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }

    private static T[] InitNumberArray<T>(int size, T value) { var arr = new T[size]; for (int i = 0; i < size; i++) arr[i] = value; return arr; }

    private static List<T>[] CreateListArray<T>(int n)
    {
        return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
    }

    private static void OutputArrayMatrix<T>(int[,] g, string sep = " ")
    {
        int m = g.GetLength(0);
        int n = g.GetLength(1);

        for (int i = 0; i < m; i++)
        {
            for (int j = 0; j < n; j++)
            {
                Console.Write(g[i, j]+ (j==n-1 ? string.Empty : sep));
            }

            Console.WriteLine();
        }
    }

    private static void OutputArrayMatrix<T>(int[][] g, string sep = " ")
    {
        int n = g.GetLength(0);

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(string.Join(sep, g[i]));
        }
    }
    #endregion
}