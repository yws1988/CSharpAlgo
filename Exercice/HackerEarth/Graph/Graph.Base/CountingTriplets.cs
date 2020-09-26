namespace HackerEarth.Graph.Base
{
    using System;
    using System.Linq;
    using input = System.Console;

    public class CountingTriplets
    {
        static long n, m;
        static long[] degree;
        static long r, rd;

        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\CountingTriplets.txt");
#endif
            var tmp = input.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
            n = tmp[0]+1;
            m = tmp[1];

            degree = new long[n];

            for (int i = 0; i < m; i++)
            {
                tmp = input.ReadLine().Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(long.Parse).ToArray();
                degree[tmp[0]]++;
                degree[tmp[1]]++;
            }

            rd = 0;
            for (int i = 1; i < n; i++)
            {
                rd += degree[i] * (n- 2 - degree[i]);
            }

            r = (n-1)*(n-2)*(n-3)/6 - rd/2;
            Console.WriteLine(r);
        }
    }
}