using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class NumberOfRs
    {
        static int t;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\NumberOfRs.txt");
#endif

            t = int.Parse(input.ReadLine());
            for (int j = 0; j < t; j++)
            {
                Solve(input.ReadLine());
            }

            Console.Read();
        }

        public static void Solve(string str)
        {
            int rn=0, kn=0, grn=0;
            int max = 0;

            int len = str.Length;
            for (int i = 0; i < len; i++)
            {
                if (str[i] == 'R')
                {
                    rn++;
                    grn++;

                    if (rn >= kn)
                    {
                        rn = 0;
                        kn = 0;
                    }
                }
                else
                {
                    kn++;

                    if (kn > rn)
                    {
                        max = Math.Max(max, kn-rn);
                    }
                }
            }

            if(grn == len)
            {
                Console.WriteLine(len-1);
            }
            else
            {
                Console.WriteLine(grn+max);
            }
        }
    }
}
