/*
    Give a matrix NxN. Our goal is to cross over all the 1s in the matrix.
    Get the minimum number of path to reach (m, n) from (0, 0). 
    Each path can only raverse down, right and diagonally lower cells from a given cell, 
    for example, from a given cell (i, j), cells (i+1, j), (i, j+1) and (i+1, j+1) can be traversed.
    
    Example matrix:
    
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,
    0,0,1,0,0,1,0,0,0,1,

    Output 3 paths can transverse all the 1 points
*/

namespace CSharpAlgo.Graph.Flow
{
    using System.Collections.Generic;
    using System.Linq;

    public class MinimumPathsToTransverAllPointsInGrid
    {
        public static int GetMinimumNumberOfPaths(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            var list = new List<(int, int)>();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    if (matrix[i, j] == 1)
                    {
                        list.Add((i, j));
                    }
                }
            }

            int nn = list.Count;

            var matches = Enumerable.Range(0, nn).Select(s => new List<int>()).ToArray();

            for (int i = 0; i < nn; i++)
            {
                for (int j = 0; j < nn; j++)
                {
                    if (i != j && list[i].Item1 <= list[j].Item1 && list[i].Item2 <= list[j].Item2)
                    {
                        matches[i].Add(j);
                    }
                }
            }

            int maxMatching = MaximumBiPartiteGraph.GetMaximumBitPartiteMatching(matches);


            return nn - maxMatching;

        }
    }
}