using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class FallingBalls
    {
        public static int T;
        public static int C;
        public static int[] Bs;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\FallingBalls.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                C = int.Parse(input.ReadLine());
                Bs = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Solve(i+1);
            }

            Console.Read();
        }

        public static void Solve(int i)
        {
            char[,] g= new char[C, C];
            if (Bs[0] == 0 || Bs[C - 1] == 0)
            {
                Output(i, "IMPOSSIBLE");
                return;
            }

            int idx = 0;
            int[] maps = new int[C];

            for (int h = 0; h < C; h++)
            {
                int temp = Bs[h];
                if (temp > 0)
                {
                    while (temp > 0)
                    {
                        if (idx >= C)
                        {
                            Output(i, "IMPOSSIBLE");
                            return;
                        }
                        maps[idx] = h;
                        idx++;
                        temp--;
                    }
                }
            }

            if (idx != C)
            {
                Output(i, "IMPOSSIBLE");
                return;
            }

            int D = 1;
            for (int c = 0; c < C; c++)
            {
                int dis = Math.Abs(maps[c] - c);
                D = Math.Max(dis+1, D);
                if (maps[c] > c)
                {
                    for (int t = 0; t < dis; t++)
                    {
                        g[t, c+t]='\\';
                    }
                }else if(maps[c] < c)
                {
                    for (int t = 0; t < dis; t++)
                    {
                        g[t, c - t] = '/';
                    }
                }
            }

            Output(i, D.ToString());
            for (int m = 0; m < D; m++)
            {
                for (int h = 0; h < C; h++)
                {
                    Console.Write(g[m, h]==default(char) ? '.': g[m, h]);
                }
                Console.WriteLine();
            }
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
