namespace CSharpAlgo.Graph.Flow
{
    public class MaximumBiPartiteGraph
    {
        public static int[] GetMaximumBitPartiteMatching(int[,] bp)
        {
            int m = bp.GetLength(0);
            int n = bp.GetLength(1);

            int[] match = new int[n];
            for (int i = 0; i < n; i++)
            {
                match[i] = -1;
            }

            int result = 0;
            for (int i = 0; i < m; i++)
            {
                bool[] seen = new bool[n];
                if (BitPartiteMatching(bp, i, match, seen, n))
                {
                    result++;
                }

                if (result == n)
                {
                    break;
                }
            }

            return match;
        }

        static bool BitPartiteMatching(int[,] bp, int u, int[] match, bool[] seen, int n)
        {
            for (int v = 0; v < n; v++)
            {
                if (bp[u, v] == 1 && !seen[v])
                {
                    seen[v] = true;
                    if (match[v] == -1 || BitPartiteMatching(bp, match[v], match, seen, n))
                    {
                        match[v] = u;
                        return true;
                    }
                }
            }

            return false;
        }
    }
}
