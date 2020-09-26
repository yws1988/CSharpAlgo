using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class ArrayConversion
    {
        public static int t;
        public static int n;
        public static int k;
        public static int[] ns;
        public static Dictionary<int, bool>[] dp;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\ArrayConversion.txt");
#endif
            t = int.Parse(input.ReadLine());

            for (int i = 0; i < t; i++)
            {
                var tmp = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                n = tmp[0];
                k = tmp[1];
                ns = input.ReadLine().Split(' ').Select(s=>int.Parse(s)).ToArray();

                Solve();
            }
            
            //Console.Read();
        }

        public static void Solve()
        {
            
            dp = new Dictionary<int, bool>[n];
            for (int i = 0; i < n; i++)
            {
                dp[i] = new Dictionary<int, bool>();
            }

            Console.WriteLine(Solve(0, k) ? "YES":"NO");
        }

        static bool Solve(int i, int s)
        {
            if (i == n && s == 0) return true;

            if (i>=n) return false;

            if (dp[i].ContainsKey(s)) return dp[i][s];

            return dp[i][s] = Solve(i + 1, s - ns[i]) || Solve(i + 1, s + ns[i]) || Solve(i + 1, s - (ns[i]+i+1)) || Solve(i + 1, s - (ns[i]-i-1));
        }
    }
}
