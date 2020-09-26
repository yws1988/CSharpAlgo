/*
 * https://www.geeksforgeeks.org/n-queen-problem-backtracking-3/ 
 * The N Queen is the problem of placing N chess queens on an N×N chessboard 
 * so that no two queens attack each other. 
 */

namespace CSharpAlgo.Excercise.Excercises.Backtracking
{
    public class NQueen
    {
        public static bool Start(int[,] g)
        {
            int n = g.GetLength(0);

            // if g[i,j]==1 put the queen position in this cell
            return FindPath(g, 0, n);
        }

        static bool FindPath(int[,] g, int column, int n)
        {
            if(column== n)
            {
                return true;
            }

            for (int i = 0; i < n; i++)
            {
                if(IsValid(g, i, column, n))
                {
                    g[i, column] = 1;
                    if(FindPath(g, column + 1, n))
                    {
                        return true;
                    }
                    g[i, column] = 0;
                }
            }

            return false;
        }

        static bool IsValid(int[,] g, int x, int y, int n)
        {
            for (int i = 0; i < y; i++)
            {
                if (g[x, i] == 1) return false;
            }

            for (int i = 1; i <= y; i++)
            {
                if (x-i>=0 && g[x-i, y-i] == 1) return false;

                if (x + i < n && g[x + i, y - i] == 1) return false;
            }

            return true;
        }
    }
}
