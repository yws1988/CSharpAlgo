using System;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class BitParty
    {
        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\BitParty.txt");
#endif

            int t = Convert.ToInt32(input.ReadLine());
            int[][] Ns = new int[t][];
            int[][][] Cs = new int[t][][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int C = Ns[i][2];

                Cs[i] = new int[C][];
                for (int h = 0; h < C; h++)
                {
                    Cs[i][h] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                }
            }

            for (int i = 0; i < t; i++)
            {
                Output(i + 1, Solve(Ns[i], Cs[i]));
            }

            Console.Read();
        }

        public static long Solve(int[] Ns, int[][] Cs)
        {
            int R = Ns[0];
            int B = Ns[1];
            int C = Ns[2];
            long min=0, max=long.MaxValue;
            long val = (min + max) / 2;
            while(true)
            {
                if(!IsEnough(val - 1, R, B, Cs) && IsEnough(val, R, B, Cs))
                {
                    break;
                }

                if(IsEnough(val, R, B, Cs))
                {
                    max = val - 1;
                    val = (min + max) / 2;
                }
                else
                {
                    min = val + 1;
                    val = (min + max) / 2;
                }
            }

            return val;
        }

        public static bool IsEnough(long T, int R, int B, int[][] Cs)
        {
            long[] caps = new long[Cs.Count()];
            for (int i = 0; i < Cs.Count(); i++)
            {
                int M = Cs[i][0];
                int S = Cs[i][1];
                int P = Cs[i][2];
                caps[i] = Math.Max(0, Math.Min(M, (T-P)/S));
            }
            long sum = caps.OrderByDescending(s=>s).Take(R).Sum();
            return sum >= B;
        }

        public static void Output(int caseNum, long result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }
}
