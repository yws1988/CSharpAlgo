namespace CSharpAlgo.Excercise.Excercises.BruteForce
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.IO;

    public class FightAttemptPermutation
    {
        public static int n, m;
        public static string ns, ms;

        public static void Solve()
        {
            var dic = new Dictionary<char, char>
        {
            { 'E', 'F' },
            { 'F', 'P' },
            { 'P', 'E' }
        };

            string win = string.Empty;
            string equ = string.Empty;
            string lose = string.Empty;

            var list = new char[] { 'f', 'e', 'd', 'd' };
            var idx = Enumerable.Range(0, n);
            var permutations = GetPermutations(idx, n);

            foreach (var permutation in permutations)
            {
                var newString = permutation.Select(s => ns[s]).ToArray();

                int i = 0, j = 0;
                while (i < n && j < m)
                {
                    if (newString[i] == ms[j])
                    {
                        i++;
                        j++;
                    }
                    else
                    {
                        if (dic[newString[i]] == ms[j])
                        {
                            j++;
                        }
                        else
                        {
                            i++;
                        }
                    }
                }

                string result = new string(newString);

                if (i == n && j == m)
                {
                    equ = result;
                }
                else if (j == m)
                {
                    win = result;
                    break;
                }
                else
                {
                    lose = new string(newString);
                }
            }

            if (win != string.Empty)
            {
                Console.WriteLine("+" + win);
            }
            else if (equ != string.Empty)
            {
                Console.WriteLine("=" + equ);
            }
            else
            {
                Console.WriteLine("-" + lose);
            }
        }

        public static IEnumerable<IEnumerable<T>> GetPermutations<T>(IEnumerable<T> list, int length)
        {
            if (length == 1) return list.Select(t => new T[] { t });

            return GetPermutations(list, length - 1)
                .SelectMany(t => list.Where(e => !t.Contains(e)),
                    (t1, t2) => t1.Concat(new T[] { t2 }));
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
            n = ReadInt();
            ns = ReadString();
            m = ReadInt();
            ms = ReadString();

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
        #endregion
    }
}
