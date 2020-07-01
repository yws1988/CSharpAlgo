/*
 * Given two dimension matrix [n, n], Iteration all the elements, the direction of
 * the iteration can just go up, right, bottom, left of the adjencent elements, output
 * the iteration path. 
 * Go Up(output ^)
 * Go Bottom(output v) 
 * Go Right(output >)
 * Go Left(output <)
 */
namespace CSharpAlgo.Graph.Traversal
{
    using System.Text;

    public class IterationInMatrix
    {
        public static (string, int) FromTopToBottom(int[,] matrix)
        {
            StringBuilder sb = new StringBuilder();

            int n = matrix.GetLength(0);
            int startRow = 0, col = 0, direction = 1;

            while (startRow < n)
            {
                if (col + direction >= 0 && col + direction < n)
                {
                    sb.Append(direction == 1 ? ">" : "<");
                    col += direction;
                }
                else
                {
                    if (startRow < n - 1)
                    {
                        sb.Append("v");
                    }

                    direction = -direction;
                    startRow++;
                }
            }

            return (sb.ToString(), direction);
        }
        
        public static (string, int) FromBottomToTop(int[,] matrix, int direction)
        {
            StringBuilder sb = new StringBuilder();

            int n = matrix.GetLength(0);
            int startRow = n - 1;
            int col = direction == 1 ? 0 : n-1;
            while (startRow >= 0)
            {
                if (col + direction >= 0 && col + direction < n)
                {
                    sb.Append(direction == 1 ? ">" : "<");
                    col += direction;
                }
                else
                {
                    if (startRow > 0)
                    {
                        sb.Append("^");
                    }

                    direction = -direction;
                    startRow--;
                }
            }

            return (sb.ToString(), direction);
        }
    }
}
