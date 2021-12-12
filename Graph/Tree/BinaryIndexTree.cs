namespace CSharpAlgo.Graph.Tree
{
    using System.Linq;

    public class BinaryIndexedTree
    {
        public int[] BITree;
        public int n;

        public BinaryIndexedTree(int sizeOfArray)
        {
            n = sizeOfArray;
            BITree = new int[n + 1];
        }

        public BinaryIndexedTree(int[] arr)
        {
            n = arr.Count();
            BITree = new int[n + 1];

            for (int i = 0; i < n; i++)
                update(i, arr[i]);
        }

        public int query(int index)
        {
            int sum = 0;
            index = index + 1;

            while (index > 0)
            {
                sum += BITree[index];

                index -= index & (-index);
            }
            return sum;
        }

        public void update(int index, int val)
        {
            index = index + 1;

            while (index <= n)
            {
                BITree[index] += val;

                index += index & (-index);
            }
        }
    }
}
