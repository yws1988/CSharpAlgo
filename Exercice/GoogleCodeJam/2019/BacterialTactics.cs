using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class BacterialTactics
    {
        static int T;
        static int r;
        static int c;
        static char[][] cs;
        static int res;

        public static void Main()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                var nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                r = nums[0];
                c = nums[1];
                cs = new char[r][];
                for (int j = 0; j < r; j++)
                {
                    cs[j] = input.ReadLine().ToCharArray();
                }

                //Solve(i+1);
            }

            Console.Read();
        }

        //public static void Solve(int t)
        //{
        //    for (int i = 0; i < r; i++)
        //    {
        //        for (int j = 0; j < c; j++)
        //        {
        //            if (cs[i][j] != '#')
        //            {
        //                if(dfs(i, j, 1, 0) || dfs(i, j, 1, 1))
        //                {
        //                    Output(t, res.ToString());
        //                    return;
        //                }
        //            }
        //        }
        //    }

        //    Output(t, "0");
        //}

        //static bool isSafe()
        //{

        //}

        //static bool dfs(int x, int y, int level, int t)
        //{
        //    if (t == 0)
        //    {
        //        if(isSafe(y))
        //    }
        //    else
        //    {

        //    }
        //}

        public static void Output(int caseNum, string result)
        {
            Console.WriteLine("Case #" + caseNum + ": " + result);
        }
    }
}
