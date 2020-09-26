using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class PattensInString
    {
        static int n;
        static int len;
        static string str;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\PatternsInString.txt");
#endif
            n = int.Parse(input.ReadLine());

            for (int i = 0; i < n; i++)
            {
                len = int.Parse(input.ReadLine());
                str = input.ReadLine();
                Solve(str);
            }

            Console.Read();
        }

        public static void Solve(string str)
        {
            int a = 0, ab = 0, aba = 0, b = 0, ba = 0, bab = 0;

            for (int i = 0; i < len; i++)
            {
                var c = str[i];
                if (c == 'a')
                {
                    a++;
                    ba = Math.Max(ba, b) + 1;
                    aba = Math.Max(aba, ab) + 1;
                }
                else
                {
                    b++;
                    ab = Math.Max(ab, a) + 1;
                    bab = Math.Max(bab, ba)+ 1;
                }
            }

            Console.WriteLine(Math.Max(aba, bab));
        }
    }
}
