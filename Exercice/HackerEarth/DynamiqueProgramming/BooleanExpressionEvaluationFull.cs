using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class BooleanExpressionEvaluationFull
    {
        public static bool[] e;
        static int n;
        public static char[] op;
        public static int q;
        static bool[,] dp;
        static bool[,] dpSuffix;
        static int[,,] res;
        const int Max = 1000000009;
#if true
        static System.IO.StreamReader input;
#endif

        public static void Start()
        {
#if true
            input = new System.IO.StreamReader(@"test\BooleanExpression.txt");
#endif
            var tmp = input.ReadLine().Split(new char[] {' '}, StringSplitOptions.RemoveEmptyEntries);
            e = tmp[0].Select(s => s=='1').ToArray();
            op = tmp[1].ToCharArray();

            Solve();

            Console.Read();
        }

        public static void Solve()
        {
            n = e.Length;
            dp = new bool[n, n];

            for (int i = 0; i < n; i++)
            {
                for (int j = 0; i+j < n; j++)
                {
                    if (j == 0)
                    {
                        dp[i, i] = e[i];
                    }
                    else
                    {
                        int tt = i + j;
                        dp[i, tt] = Cal(dp[i, tt - 1], e[tt], op[tt-1]);
                    }
                }
            }

            dpSuffix = new bool[2, n];
            for (int i = 1; i < n; i++)
            {
                dpSuffix[0, i] = false;
                dpSuffix[1, i] = true;
                for (int j = i; j < n; j++)
                {
                    dpSuffix[0, i] = Cal(dpSuffix[0, i], e[j], op[j-1]);
                    dpSuffix[1, i] = Cal(dpSuffix[1, i], e[j], op[j-1]);
                }
            }

            res = new int[n, n, 2];
            bool tmp = dp[0, n - 1];
            for (int i = 0; i < n; i++)
            {
                res[i, i, 0] = tmp ? 0 : 1;
                res[i, i, 1] = tmp ? 1 : 0;
            }

            for (int i = 0; i < n; i++)
            {
                for (int j = i + 1; j < n; j++)
                {
                    bool temp = Val(i, j);
                    res[i, j, 0] = (res[i, j - 1, 0] + res[i + 1, j, 0] + (temp ? 0 : 1))%Max;
                    res[i, j, 1] = (res[i, j - 1, 1] + res[i + 1, j, 1] + (temp ? 1 : 0))%Max;

                }
            }

            q = int.Parse(input.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var tt = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(res[int.Parse(tt[0])-1, int.Parse(tt[1])-1, tt[2]=="true" ? 1 : 0]);
            }
        }

        static bool Val(int i, int j)
        {
            if (i == 0)
            {
                return dp[i, j];
            }else if(j == n - 1)
            {
                return dpSuffix[dp[0, i - 1] ? 1 : 0, i];
            }
            else
            {
                bool temp= Cal(dp[0, i - 1], dp[i, j], op[i - 1]);
                return dpSuffix[temp ? 1 : 0, j + 1];
            }
        }

        static bool Cal(bool a, bool b, char c)
        {
            if (c == 'a')
            {
                return a & b;
            }else if (c == 'x')
            {
                return a ^ b;
            }
            else
            {
                return a | b;
            }
        }
    }
}
