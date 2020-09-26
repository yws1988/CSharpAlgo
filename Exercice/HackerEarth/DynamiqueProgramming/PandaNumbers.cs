using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class PandaNumbers
    {
        public static int n;
        public static int[] nums;
        const int MAX = 1000001;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\PandaNumbers.txt");
#endif
            n = int.Parse(input.ReadLine());
            nums = new int[n];
            for (int i = 0; i < n; i++)
            {
                nums[i] = int.Parse(input.ReadLine());
            }

            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            var yes = new bool[MAX];
            for (int i = 1; i < 8; i++)
            {
                int x = (int)Math.Pow(i, i);
                yes[x] = true;
            }

            for (int i = 1; i < MAX; i++)
            {
                if (yes[i])
                    continue;

                foreach (char ch in i.ToString())
                {
                    int x = i - (ch - '0') * (ch - '0');
                    yes[i] |= (x > 0 && yes[x]);
                }
            }

            for (int i = 0; i < n; i++)
            {
                Console.WriteLine(yes[nums[i]] ? "Yes" : "No");
            }
        }
    }
}
