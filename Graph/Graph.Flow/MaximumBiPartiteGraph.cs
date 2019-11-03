namespace Graph.Flow
{
    using System;

    public class MaximumBiPartiteGraph
    {
        public static int M;
        public static int N;

        public static bool BitPartiteMatching(int[,] bp, int u, int[] match, bool[] seen)
        {
            for (int v = 0; v < N; v++)
            {
                if (bp[u, v] == 1 && !seen[v])
                {
                    seen[v] = true;
                    if (match[v] == -1 || BitPartiteMatching(bp, match[v], match, seen))
                    {
                        match[v] = u;
                        return true;
                    }
                }
            }

            return false;
        }

        public static int GetMaximumBitPartiteMatching(int[,] bp)
        {
            M = bp.GetLength(0);
            N = bp.GetLength(1);
            
            int[] match = new int[N];
            for (int i = 0; i < N; i++)
            {
                match[i] = -1;
            }
            
            int result = 0;
            for (int i = 0; i < M; i++)
            {
                bool[] seen = new bool[N];
                if (BitPartiteMatching(bp, i, match, seen))
                {
                    result++;
                }
                if (result == N)
                {
                    break;
                }
            }

            for (int i = 0; i < N; i++)
            {
                Console.WriteLine($"{i} : {match[i]}");
            }

            return result;

        }
    }
}
