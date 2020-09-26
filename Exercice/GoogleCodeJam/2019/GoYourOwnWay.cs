using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class GoYourOwnWay
    {
        public static int T;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\test.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                int n = int.Parse(input.ReadLine());
                string str = input.ReadLine();

                Solve(i, n, str);
            }

            Console.Read();
        }

        public static void Solve(int t, int n, string str)
        {
            var arr = str.ToCharArray();
            int len = arr.Length;

            char[] ts = new char[len];
            char c = arr[0];
            char cr = arr[0] == 'S' ? 'E' : 'S';

            if (arr[len - 1] == c)
            {
                int tt= n * 2 - 3;
                int cc = 0;
                while (tt>1)
                {
                    if (arr[tt] == cr)
                    {
                        cc++;
                    }

                    if(arr[tt]==cr && arr[tt - 1] == cr)
                    {
                        break;
                    }

                    tt--;
                }

                for (int i = 0; i < n-1-cc; i++)
                {
                    ts[i] = cr;
                }

                for (int i = n - 1 - cc; i < n * 2 - 2 - cc; i++)
                {
                    ts[i] = c;
                }

                for (int i = n * 2 - 2 - cc; i < n * 2 - 2; i++)
                {
                    ts[i] = cr;
                }
            }
            else
            {
                for (int i = 0; i < n - 1; i++)
                {
                    ts[i] = cr;
                }

                for (int i = n - 1; i < n * 2 - 2; i++)
                {
                    ts[i] = c;
                }
            }

            Output(t+1, new string(ts));
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": " + result);

            Console.WriteLine();
        }
    }
}
