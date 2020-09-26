using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class FaceDetection
    {
        public static long[,] dp;
        public static int r;
        public static int c;
        public static int[][] nn;
        public static int q;
        public static int[] qn;

        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\FaceDetection.txt");
#endif
            var t= input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            r = t[0];
            c = t[1];
            nn = new int[r+1][];
            for (int i = 1; i <= r; i++)
            {
                var tl = input.ReadLine().Split(' ').Select(int.Parse).ToList();
                tl.Insert(0, 0);
                nn[i]=tl.ToArray();
            }

            dp = new long[r+1, c+1];

            for (int i = 1; i <= r; i++)
            {
                for (int j = 1; j <= c; j++)
                {
                    if(i!=1 || j != 1)
                    {
                        dp[i, j] = nn[i][j] + dp[i - 1, j] + dp[i, j - 1] - dp[i - 1, j - 1];
                    }
                }
            }

            q = int.Parse(input.ReadLine());

            for (int i = 0; i < q; i++)
            {
                var tt = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

                var res = dp[tt[2]+1, tt[3]+1] - dp[tt[0], tt[3] + 1] - dp[tt[2] + 1, tt[1]] + dp[tt[0], tt[1]];
                Console.WriteLine(res);
            }

            Console.Read();
        }
    }
}
