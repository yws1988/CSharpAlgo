using System;

namespace Graph.Other
{
    public class LargestConnectedComponent
    {
        public static bool[,] IsVisited;
        public static int[,] Graph;
        public static int[,] Final;
        public static int Max = 0;
        public static int M;
        public static int N;


        public static void GetLargestConnectedComponent(int[,] graph)
        {
            Graph = graph;
            M = Graph.GetLength(0);
            N = Graph.GetLength(1);
            Final = new int[M, N];

            IsVisited = new bool[M, N];

            int counter = 1;
            int maxCounter = 1;
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    if (!IsVisited[i,j])
                    {
                        int val = Graph[i, j];
                        int num = Search(i, j, val, counter);
                        if (num > Max)
                        {
                            maxCounter = counter;
                            Max = num;
                        }
                        counter++;
                    }
                }
            }

            Console.WriteLine($"The largest value is : {Max}");
            for (int i = 0; i < M; i++)
            {
                for (int j = 0; j < N; j++)
                {
                    Console.Write(Final[i, j] == maxCounter ? Graph[i, j].ToString() : "*");
                    Console.Write(' ');
                }
                Console.WriteLine();
            }
        }

        public static int Search(int i, int j, int val, int counter)
        {
            if (i < 0 || i >= M || j < 0 || j >= N) return 0;

            if (!IsVisited[i, j] && Graph[i, j]==val)
            {
                IsVisited[i, j] = true;
                Final[i, j] = counter;
                int[] xMove = {1, -1, 0, 0};
                int[] yMove = { 0, 0, 1, -1};

                int c = 1;
                for (int u = 0; u < 4; u++)
                {
                    c+=Search(i+xMove[u], j+yMove[u], val, counter);
                }
                return c;
            }

            return 0;
        }
    }
}
