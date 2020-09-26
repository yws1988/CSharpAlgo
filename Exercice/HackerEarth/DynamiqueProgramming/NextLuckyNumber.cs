using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class NextLuckyNumber
    {
        public static int t;
        public static string str;
        public static int[] ns;
        static int first;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\LuckyNumber.txt");
#endif
            t = int.Parse(input.ReadLine());

            for (int i = 0; i < t; i++)
            {
                str = input.ReadLine();

                Solve();
            }

            //Console.Read();
        }

        public static void Solve()
        {
            int len = str.Length;
            ns = str.Select(s => s - '0').ToArray();
            first = 0;

            int ti = 0;
            while (ti < len)
            {
                if (ns[ti] == 3 || ns[ti] == 5)
                {
                    ti++;
                }
                else
                {
                    break;
                }
            }

            if (ti == len)
            {
                AssignP(len - 1, 1);
            }
            else
            {
                Assign(ti);
            }

            var tstr = string.Join("", ns.Select(s => s.ToString()));
            if (first > 0)
            {
                Console.WriteLine(first + tstr);
            }
            else
            {
                Console.WriteLine(tstr);
            }
        }

        static void AssignP(int idx, int add)
        {
            if (idx < 0 && add == 1) first = 3;
            if (idx < 0) return;

            int nn = ns[idx];
            if (add == 1)
            {
                if (nn == 3)
                {
                    ns[idx] = 5;
                    AssignP(idx - 1, 0);
                }
                else
                {
                    ns[idx] = 3;
                    AssignP(idx - 1, 1);
                }
            }
        }

        static void Assign(int idx)
        {
            int nn = ns[idx];
            if (nn < 3)
            {
                ns[idx] = 3;
                AssignP(idx - 1, 0);
            }
            else if (nn > 3 && nn < 5)
            {
                ns[idx] = 5;
                AssignP(idx - 1, 0);
            }
            else
            {
                ns[idx] = 3;
                AssignP(idx - 1, 1);
            }

            for (int i = idx+1; i < ns.Length; i++)
            {
                ns[i] = 3;
            }
        }
    }
}
