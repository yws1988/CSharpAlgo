using System;
using System.Linq;

namespace GoogleCodeJam
{
    public class GoGopher
    {
        public static int[,] grid = new int[4, 68];

        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            for (int i = 0; i < t; i++)
            {
                for (int m = 0; m < 4; m++)
                {
                    for (int c = 0; c < 68; c++)
                    {
                        grid[m, c] = 0;
                    }
                }
                int A = Convert.ToInt32(Console.ReadLine());
                int end = A / 3 + 1;
                int[] cell=new int[2];
                for (int j = 2; j < end; j += 3)
                {
                    int time = 1;
                    while (true)
                    {
                        Output(2, j);
                        cell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                        grid[cell[0], cell[1]] = 1;
                        if (time % 9 == 0 && isFull(2, j))
                        {
                            break;
                        }
                        time++;
                    }
                }

                do
                {
                    Output(2, end-1);
                    cell = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                } while (cell[0] != 0 && cell[1] != 0);
            }
        }

        public static bool isFull(int x, int y)
        {
            for (int i = x-1; i <= x+1; i++)
            {
                for (int h = y-1; h < y+1; h++)
                {
                    if (grid[i, h] != 1) return false;
                }
            }
            return true;
        }

        public static void Output(int x, int y)
        {
            Console.WriteLine(x + " " + y);
        }
    }
}
