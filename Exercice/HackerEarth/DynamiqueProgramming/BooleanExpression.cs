using System;
using System.Linq;
using input = System.Console;

namespace CSharpAlgo.Excercise.HackerEarth.DynamiqueProgramming
{
    public class BooleanExpression
    {
        public static bool[] e;
        static int n;
        public static char[] op;
        public static int q;
        static long[,] ts;
        static long[,] fs;
        static long[,] all;
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
            ts = new long[n, n];
            fs = new long[n, n];
            all = new long[n, n];

            for (int i = 0; i < n; i++)
            {
                if (e[i])
                {
                    ts[i, i] = 1;
                }
                else
                {
                    fs[i, i] = 1;
                }

                all[i, i] = 1;
            }

            for (int interval = 1; interval < n; interval++)
            {
                for (int i = 0; i < n; i++)
                {
                    int j = i + interval;
                    if (j >= n)
                    {
                        break;
                    }

                    for (int k = i; k < j; k++)
                    {
                        if (op[k] == 'a')
                        {
                            ts[i, j] += (ts[i, k] * ts[k+1, j]);
                            fs[i, j] += ((all[i, k]* all[k + 1, j]) -(ts[i, k] * ts[k + 1, j]));
                        }
                        else if (op[k] == 'o')
                        {
                            fs[i, j] += (fs[i, k] * fs[k + 1, j]);
                            ts[i, j] += ((all[i, k] * all[k + 1, j]) - (fs[i, k] * fs[k + 1, j]));
                        }
                        else
                        {
                            ts[i, j] += (ts[i, k] * fs[k + 1, j]) + (fs[i, k] * ts[k + 1, j]);
                            fs[i, j] += (ts[i, k] * ts[k + 1, j]) + (fs[i, k] * fs[k + 1, j]);
                        }

                        ts[i, j] %= Max;
                        fs[i, j] %= Max;
                    }

                    all[i, j] = ts[i, j] + fs[i, j];
                }
            }

            q = int.Parse(input.ReadLine());
            for (int i = 0; i < q; i++)
            {
                var tt = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                Console.WriteLine(tt[2] == "true" ? ts[int.Parse(tt[0]) - 1, int.Parse(tt[1]) - 1] : fs[int.Parse(tt[0]) - 1, int.Parse(tt[1]) - 1]);
            }
        }
    }
}
