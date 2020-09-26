using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class CostumeChange
    {
        public static int T;
        public static int N;
        public static int[][] Nums;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\CostumeChange.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                N = int.Parse(input.ReadLine());
                Nums = new int[N][];
                for (int j = 0; j < N; j++)
                {
                    Nums[j] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                }

                Output(i + 1, Solve());
            }

            Console.Read();
        }
        public static bool BMP(int[,] bmp, int u, int[] match, bool[] seen)
        {
            for (int i = 0; i < N; i++)
            {
                if(bmp[u, i] == 1 && !seen[i])
                {
                    seen[i] = true;
                    if (match[i] == -1 || BMP(bmp, match[i], match, seen))
                    {
                        match[i] = u;
                        return true;
                    }
                }
            }

            return false;
        }

        public static int GetMaximumBitPartite(int[,] bmp)
        {
            int counter = 0;
            int[] match = new int[N];
            for (int j = 0; j < N; j++)
            {
                match[j] = -1;
            }

            for (int i = 0; i < N; i++)
            {
                bool[] seen = new bool[N];
                if (BMP(bmp, i, match, seen))
                {
                    counter++;
                }
            }

            return counter;
        }

        public static int Solve()
        {
            int counter = 0; 
            int[][,] bmp = new int[2 * N + 1][,];
            for (int i = 0; i < 2 * N + 1; i++)
            {
                bmp[i] = new int[N, N];
            }

            for (int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    bmp[Nums[i][j]+N][i,j] = 1;
                }
            }

            for (int i = -N; i <= N; i++)
            {
                if (i == 0) continue;
                counter += GetMaximumBitPartite(bmp[i+N]);
            }
            

            return N * N - counter;
        }
           
            

        public static void Output(int caseNum, int result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
