using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

public class TravelDiaries
{
    public static int n, m;
    public static int[] ns;
    public static int[][] g;

    public void Solve()
    {
        bool[,] vs = new bool[n, m];
        Queue<Node> queue = new Queue<Node>();
        int n1 = 0;
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < m; j++)
            {
                if (g[i][j] == 2)
                {
                    queue.Enqueue(new Node(i, j, 0));
                    vs[i, j] = true;
                }else if (g[i][j] == 1)
                {
                    n1++;
                }
            }
        }

        int[] dx = {1, 0, -1, 0 };
        int[] dy = {0, 1, 0, -1 };

        int max = 0;
        while (queue.Count > 0)
        {
            var node = queue.Dequeue();
            int i = node.x;
            int j = node.y;
            int d = node.d;
            for (int m = 0; m < 4; m++)
            {
                int tx = i + dx[m];
                int ty = j + dy[m];
                if(IsSafe(tx, ty) && !vs[tx, ty] && g[tx][ty]==1)
                {
                    queue.Enqueue(new Node(tx, ty, d + 1));
                    n1--;
                    if (d >= max)
                    {
                        max = d + 1;
                    }
                    vs[tx, ty] = true;
                }
            }
        }

        if (n1 == 0)
        {
            Console.WriteLine(max);
        }
        else
        {
            Console.WriteLine(-1);
        }
        
    }

    static bool IsSafe(int x, int y)
    {
        return x >= 0 && x < n && y >= 0 && y < m;
    }

    public struct Node
    {
        public int x { get; set; }
        public int y { get; set; }
        public int d { get; set; }

        public Node(int tx, int ty, int td)
        {
            x = tx;
            y = ty;
            d = td;
        }
    }

    #region Main

    protected static TextReader reader;
    static void MainF()
    {
#if true
        reader = new StreamReader(@"test\TravelDiaries.txt");
#else
        reader = new StreamReader(Console.OpenStandardInput());
#endif
        ns = ReadIntArray();
        n = ns[0];
        m = ns[1];
        g = ReadIntMatrix(n);
 
        new TravelDiaries().Solve();
        reader.Close();
    }

    #endregion

    #region Read / Write
    private static Queue<string> currentLineTokens = new Queue<string>();
    private static string[] ReadAndSplitLine() { return reader.ReadLine().Split(new[] { ' ', '\t' }, StringSplitOptions.RemoveEmptyEntries); }
    public static string ReadToken() { while (currentLineTokens.Count == 0) currentLineTokens = new Queue<string>(ReadAndSplitLine()); return currentLineTokens.Dequeue(); }
    public static int ReadInt() { return int.Parse(ReadToken()); }
    public static int[] ReadIntArray() { return ReadAndSplitLine().Select(int.Parse).ToArray(); }
    public static int[][] ReadIntMatrix(int numberOfRows) { int[][] matrix = new int[numberOfRows][]; for (int i = 0; i < numberOfRows; i++) matrix[i] = ReadIntArray(); return matrix; }
    #endregion
}