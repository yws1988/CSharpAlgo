namespace Utils.Helper
{
    public class ArrayHelper
    {
        public static T[,] Clone<T>(T[,] array)
        {
            int m = array.GetLength(0);
            int n = array.GetLength(1);

            var cArray = new T[m, n];
            for (int i = 0; i < m; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    cArray[i, j] = array[i, j];
                }
            }

            return cArray;
        }

        public static T[][] Clone<T>(T[][] array)
        {
            int m = array.GetLength(0);

            var cArray = new T[m][];
            for (int i = 0; i < m; i++)
            {
                cArray[i] = new T[array[i].Length];
                array[i].CopyTo(cArray[i], 0);
            }

            return cArray;
        }

        public static T[] CopyArray<T>(T[] array)
        {
            int len = array.Length;
            T[] copyArray = new T[len];
            array.CopyTo(copyArray, 0);

            return copyArray;
        }

        /// <summary>
        /// Inverse the position of the first k elements of the array
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="k"></param>
        /// <param name="array"></param>
        /// <returns></returns>
        public static T[] Inverse<T>(T[] array, int k)
        {
            var newArray = new T[array.Length];
            array.CopyTo(newArray, 0);
            for (int i = 0, j = k; i <= k / 2; i++, j--)
            {
                T temp = newArray[i];
                newArray[i] = newArray[j];
                newArray[j] = temp;
            }

            return newArray;
        }
    }
}
