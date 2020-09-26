using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class FieldTrip
    {
        public static int T;
        public static int N;
        public static int[][] Nums;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\FieldTrip.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                N = int.Parse(input.ReadLine());
                Nums = new int[N][];
                for (int j = 0; j < N; j++)
                {
                    Nums[j] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                }
                Console.WriteLine(-~13);
                Output(i+1, Solve());
            }

            Console.Read();
        }

        public static int Solve()
        {
            var Xs = Nums.Select(n => n[0]).OrderBy(n => n).ToArray();
            var Ys = Nums.Select(n => n[1]).OrderBy(n => n).ToArray();

            return (int)Math.Max(Math.Ceiling((Xs[N - 1] - Xs[0])/2.0), Math.Ceiling((Ys[N - 1] - Ys[0]) / 2.0));
        }

        public static void Output(int caseNum, int result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
