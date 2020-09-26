using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class Pylons
    {
        public static int T;
        public static int[] Nums;
        static int r;
        static int c;
        static int n;
        static List<int>[] g;
        static Stack<int> stack = new Stack<int>();

        public static void Start()
        {

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                Nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                r = Nums[0];
                c = Nums[1];

                SolveBruteForce(i + 1);
            }
        }


        public static void SolveBruteForce(int t)
        {
            n = r * c;
            g = new List<int>[n];

            for (int i = 0; i < r; i++)
            {
                for (int j = 0; j < c; j++)
                {
                    g[i * c + j] = new List<int>();

                    for (int ii = 0; ii < r; ii++)
                    {
                        for (int jj = 0; jj < c; jj++)
                        {
                            if (i != ii && j != jj && (i + j) != (ii + jj) && (i - j) != (ii - jj))
                            {
                                g[i * c + j].Add(ii * c + jj);
                            }
                        }
                    }
                }
            }

            for (int i = 0; i < n; i++)
            {
                Shuffle<int>(g[i]);
            }

            bool res = false;

            bool[] vst = new bool[n];

            res = false;
            for (int i = 0; i < n; i++)
            {
                bool[] vs = new bool[n];
                stack.Clear();
                res = Dfs(i, 1, vs);
                if (res) break;
            }

            if (res)
            {
                Console.WriteLine("Case #" + t + ": POSSIBLE");
                foreach (var item in stack.Reverse().ToArray())
                {
                    Console.WriteLine((item / c + 1) + " " + (item % c + 1));
                }
            }
            else
            {
                Console.WriteLine("Case #" + t + ": IMPOSSIBLE");
            }
        }

        static bool Dfs(int i, int level, bool[] vs)
        {
            vs[i] = true;
            stack.Push(i);
            if (level == n) return true;

            for (int h = 0; h < g[i].Count; h++)
            {
                if (!vs[g[i][h]])
                {
                    if (Dfs(g[i][h], level + 1, vs)) return true;
                }
            }

            stack.Pop();
            vs[i] = false;
            return false;
        }

        public static void Shuffle<T>(IList<T> list)
        {
            Random rng = new Random();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n);
                T value = list[k];
                list[k] = list[n];
                list[n] = value;
            }
        }
    }
}
