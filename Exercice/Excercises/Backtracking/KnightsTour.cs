/*
 * https://www.geeksforgeeks.org/the-knights-tour-problem-backtracking-1/
 * In the 8 x 8 cells chessbord, The knight is placed on the first block of 
 * an empty board and, moving according to the rules of chess, 
 * must visit each square exactly once. Check if the there is the solution. 
 */
namespace CSharpAlgo.Excercise.Excercises.Backtracking
{
    public class KnightsTour
    {
        // Warnsdorff’s algorithm

        public static int[] Xs = {1, 1, 2, 2,-1, -1, -2, -2};
        public static int[] Ys = { 2, -2, 1, -1, 2, -2, 1, -1 };
        public const int N = 8;
        public static int[,] G=new int[N, N];

        public static bool DoesTourPathExist(int x, int y)
        {
            G[x, y] = 1;
            int c = 1;
            while (NextMove(ref x, ref y))
            {
                G[x, y] = ++c;
            }

            // G[x, y] contains all the steps for the tour

            return c == N * N ? true : false;
        }

        static bool NextMove(ref int x, ref int y)
        {
            int min = N+1;
            int f=-1;
            int nX=0, nY=0;
            for (int i = 0; i < N; i++)
            {
                nX = x + Xs[i]; nY = y + Ys[i];
                if (IsValid(nX, nY))
                {
                    int d = GetDegree(nX, nY);
                    if (d < min)
                    {
                        min = d;
                        f = i;
                    }
                }
            }

            if (f != -1)
            {
                x = x + Xs[f]; y = y + Ys[f];
            }

            return f!=-1;
        }

        static bool IsValid(int x, int y)
        {
            return x >= 0 && x < N && y >= 0 && y < N && G[x, y] == 0;
        }

        // Get the minimum degree for the next move, greedy method
        static int GetDegree(int x, int y)
        {
            int c = 0;
            for (int i = 0; i < N; i++)
            {
                if (IsValid(x+Xs[i], y+Ys[i]))
                {
                    c++;
                }
            }

            return c;
        }
    }
}
