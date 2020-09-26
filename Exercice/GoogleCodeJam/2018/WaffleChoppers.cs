using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class WaffleChoppers
    {
        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\test.txt");
#endif

            int t = Convert.ToInt32(input.ReadLine());
            int[][] Ns = new int[t][];
            char[][][] strs = new char[t][][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = input.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
                int R = Ns[i][0];
                strs[i] = new char[R][];
                for (int h = 0; h < R; h++)
                {
                    strs[i][h] = input.ReadLine().ToCharArray();
                }
            }

            for (int i = 0; i < t; i++)
            {
                if (Solve(Ns[i], strs[i]))
                {
                    Output(i + 1, "POSSIBLE");
                }
                else
                {
                    Output(i + 1, "IMPOSSIBLE");
                }
            }

            //Console.Read();
        }

        public static bool Solve(int[] Ns, char[][] strs)
        {
            int R = Ns[0];
            int C = Ns[1];
            int H = Ns[2];
            int V = Ns[3];

            long[] cA = new long[C];
            int counter = 0;
            for (int c = 0; c < C; c++)
            {
                for (int r = 0; r < R; r++)
                {
                    if (strs[r][c] == '@') counter++;
                }

                cA[c] = counter;
            }

            if (cA[C - 1] == 0)
            {
                return true;
            }

            if (cA[C - 1] % (V + 1) != 0)
            {
                return false;
            }

            long aV = cA[C - 1] / (V + 1);
            List<int> cBorderA = new List<int>();
            cBorderA.Add(0);

            int d=1;
            long val = d * aV;
            for (int i = 0; i < C; i++)
            {
                if (cA[i] == val)
                {
                    cBorderA.Add(i+1);
                    d++;
                    val = d * aV;
                }
            }

            if (cBorderA.Count() != V+2) return false;

            long[] rA = new long[R];
            counter = 0;
            for (int r = 0; r < R; r++)
            {
                for (int c = 0; c < C; c++)
                {
                    if (strs[r][c] == '@') counter++;
                }

                rA[r] = counter;
            }

            if (rA[R - 1] % (H + 1) != 0) return false;
            aV = rA[R - 1] / (H + 1);

            List<int> rBorderA = new List<int>();
            rBorderA.Add(0);

            d = 1;
            val = d * aV;
            for (int i = 0; i < R; i++)
            {
                if (rA[i] == val)
                {
                    rBorderA.Add(i+1);
                    d++;
                    val = d * aV;
                }
            }
            if (rBorderA.Count() != H + 2) return false;

            if (cA[C - 1] % ((H + 1) * (V + 1))!=0) return false;

            long aTn = cA[C - 1] / ((H + 1) * (V + 1));

            for (int i = 1; i < rBorderA.Count; i++)
            {
                for (int j = 1; j < cBorderA.Count; j++)
                {
                    if (Verify(rBorderA[i-1], rBorderA[i], cBorderA[j-1], cBorderA[j], strs, aTn)) continue;
                    else return false;
                }
            }

            return true;

        }

        public static bool Verify(int minH, int maxH, int minV, int maxV, char[][] strs, long aTn)
        {
            int counter = 0;
            for (int i = minH; i < maxH; i++)
            {
                for (int h = minV; h < maxV; h++)
                {
                    if (strs[i][h] == '@') counter++;
                }
            }
            if (counter != aTn) return false;
            return true;
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": "+result);
 
            Console.WriteLine();
        }
    }
}
