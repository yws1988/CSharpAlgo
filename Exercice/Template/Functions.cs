namespace Utils
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class Functions
    {
        public static T[] InitObjectArray<T>(int size) where T : new() { var ret = new T[size]; for (int i = 0; i < size; i++) ret[i] = new T(); return ret; }

        public static T[] InitNumberArray<T>(int size, T value) { var arr = new T[size]; for (int i = 0; i < size; i++) arr[i] = value; return arr; }

        public static List<T>[] CreateListArray<T>(int n)
        {
            return Enumerable.Range(0, n).Select(s => new List<T>()).ToArray();
        }

        public static void OutputArrayMatrix<T>(int[,] g, string sep = " ")
        {
            int m = g.GetLength(0);
            int n = g.GetLength(1);

            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    Console.Write(g[i, j] + (j == n - 1 ? string.Empty : sep));
                }

                Console.WriteLine();
            }
        }

        public static void OutputArrayMatrix<T>(int[][] g, string sep = " ")
        {
            int n = g.GetLength(0);

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(string.Join(sep, g[i]));
            }
        }
    }
}
