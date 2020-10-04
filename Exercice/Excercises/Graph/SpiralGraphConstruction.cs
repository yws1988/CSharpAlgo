namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;

    public class SpiralGraphConstruction
    {
        static int N;
        static char[,] chars;

        public static void Start(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            chars = new char[N, N];
            int cX = N / 2;
            int cY = N / 2;
            chars[cX, cY] = '#';
            int[,] ds = {{ 1,0 }, { 0, 1 }, { -1, 0 }, { 0, -1 }};
            int dir = 3;
            cX += ds[dir, 0];
            cY += ds[dir, 1];

            int len = 2;
            while (true)
            {
                if (cX < 0 || cX >= N || cY < 0 || cY >= N) break;
                dir++;
                if (dir >= 4) dir %= 4;
                for (int h = 1; h <= len; h++)
                {
                    chars[cX, cY] = '#';
                    cX += ds[dir, 0];
                    cY += ds[dir, 1];
                }
                len++;
            }

            for(int i = 0; i < N; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(chars[i, j] == default(char) ? "=" : "#");
                }
                Console.WriteLine();
            }
        }
    }
}
