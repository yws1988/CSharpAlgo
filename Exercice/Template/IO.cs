namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Globalization;
    using System.IO;
    using System.Linq;

    public static class IO
    {
        public static TextReader Reader;

        private static Queue<string> currentLineTokens = new Queue<string>();
        public static string[] ReadStringArray() { return Reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
        public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadStringArray()); return currentLineTokens.Dequeue(); }
        public static int ReadInt() { return int.Parse(ReadToken()); }
        public static long ReadLong() { return long.Parse(ReadToken()); }
        public static double ReadDouble() { return double.Parse(ReadToken(), CultureInfo.InvariantCulture); }
        public static int[] ReadIntArray() { return ReadStringArray().Select(int.Parse).ToArray(); }
        public static long[] ReadLongArray() { return ReadStringArray().Select(long.Parse).ToArray(); }
        public static double[] ReadDoubleArray() { return ReadStringArray().Select(s => double.Parse(s, CultureInfo.InvariantCulture)).ToArray(); }
        public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
        public static int[][] ReadAndTransposeIntMatrix(int numberOfRows)
        {
            int[][] matrix = ReadIntMatrix(numberOfRows); int[][] ret = new int[matrix[0].Length][];
            for (int i = 0; i < ret.Length; i++) { ret[i] = new int[numberOfRows]; for (int j = 0; j < numberOfRows; j++) ret[i][j] = matrix[j][i]; }
            return ret;
        }
        public static string ReadString() { return Reader.ReadLine(); }
        public static string[] ReadLines(int quantity) { string[] lines = new string[quantity]; for (int i = 0; i < quantity; i++) lines[i] = Reader.ReadLine().Trim(); return lines; }
        public static string[][] ReadStringMatrix(int numberOfRows) { string[][] matrix = new string[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadStringArray(); return matrix; }
        public static char[] ReadChars() { return Reader.ReadLine().ToCharArray(); }
        public static char[][] ReadCharsMatrix(int numberOfRows) { char[][] matrix = new char[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadChars(); return matrix; }

    }
}
