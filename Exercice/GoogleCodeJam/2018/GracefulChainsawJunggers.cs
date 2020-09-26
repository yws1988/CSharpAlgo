using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class GracefulChainsawJunggers
    {
        public static int T;
        public static int[][] Nums;
        public static int R;
        public static int B;
        public static int Max = 50;
        public static int MaxRB = 500;
        public static int[,] dp=new int[MaxRB+1, MaxRB+1];

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\GracefulChainsawJunggers.txt");
#endif
            Solve();
            T = Convert.ToInt32(input.ReadLine());
            Nums = new int[T][];

            for (int i = 0; i < T; i++)
            {
                Nums[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                R = Nums[i][0];
                B = Nums[i][1];
                
                Output(i + 1, dp[R, B]);
            }

            Console.Read();
        }

        public static void Solve()
        {
            for (int i = 0; i <= Max; i++)
            {
                for (int j = 0; j <= Max; j++)
                {
                    if (i + j == 0) continue;

                    for (int r = MaxRB-i; r >= 0; r--)
                    {
                        for (int b = MaxRB-j; b >= 0; b--)
                        {
                            dp[r+i, b+j] = Math.Max(dp[r+i, b+j], dp[r, b] + 1);
                        }
                    }
                }
            }
        }

        public static void Output(int caseNum, int result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
