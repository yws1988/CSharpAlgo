using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace HackerEarth.Graph.Base
{
    public class BuggyBot
    {
        public static int n, m, k;
        public static int[] ia, ib, ee, pos;
        public static List<int>[] g;
        public static HashSet<int> r = new HashSet<int>();

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\BuggyBot.txt");
#endif
            var nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
            n = nums[0]+1;
            m = nums[1];
            k = nums[2]+1;

            g = Enumerable.Range(0, n).Select(s=>new List<int>()).ToArray();

            for (int i = 0; i < m; i++)
            {
                var e = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                g[e[0]].Add(e[1]);
            }

            ia = new int[k];
            ib = new int[k];
            pos = new int[k];
            pos[0] = 1;
            for (int i = 1; i < k; i++)
            {
                if (ia[i] == pos[i - 1])
                {
                    pos[i] = ib[i];
                }
                else
                {
                    pos[i] = pos[i - 1];
                }
            }


        }
    }
}