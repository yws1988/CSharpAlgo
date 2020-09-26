using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class LollipopShop
    {
        public static int T;
        public static int N;
        public static int[] Nums;
        public static int[] Likes;
        public static int[] Sold;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\LollipopShop.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                N = int.Parse(input.ReadLine());
                Likes = new int[N];
                Sold = new int[N];

                for (int h = 0; h < N; h++)
                {
                    Nums = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                    
                    Solve();
                }
            }

            Console.Read();
        }

        public static void Solve()
        {
            if (Nums[0] == 0)
            {
                Console.WriteLine("-1");
            }
            else
            {
                int sale = -1;
                int min = int.MaxValue;
                for (int m = 1; m < Nums.Length; m++)
                {
                    Likes[Nums[m]]++;
                }

                for (int m = 1; m < Nums.Length; m++)
                {
                    if(Sold[Nums[m]]==0 && min > Likes[Nums[m]])
                    {
                        sale = Nums[m];
                        min = Likes[Nums[m]];
                    }
                }

                if (sale != -1)
                {
                    Sold[sale] = 1;
                    Console.WriteLine(sale);
                }
                else
                {
                    Console.WriteLine("-1");
                }
            }
        }

        public static void Output(int caseNum, string result)
        {
            Console.Write("Case #" + caseNum + ": " + result);
            Console.WriteLine();
        }
    }
}
