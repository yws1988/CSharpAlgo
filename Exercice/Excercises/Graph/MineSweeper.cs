namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class MineSweeper
    {
        static string[][] strs;
        static int H, L;
        static int startX, startY;

        public static void Start(string[] args)
        {
            var input = new List<string>();
            string line;
            while ((line = Console.ReadLine()) != null)
            {
                input.Add(line);
            }

            H = int.Parse(input[0]);
            L = int.Parse(input[1]);
            strs = new string[H][];
            for (int i = 0; i < H; i++)
            {
                strs[i] = new string[L];
            }

            for (int i = 0; i < H; i++)
            {
                strs[i] = input[i + 2].ToCharArray().Select(s => s.ToString()).ToArray();
            }
            int result = 0;
            for (int i = 0; i < H; i++)
            {
                for (int j = 0; j < L; j++)
                {
                    if (strs[i][j] == "x")
                    {
                        startX = i;
                        startY = j;
                    }

                    ConvertArray(i, j);
                }
            }

            int total = GetNum(startX, startY);
            Console.WriteLine(result);
        }

        static void ConvertArray(int x, int y)
        {
            if (strs[x][y] != "*")
            {
                return;
            }

            for (int i = x-1; i <= x + 1; i++)
            {
                for (int j = y-1; j <= y + 1; j++)
                {
                    if (x < 0 || y < 0 || x >= H || y >= L) continue;
                    if (strs[i][j] != "*" && strs[i][j]!="x")
                    {
                        strs[i][j] = "d";
                    }
                }
            }
        }

        static int GetNum(int x, int y)
        {
            if (strs[x][y] == "v") return 0;
            if (strs[x][y] == "*" || strs[x][y] == "d")
            {
                strs[x][y] = "v";
                return 1;
            }
            int total = 1;
            strs[x][y] = "v";

            for (int i = x - 1; i <= x + 1; i++)
            {
                for (int j = y - 1; j <= y + 1; j++)
                {
                    if (x < 0 || y < 0 || x >= H || y >= L) continue;
                    if (strs[i][j] != "v")
                    {
                        total += GetNum(i, j);
                    }
                }
            }
            return total;
        }
    }
}

