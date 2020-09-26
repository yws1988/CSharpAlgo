using System;
using System.Collections.Generic;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class FairFight
    {
        public static int T;
        public static int n;
        public static int k;
        public static int[] cs;
        public static int[] ds;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\2019\FairFight.txt");
#endif

            T = Convert.ToInt32(input.ReadLine());

            for (int i = 0; i < T; i++)
            {
                var temp= input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                n = temp[0];
                k = temp[1];
                cs = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                ds = input.ReadLine().Split(' ').Select(int.Parse).ToArray();

                Solve(i+1);
            }

            Console.Read();
        }

        public static void Solve(int t)
        {
            SegmentTreeCompare treec = new SegmentTreeCompare(cs, (i, j)=>Math.Max(i, j));
            SegmentTreeCompare treed = new SegmentTreeCompare(ds, (i, j) => Math.Max(i, j));

            long res = 0;
            Dictionary<int, int> dic = new Dictionary<int, int>();
            
            for (int i = 0; i < n; i++)
            {
                int l, r, lm, rm, bl=-1;

                if (dic.ContainsKey(cs[i]))
                {
                    bl = dic[cs[i]];
                    dic[cs[i]] = i;
                }
                else
                {
                    dic[cs[i]] = i;
                }

                l = BSearchL(treec, treed, bl+1, i, cs[i], cs[i] + k + 1);
                r = BSearchR(treec, treed, i, n - 1, cs[i], cs[i] + k + 1);

                lm = BSearchL(treec, treed, bl+1, i, cs[i], cs[i] - k);
                rm = BSearchR(treec, treed, i, n - 1, cs[i], cs[i] - k);

                res += (r - i + 1) * (i - l + 1);
                res -= (rm - i + 1) * (i - lm + 1);
            }

            Output(t, res.ToString());
        }

        static int BSearchL(SegmentTreeCompare treec, SegmentTreeCompare treed, int l, int r, int max, int max2)
        {
            int ii = r;
            while (r >= l)
            {
                int mid = (l + r) / 2;
                if (treec.Value(mid, ii) <= max && treed.Value(mid, ii) < max2)
                {
                    r = mid-1;
                }
                else
                {
                    l = mid + 1;
                }
            }

            return l;
        }

        static int BSearchR(SegmentTreeCompare treec, SegmentTreeCompare treed, int l, int r, int max, int max2)
        {
            int ii = l;
            while (r >= l)
            {
                int mid = (l + r) / 2;
                if (treec.Value(ii, mid) <= max && treed.Value(ii, mid) < max2)
                {
                    l = mid+1;
                }
                else
                {
                    r = mid - 1;
                }
            }

            return r;
        }

        public static void Output(int caseNum, string result)
        {
            Console.WriteLine("Case #" + caseNum + ": " + result);
        }
    }

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
            if (s == e) return Arr[idx] = _arr[s];

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
            return GetValueUtil(qs, qe, 0, n - 1, 0);
        }

        int GetValueUtil(int qs, int qe, int s, int e, int idx)
        {
            if (qs <= s && qe >= e)
            {
                return Arr[idx];
            }

            if (qe < s || qs > e)
            {
                return -this._func(int.MaxValue, (int.MinValue + 1));
            }

            int mid = Mid(s, e);

            return this._func(GetValueUtil(qs, qe, s, mid, idx * 2 + 1), GetValueUtil(qs, qe, mid + 1, e, idx * 2 + 2));
        }
    }
}
