using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class ArrayShuffling
    {
        public static int N;
        public static int[][] nn;
        static int[,,] dp=new int[100,101,101];
        static List<Tuple<int, int>> pairs = new List<Tuple<int, int>>(); 

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\ArrayShuffling.txt");
#endif
            N = int.Parse(input.ReadLine());
            nn = new int[3][];
            nn[0] = input.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            nn[1] = input.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
            nn[2] = input.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            for (int i = 0; i < 100; i++)
            {
                for (int j = 0; j < 101; j++)
                {
                    for (int k = 0; k < 101; k++)
                    {
                        dp[i, j, k] = -1;
                    }
                }
            }

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (i != j)
                    {
                        pairs.Add(new Tuple<int, int>(i, j));
                    }
                }
            }

            Console.WriteLine(MaxUtil(0, 0, 0));

            Console.Read();
        }

       static int MaxUtil(int pos, int m, int n)
       {
            if (pos >= N) return 0;
            if (dp[pos, m, n] != -1) return dp[pos, m, n];

            int res = MaxUtil(pos+1, m, n);

            foreach (var ps in pairs)
            {
                int ff = ps.Item1;
                int fs = ps.Item2;

                if(nn[ff][pos]>=m && nn[fs][pos] >= n)
                {
                    res = Math.Max(res, MaxUtil(pos+1, nn[ff][pos], nn[fs][pos])+2);
                }

                if (nn[ff][pos] >= m)
                {
                    res = Math.Max(res, MaxUtil(pos + 1, nn[ff][pos], n)+1);
                }

                if (nn[fs][pos] >= n)
                {
                    res = Math.Max(res, MaxUtil(pos + 1, m, nn[fs][pos])+1);
                }
            }

            return dp[pos, m, n]=res;
       }
    }
}
