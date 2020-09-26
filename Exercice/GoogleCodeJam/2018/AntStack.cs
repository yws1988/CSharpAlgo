using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class AntStack
    {
        public static int T;
        public static int N;
        public static long[] Nums;
        public static long[,] Sums;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\AntStack.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                N = int.Parse(input.ReadLine());
                Nums = input.ReadLine().Split(' ').Select(Int64.Parse).ToArray();
                Output(i+1, Solve());
            }

            Console.Read();
        }

        public static int Solve()
        {
            int yM=GetMaxY();
            Sums = new long[N+1, yM+1];

            long min = Nums[0];
            for (int i = 1; i <= N; i++)
            {
                if (min > Nums[i-1])
                {
                    min = Nums[i-1];  
                }
                Sums[i, 1] = min;
            }

            for (int i = 2; i <= yM; i++)
            {
                Sums[1, i] = long.MaxValue;
            }

            for (int i = 2; i <= N; i++)
            {
                for (int j = 1; j <= yM; j++)
                {
                    if (Sums[i - 1, j - 1]<= Nums[i-1] * 6)
                    {
                        Sums[i, j] = Math.Min(Sums[i - 1, j], Sums[i - 1, j - 1] + Nums[i-1]);
                    }
                    else
                    {
                        Sums[i, j] = Sums[i - 1, j];
                    }
                }
            }

            int c= yM;
            while (c >= 0)
            {
                if(Sums[N, c] != long.MaxValue)
                {
                    break;
                }
                c--;
            }
            
            return c;
        }

        public static int GetMaxY()
        {
            int c = 1;
            long n = 1;
            long sum = 1;
            while(sum<=6*Math.Pow(10, 9))
            {
                if (sum > n * 6)
                {
                    long temp = sum / 6;
                    if (sum % 6 != 0)
                    {
                        temp++;
                    }
                    
                    n = temp;
                }

                sum += n;
                c++;
            }

            return c;
        }

        public static void Output(int caseNum, int result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
