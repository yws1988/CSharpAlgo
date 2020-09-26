using System;
using System.Linq;
using input = System.Console;

namespace CodeJam
{
    public class Foregone
    {
        public static int t;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif

            t = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < t; i++)
            {
                Solve(input.ReadLine(), i);
            }

            Console.Read();
        }

        public static void Solve(string str, int c)
        {
            int n = str.Length;
            int[] m = str.ToCharArray().Select(s=>s-'0').ToArray();
            int[] mp = new int[n];
            int temp = -1;
            
            for (int i = 0; i < n; i++)
            {
                if (m[i] == 4)
                {
                    m[i] = 1;
                    mp[i] = 3;
                    if (temp == -1)
                    {
                        temp = i;
                    }
                }
            }

            string str1 = string.Join("", m.Select(s => s.ToString()).ToArray());

            string str2 = "";
            for (int i = temp; i < n; i++)
            {
                str2 += mp[i].ToString();
            }
            Output(c, str1 + " " + str2);
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }
}
