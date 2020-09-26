using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class GridCeption
    {
        public static int T;
        public static int[] Ns;
        public static int R;
        public static int C;
        public static int[][] Cs;
        public static int[,] ConnectedA;
        public static int Max;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\GridCeption.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());
            Ns = new int[T];

            for (int i = 0; i < T; i++)
            {
                Ns = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                R = Ns[0];
                C = Ns[1];
                Cs = new int[R][];
                for (int h = 0; h < R; h++)
                {
                    Cs[h] = input.ReadLine().ToCharArray().Select(c => c=='B'? 1:0).ToArray();
                }

                Solve();
                Output(i + 1, Max);
            }

            Console.Read();
        }

        public static void Solve()
        {
            ConnectedA = new int[R, C];
            Max = 0;

            List<int> patterns = new List<int>();

            int[] xMove = { -1, -1, 0, 0 };
            int[] yMove = { -1, 0, -1, 0 };

            for (int i = 0; i <R ; i++)
            {
                for (int j = 0; j <C; j++)
                {
                    int t = 0;

                    for (int m = 0; m < 4; m++)
                    {
                        t += (int)Math.Pow(2, m) * GetValue(i + xMove[m], j + yMove[m]);
                    }

                    patterns.Add(t);
                }
            }

           var ps = patterns.Distinct().ToList();

            foreach(int m in ps)
            {
                for (int i = 0; i <= R; i++)
                {
                    for (int j = 0; j <= C; j++)
                    {
                        for (int n = 0; n < 4; n++)
                        {
                            int color = (m >> n) & 1;
                            int r1 = (n == 0 || n == 1) ? 0 : i;
                            int r2 = (n == 0 || n == 1) ? i : R;
                            int c1 = (n == 0 || n == 2) ? 0 : j;
                            int c2 = (n == 0 || n == 2) ? j : C;
                            SetValue(r1, c1, r2, c2, color);
                        }

                        GetLargestConnectedComponent();
                    }
                }
            }
        }

        public static int GetValue(int x, int y)
        {
            if (x < 0) x += 1;

            if (y < 0) y += 1;

            if (x >= R) x--;

            if (y >= C) y--;

            return Cs[x][y];
        }

        public static void SetValue(int x0, int y0, int x1, int y1, int color)
        {
            for (int i = x0; i < x1; i++)
            {
                for (int j = y0; j < y1; j++)
                {
                    if (Cs[i][j] == color)
                    {
                        ConnectedA[i, j] = 1;
                    }
                    else
                    {
                        ConnectedA[i, j] = 0;
                    }
                }
            }
        }

        public static void GetLargestConnectedComponent()
        {
            bool[,] IsVisited = new bool[R, C];

            for (int i = 0; i < R; i++)
            {
                for (int j = 0; j < C; j++)
                {
                    if (!IsVisited[i, j])
                    {
                        int num = Search(i, j, IsVisited);
                        if (num > Max)
                        {
                            Max = num;
                        }
                    }
                }
            }
        }

        public static int Search(int i, int j, bool[,] isVisited)
        {
            if (i < 0 || i >= R || j < 0 || j >= C) return 0;

            if (!isVisited[i, j] && ConnectedA[i, j] == 1)
            {
                isVisited[i, j] = true;
                int[] xMove = { 1, -1, 0, 0 };
                int[] yMove = { 0, 0, 1, -1 };

                int c = 1;
                for (int u = 0; u < 4; u++)
                {
                    c += Search(i + xMove[u], j + yMove[u], isVisited);
                }
                return c;
            }

            return 0;
        }

        public static void Output(int caseNum, int result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
