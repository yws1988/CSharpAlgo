using System;
using System.Collections.Generic;
using System.Linq;

namespace GoogleCodeJam
{
    //mark
    public class Party
    {
        public char C { get; set; }
        public int Num { get; set; }
        public Party(char c, int num)
        {
            C = c;
            Num = num;
        }
    }

    class Cruis
    {
        static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[] Ns = new int[t];
            int[][] numss = new int[t][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = Convert.ToInt32(Console.ReadLine());
                numss[i] = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
            }

            for (int i = 0; i < t; i++)
            {
                int N = Ns[i];
                int[] nums = numss[i];
                List<Party> infos = new List<Party>();
                for (int j = 0; j < N; j++)
                {
                    infos.Add(new Party((char)(j + 65), nums[j]));
                }
                infos = infos.OrderByDescending(info => info.Num).ToList();
                List<Char> solution = new List<Char>();

                int maxN = infos[0].Num;
                for (int m = 0; m < maxN; m++)
                {
                    int cValue = infos[0].Num;
                    for (int h = 0; h < N; h++)
                    {
                        if (infos[h].Num != cValue)
                        {
                            break;
                        }
                        solution.Add(infos[h].C);
                        infos[h].Num--;
                    }
                }

                PrintResult(i, solution);
                Console.WriteLine();
            }

            Console.Read();
        }

        private static void PrintResult(int i, List<char> solution)
        {
            Console.Write("Case #" + (i + 1) + ": ");

            if (solution.Count % 2 == 0)
            {
                for (int m = 0; m < solution.Count; m++)
                {
                    Console.Write(solution[m]);
                    if (m % 2 == 1) Console.Write(' ');
                } 
            }
            else
            {
                for (int m = 0; m < solution.Count-3; m++)
                {
                    Console.Write(solution[m]);
                    if (m % 2 == 1) Console.Write(' ');
                }
                Console.Write(' ');
                Console.Write(solution[solution.Count - 3]);
                Console.Write(' ');
                Console.Write(solution[solution.Count - 2]);
                Console.Write(solution[solution.Count - 1]);
            }
        }

    }
}
