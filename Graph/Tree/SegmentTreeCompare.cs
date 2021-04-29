namespace CSharpAlgo.Graph.Tree
{
    using System;

    public class SegmentTreeCompare
    {
        int[] _array;
        int n;
        public Node[] Tree;
        public int N;
        Func<Node, Node, Node> _func;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="array">arr to pass</param>
        /// <param name="condition">0 min query, 1 max query</param>
        public SegmentTreeCompare(int[] array, Func<Node, Node, Node> func)
        {
            _array = array;
            n = array.Length;
            _func = func;
            this.Build();
        }

        void Build()
        {
            N = (int)Math.Pow(2, ((int)Math.Ceiling(Math.Log(_array.Length, 2)))) * 2 - 1;
            Tree = new Node[N];

            BuildUntil(0, 0, n - 1);
        }

        Node BuildUntil(int index, int s, int e)
        {
            if (s == e) return Tree[index] = new Node(s, _array[s]);

            int mid = Mid(s, e);
            return Tree[index] = this._func(BuildUntil(index * 2 + 1, s, mid), BuildUntil(index * 2 + 2, mid + 1, e));
        }

        int Mid(int s, int e)
        {
            return (s + e) / 2;
        }

        // qt:query start. qe:query end
        public Node Value(int qs, int qe)
        {
            return GetValueUtil(qs, qe, 0, n - 1, 0);
        }

        Node GetValueUtil(int qs, int qe, int s, int e, int idx)
        {
            if (qs <= s && qe >= e)
            {
                return Tree[idx];
            }

            if (qe < s || qs > e)
            {
                return null;
            }

            int mid = Mid(s, e);

            return this._func(GetValueUtil(qs, qe, s, mid, idx * 2 + 1), GetValueUtil(qs, qe, mid + 1, e, idx * 2 + 2));
        }

        public void Update(int key, int value)
        {
            if (value != _array[key])
            {
                _array[key] = value;

                UpdateUtil(key, value, 0, n - 1, 0);
            }

        }

        Node UpdateUtil(int key, int value, int s, int e, int idx)
        {
            if (key < s || key > e)
            {
                return Tree[idx];
            }

            if (s == e)
            {
                Tree[idx] = new Node(key, value);
                return Tree[idx];
            }

            int mid = Mid(s, e);

            Tree[idx] = this._func(UpdateUtil(key, value, s, mid, idx * 2 + 1), UpdateUtil(key, value, mid + 1, e, idx * 2 + 2));

            return Tree[idx];

        }
    }

    public class Node : IComparable<Node>
    {
        public int Index { get; set; }
        public int Value { get; set; }

        public Node(int index, int value)
        {
            Index = index;
            Value = value;
        }

        public int CompareTo(Node other)
        {
            int result = this.Value - other.Value;
            if (result == 0)
            {
                return other.Index - this.Index;
            }

            return result;
        }
    }
}
