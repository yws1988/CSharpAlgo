using System;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class DatBae
    {
        static int T;
        static int[][] output;

#if true
        static System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\DatBae.txt");
#endif

        public static void Start()
        {
            T = Convert.ToInt32(input.ReadLine());

            output = new int[5][];

            for (int i = 0; i < 5; i++)
            {
                output[i] = new int[1025];
                for (int j = 0; j < 1025; j++)
                {
                    output[i][j] = ((j % 32) >> i) & 1;
                }
            }

            for (int i = 0; i < T; i++)
            {
                if (i != 0) input.ReadLine();
                Solve();
            }
        }

        public static void Solve()
        {
            int n = int.Parse(input.ReadLine());
            int b = int.Parse(input.ReadLine());
            int f = int.Parse(input.ReadLine());

            int[] res = new int[n-b];

            for (int i = 0; i < 5; i++)
            {
                Console.WriteLine(string.Join("", output[i].Take(n)));
                var r = input.ReadLine().ToCharArray().Select(c => c - '0').ToArray();
                for (int k = 0; k < r.Length; k++)
                {
                    res[k] += (int)Math.Pow(2, i) * r[k];
                }
            }

            int[] ans = new int[b];

            int jj = 0;
            int idx = 0;
            for (int i = 0; i < n; i++)
            {
                if (idx < n-b)
                {
                    if (res[idx] != i % 32)
                    {
                        ans[jj] = i;
                        jj++;
                    }
                    else
                    {
                        idx++;
                    }
                }
                else
                {
                    ans[jj] = i;
                    jj++;
                }
            }

            Console.WriteLine(string.Join(" ", ans));
        }
    }
}
