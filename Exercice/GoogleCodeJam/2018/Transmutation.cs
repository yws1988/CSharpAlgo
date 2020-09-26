using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class Transmutation
    {
        public static int T;
        public static int N;
        public static int[] R1;
        public static int[] R2;
        public static int[][] R;
        public static long[] G;
        public static long[] Reqs;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\Transmutation.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                N = int.Parse(input.ReadLine());
                R1 = new int[N];
                R2 = new int[N];
                R = new int[N][];

                for (int h = 0; h < N; h++)
                {
                    R[h] = new int[N];
                    int[] Rs = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    R1[h] = --Rs[0];
                    R2[h] = --Rs[1];
                }
                
                G = input.ReadLine().Split(' ').Select(Int64.Parse).ToArray();
                Reqs = new long[N];

                Output(i+1, Solve());
            }

            Console.Read();
        }

        public static long Solve()
        {
            long max = G.Skip(1).Sum()/2+G[0];
            long min = G[0];
            long val = (min + max) / 2;

            while (min <= max)
            {
                if (IsOk(val))
                {
                    min = val+1;
                }
                else
                {
                    max = val - 1;
                }
                val = (min + max) / 2;
            }

            return val;
        }

        public static bool IsOk(long val)
        {
            Reset();
            for (int h = 0; h < N; h++)
            {
                Reqs[h] -= G[h];

                R[h][R1[h]]++;
                R[h][R2[h]]++;
            }
            Reqs[0] += val;

            bool done = false;
            while (!done)
            {
                done = true;
                for (int i = 0; i < N; i++)
                {
                    if (Reqs[i] <= 0) continue;
                    done = false;
                    if (R[i][i] != 0) return false;
                    for (int j = 0; j < N; j++)
                    {
                        Reqs[j] += Reqs[i] * R[i][j];
                    }

                    Reqs[i] = 0;

                    for (int m = 0; m < N; m++)
                    {
                        if (R[m][i] == 0) continue;
                        for (int n = 0; n < N; n++)
                        {
                            R[m][n] += R[m][i] * R[i][n];
                        }
                        R[m][i] = 0;
                    }
                }

                if (Reqs.Sum() > 0) return false;
            }

            return true;
        }

        public static void Reset()
        {
            for (int i = 0; i < N; i++)
            {
                Reqs[i] = 0;
                for (int h = 0; h < N; h++)
                {
                    R[i][h] = 0;
                }
            }
        }

        public static void Output(int caseNum, long result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }
}
