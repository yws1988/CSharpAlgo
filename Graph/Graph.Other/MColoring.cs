namespace Graph.Other
{
    public class MColoring
    {
        public static bool AssignColors(int[,] g, int colorNum, int[] colors)
        {
            int n = g.GetLength(0);
            colors = new int[n];
            bool isPossible = true;

            for (int i = 0; i < n; i++)
            {
                for (int j = 1; j <= colorNum; j++)
                {
                    colors[i] = j;
                    if (IsSafe(g, n, i, colors))
                    {
                        break;
                    }

                    if (j == colorNum)
                    {
                        isPossible = false;
                        goto End;
                    }
                }
            }

            End:
            return isPossible;
        }

        public static bool IsSafe(int[,] g, int n, int v, int[] colors)
        {
            for (int i = 0; i < n; i++)
            {
                if (i == v) continue;
                if(g[v, i]==1 && colors[v] == colors[i])
                {
                    return false;
                }
            }

            return true;
        }
    }
}
