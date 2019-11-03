namespace Algorithmne
{
    using System;
    using System.Linq;

    public class AdjacencyMatrix
    {
        public static int[,] AdacencyMatrix;

        public static void Generate()
        {
            int N = int.Parse(Console.ReadLine());
            AdacencyMatrix = new int[N, N];
            int E = int.Parse(Console.ReadLine());
            int i = 0;
            while (i < E)
            {
                int[] indexes = Console.ReadLine().Split(' ').ToArray().Select(s => int.Parse(s)).ToArray();
                AdacencyMatrix[indexes[0], indexes[1]] = 1;
                AdacencyMatrix[indexes[1], indexes[0]] = 1;
                i++;
            }
        }

        public static void Print()
        {
            for (int i = 0; i < AdacencyMatrix.GetLength(0); i++)
            {
                for (int j = 0; j < AdacencyMatrix.GetLength(1); j++)
                {
                    Console.Write(AdacencyMatrix[i,j] + " ");
                }
                Console.WriteLine();
            }
        }
    }
}
