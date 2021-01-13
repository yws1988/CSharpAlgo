using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;

public class Program
{
    public static int n;
    static List<(int, int, int, int)> list = new List<(int, int, int, int)>();

    public static void Solve()
    {
       
        
    }

    #region Main

    protected static TextReader reader;
    static void Main(string[] args)
    {
#if true
        reader = new StreamReader(@"IOFiles\test.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        n = ReadInt();

        Solve();
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
    public static string ReadString() { return reader.ReadLine(); }
    public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = reader.ReadLine().Trim(); return lines; }
    public static double[] ReadDoubleArray() { return ReadAndSplitLine().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
    public static double[][] ReadDoubleMatrix(int numberOfRows) { var matrix = new double[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadDoubleArray(); return matrix; }
    #endregion

}