using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class WithoutStatement
    {
        public static int t;
        const int max = 731;
        static List<int>[] dp = new List<int>[max];
        static int[] idx = new int[max];

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\WithoutStatement.txt");
#endif
            t = int.Parse(input.ReadLine());

            for (int i = 1; i < max; i++)
            {
                var set = new HashSet<int>() { i };
                var list = new List<int>() { i };
                int temp = Value(i);
                while (true)
                {
                    if (!set.Contains(temp))
                    {
                        set.Add(temp);
                        list.Add(temp);
                        temp = Value(temp);
                    }
                    else
                    {
                        idx[i] = list.IndexOf(temp);
                        dp[i] = list;
                        break;
                    }
                }

            }

            for (int i = 0; i < t; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                var val = Value(tt[0]);
                var time = tt[1]-1;
                if (time <= idx[val])
                {
                    Console.WriteLine(dp[val][time]);
                }
                else
                {
                    int len = dp[val].Count();
                    int m = len - idx[val];
                    Console.WriteLine(dp[val][(time-idx[val]) % m + idx[val]]);
                }
            }
        }

        public static int Value(int value)
        {
            return GetDigits(value).Select(s => s * s).Sum();
        }

        public static IList<int> GetDigits(int source)
        {
            List<int> res = new List<int>();
            while (source > 0)
            {
                var digit = source % 10;
                source /= 10;
                res.Add(digit);
            }
            return res;
        }
    }
}
