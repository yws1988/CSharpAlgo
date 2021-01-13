/*
This challenge is based on the game of life, the principles of which you will find here:
https://en.wikipedia.org/wiki/Conway%27s_Game_of_Life

In this variant, at each step:
- when a cell has a living neighbor above and a living neighbor on the left: it becomes alive;
- when a cell has no living neighbor, neither above nor to the left: it dies;
- in the rest of the cases, it retains its state.

You must indicate the survival time of the population from an initial configuration. That is to say the number of steps after which there is no longer a living cell.

For convenience, the initial configuration will be described by a series of rectangles of living cells.

Input Data:

Line 1: an integer N between 1 and 1000 representing the number of rectangles.
Lines 2 to N + 1: four integers x1 y1 x2 y2 each between 1 and 1,000,000 and separated by spaces. 
All the points included in the rectangle bounded by x1, y1 (top-left corner) and x2, y2 (bottom-right corner) are living cells. 

There will be no more than 1,000,000 living cells to start with.

Exit
An integer representing the survival time of the population. If the population survives indefinitely, return -1.

Example

Give the followings 3 rectangles:

3
5 1 5 1
2 2 4 2
2 3 2 4

has a lifespan of 6.
*/

namespace CSharpAlgo.Excercise.Excercises.Graph
{
    using System;
    using System.Collections.Generic;
    using CSharpAlgo.Graph.Tree;

    public class GameOfLifeWithUnionFindMethod
    {
        public static int n;

        public static int GetGameLifeSpan(List<Rectangle> rectangles)
        {
            var sets = UnionFind.CreateSubsets(n);
            var minXY = new int[n];
            var maxX = new int[n];
            var maxY = new int[n];

            for (int i = 0; i < n; i++)
            {
                var rec = rectangles[i];
                minXY[i] = rec.x1 + rec.y1;
                maxX[i] = rec.x2;
                maxY[i] = rec.y2;

                for (int j = 0; j < i; j++)
                {
                    var recp = rectangles[j];

                    if (!(rec.x2 + 1 < recp.x1 || rec.y2 + 1 < recp.y1 || rec.x1 - 1 > recp.x2 || rec.y1 - 1 > recp.y2) &&
                        !(rec.x2 + 1 == recp.x1 && rec.y2 + 1 == recp.y1) &&
                        !(recp.x2 + 1 == rec.x1 && recp.y2 + 1 == rec.y1))
                    {
                        int ii = UnionFind.Find(sets, i);
                        int jj = UnionFind.Find(sets, j);
                        UnionFind.Union(sets, ii, jj);

                        int k = UnionFind.Find(sets, ii);

                        minXY[k] = Math.Min(Math.Min(minXY[k], minXY[ii]), minXY[jj]);
                        maxX[k] = Math.Max(Math.Max(maxX[k], maxX[ii]), maxX[jj]);
                        maxY[k] = Math.Max(Math.Max(maxY[k], maxY[ii]), maxY[jj]);
                    }
                }
            }

            int lifes = 0;

            for (int i = 0; i < n; i++)
            {
                int parent = UnionFind.Find(sets, i);

                lifes = Math.Max(lifes, maxX[parent] + maxY[parent] - minXY[parent] + 1);
            }

            return lifes;
        }

        public class Rectangle
        {
            public int x1 { get; set; }
            public int y1 { get; set; }
            public int x2 { get; set; }
            public int y2 { get; set; }

            public Rectangle(int x1, int y1, int x2, int y2)
            {
                this.x1 = x1;
                this.y1 = y1;
                this.x2 = x2;
                this.y2 = y2;
            }
        }
    }
}
