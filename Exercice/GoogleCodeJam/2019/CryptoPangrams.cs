using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using input = System.Console;

namespace CodeJam
{
    public class CryptoPangrams
    {
        public static int T;

        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int np = int.Parse(input.ReadLine().Split(' ')[1]);
                string str = input.ReadLine();

                Solve(i, np, str);
            }

            //Console.Read();
        }

        public static void Solve(int t, int np, string str)
        {
            BigInteger[] ns = str.Split(' ').Select(BigInteger.Parse).ToArray();
            List<BigInteger> list = new List<BigInteger>();

            int tt = 0;
            BigInteger div = 1;
            for (int i = 0; i < np-1; i++)
            {
                if(ns[i]!=ns[i + 1])
                {
                    tt = i;
                    div = GreatestCommonDivisor(ns[i], ns[i + 1]);
                }
            }

            list.Add(div);
            BigInteger[] nums = new BigInteger[np + 1];

            nums[tt] = ns[tt] / div;
            for (int j = tt+1; j <= np; j++)
            {
                nums[j] = ns[j-1]/nums[j-1];
            }

            for (int j = tt-1; j>=0; j--)
            {
                nums[j] = ns[j]/nums[j+1];
            }

            var dic = nums.Distinct().OrderBy(s=>s).Select((s, i) => new { s, i }).ToDictionary(a => a.s, a => (char)(a.i + 'A'));

            var chars = nums.Select(s => dic[s]).ToArray();
            Output(t + 1, new string(chars));
        }

        public static BigInteger GreatestCommonDivisor(BigInteger m, BigInteger n)
        {
            while (n > 0)
            {
                BigInteger t = n;
                n = m % n;
                m = t;
            }

            return m;
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }
}
