namespace CSharpAlgo.Graph.Tree
{
    using System;

    public class SegmentTreeSum
    {
        int[] _arr;
        int n;
        public long[] Sum;
        public int N;

        public SegmentTreeSum(int[] arr)
        {
            _arr = arr;
            n = arr.Length;
            this.Construct();
        }

        void Construct()
        {
            N = (int)Math.Pow(2, ((int)Math.Ceiling(Math.Log(_arr.Length, 2)))) * 2 - 1;
            Sum = new long[N];
            ConstructUtil(0, n-1, 0);
        }

        long ConstructUtil(int s, int e, int idx)
        {
            if (s == e) return Sum[idx]=_arr[s];

            int mid = Mid(s, e);
            return Sum[idx] = ConstructUtil(s, mid, idx * 2 + 1) + ConstructUtil(mid + 1, e, idx * 2 + 2);
        }

        int Mid(int s, int e)
        {
           return (s + e) / 2;
        }

        // qt:query start. qe:query end
        public long GetSum(int qs, int qe)
        {
            return GetSumUtil(qs, qe, 0, n-1, 0);
        }

        long GetSumUtil(int qs, int qe, int s, int e, int idx)
        {
            if(qs<=s && qe>=e)
            {
                return Sum[idx];
            }

            if(qe<s || qs > e)
            {
                return 0;
            }

            int mid = Mid(s, e);

            return GetSumUtil(qs, qe, s, mid, idx * 2 + 1) + GetSumUtil(qs, qe, mid+1, e, idx * 2 + 2);
        }

        public void Update(int key, int value)
        {
            int diff = value - _arr[key];
            _arr[key] = value;

            if (diff != 0)
            {
                UpdateUtil(key, diff, 0, n - 1, 0);
            }
        }

        void UpdateUtil(int key, int diff, int s, int e, int idx)
        {
            if(key<s || key > e)
            {
                return;
            }

            Sum[idx] += diff;

            if (s != e)
            {
                int mid = Mid(s, e);
                UpdateUtil(key, diff, s, mid, idx * 2 + 1);
                UpdateUtil(key, diff, mid + 1, e, idx * 2 + 2);
            }
            
        }
    }
}
