namespace CSharpAlgo.Maths
{
    using System;
    using System.Linq;

    public sealed class CustomHungarianMatching
    {
        public static int[] GetAssignmentsWithMinimunCost(int[,] costMatrix)
        {
            int rows = costMatrix.GetLength(0);
            int cols =costMatrix.GetLength(1);
            rows = cols = Math.Max(rows, cols);
            var u = new int[rows];
            var v = new int[cols];
            var ind = Enumerable.Repeat(-1, cols).ToArray();

            for (int i = 0; i < rows; i++)
            {
                var links = Enumerable.Repeat(-1, cols).ToArray();
                var mins = Enumerable.Repeat(int.MaxValue, cols).ToArray();
                var visited = new bool[cols];

                int markedI = i;
                int markedJ = -1;
                int j = 0;

                while (true)
                {
                    j = -1;
                    for (int j1 = 0; j1 < rows; j1++)
                    {
                        if (!visited[j1])
                        {
                            int cur = costMatrix[markedI, j1] - u[markedI] - v[j1];
                            if (cur < mins[j1])
                            {
                                mins[j1] = cur;
                                links[j1] = markedJ;
                            }

                            if (j == -1 || mins[j1] < mins[j])
                            {
                                j = j1;
                            }
                        }
                    }

                    int delta = mins[j];

                    for(int j1=0; j1<cols; j1++) {
                        if (visited[j1]) {
                            u[ind[j1]] += delta;
                            v[j1] -= delta;
                        } else
                        {
                            mins[j1] -= delta;
                        }
                    }

                    u[i] += delta;
                    visited[j] = true;
                    markedJ = j;
                    markedI = ind[j];
                    if (markedI == -1) {
                        break;
                    }
                }

                while (true)
                {
                    if (links[j] != -1) {
                        ind[j] = ind[links[j]];
                        j = links[j];
                    } else
                    {
                        break;
                    }
                }

                ind[j] = i;
            }

            var result = new int[cols];

            for (int j = 0; j < cols; j++)
            {
                result[j] = ind[j];
            }

            return result;
        }

    }
}
