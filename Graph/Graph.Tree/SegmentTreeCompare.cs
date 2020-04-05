namespace Graph.Tree
{
    using System;

    public class SegmentTreeCompare
    {
        int[] _arr;
        int n;
        public int[] Arr;
        public int N;
        Func<int, int, int> _func;

        /// <summary>
        /// 
        /// </summary>
        /// <param name="arr">arr to pass</param>
        /// <param name="condition">0 min query, 1 max query</param>
        public SegmentTreeCompare(int[] arr, Func<int, int, int> func)
        {
            _arr = arr;
            n = arr.Length;
            _func = func;
            this.Construct();
        }

        void Construct()
        {
            N = (int)Math.Pow(2, ((int)Math.Ceiling(Math.Log(_arr.Length, 2)))) * 2 - 1;
            Arr = new int[N];

            ConstructUtil(0, n - 1, 0);
        }

        int ConstructUtil(int s, int e, int idx)
        {
            if (s == e) return Arr[idx]=_arr[s];

            int mid = Mid(s, e);
            return Arr[idx] = this._func(ConstructUtil(s, mid, idx * 2 + 1), ConstructUtil(mid + 1, e, idx * 2 + 2));
        }

        int Mid(int s, int e)
        {
           return (s + e) / 2;
        }

        // qt:query start. qe:query end
        public int Value(int qs, int qe)
        {
            return GetValueUtil(qs, qe, 0, n-1, 0);
        }

        int GetValueUtil(int qs, int qe, int s, int e, int idx)
        {
            if(qs<=s && qe>=e)
            {
                return Arr[idx];
            }

            if(qe<s || qs > e)
            {
                return -this._func(int.MaxValue, (int.MinValue+1));
            }

            int mid = Mid(s, e);

            return this._func(GetValueUtil(qs, qe, s, mid, idx * 2 + 1), GetValueUtil(qs, qe, mid+1, e, idx * 2 + 2));
        }
    }

}
