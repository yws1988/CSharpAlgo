namespace Utils.Helper.Math
{
    using System.Text;

    public class MatrixHelper
    {
        public static string GetHashString(int[,] matrix)
        {
            int n = matrix.GetLength(0);

            var sb = new StringBuilder();
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    sb.Append(matrix[i, j].ToString());
                }
            }

            return sb.ToString();
        }

        public static int[,] GetMatrixFromString(string hashString, int n)
        {
            var matrix = new int[n, n];
            for (int i = 0; i < hashString.Length; i++)
            {
                matrix[i / n, i % n] = hashString[i];
            }

            return matrix;
        }
    }
}
