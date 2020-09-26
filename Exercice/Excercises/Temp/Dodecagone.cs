using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
 * Read input from Console
 * Use Console.WriteLine to output your result.
 * Use:
 *       Utils.LocalPrint( variable); 
 * to display simple variables in a dedicated area.
 * 
 * Use:
 *      
		Utils.LocalPrintArray( collection)
 * to display collections in a dedicated area.
 * ***/

namespace CSharpContestProject
{
    class Decode
    {
        public static int N;
        public static string[,] chars;
        static void Start(string[] args)
        {
            N = Convert.ToInt32(Console.ReadLine());

            chars = new string[N, N];

            Fill(N, "#");
            chars[0,0] = ".";
            chars[0,N-1] = ".";
            chars[N-1,0] = ".";
            chars[N-1,N-1] = ".";

            for (int m = 0; m < N; m++)
            {
                for (int h = 0; h < N; h++)
                {
                    Console.Write(chars[m,h]);
                }
                Console.Write(" ");
            }

            Console.Read();
        }

        public static void Fill(int n, string s)
        {
            string nS = (s=="*" ? "#":"*");
            int start = (N - n) / 2;
            int end = start + n - 1;

            if (n == 1)
            {
                chars[start,start] = s;
                return;
            }

            for (int j = start; j<=end; j++)
            {
                if (j == start || j == end)
                {
                    chars[start,j] = s;
                    chars[end,j] = s;
                }
                else
                {
                    chars[start,j] = nS;
                    chars[end,j] = nS;

                    chars[j,start] = nS;
                    chars[j,end] = nS;
                }
            }

            Fill(n - 2, nS);
        }
    }
}