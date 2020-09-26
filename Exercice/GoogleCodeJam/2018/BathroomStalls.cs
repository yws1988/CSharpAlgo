using System;
using System.Linq;

namespace GoogleCodeJam._2018
{
    public class BathroomStalls
    {
        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());
            long[][] Ns = new long[t][];
            for (long i = 0; i < t; i++)
            {
                Ns[i] = Console.ReadLine().Split(' ').Select(s => Convert.ToInt64(s)).ToArray();
            }

            for (long i = 0; i < t; i++)
            {
                long max=0,min=0;

                long N = Ns[i][0];
                long K = Ns[i][1];

                long depth = (long)Math.Floor(Math.Log((double)(K + 1), 2));
                long left = K+1 - (long)Math.Pow(2, depth);
                if (left == 0)
                {
                    depth--;
                    left = (long)Math.Pow(2, depth);
                }
                long leftSpace = N + 1 - (long)Math.Pow(2, depth);
                long baseNum = (long)Math.Pow(2, depth);
                long num =  leftSpace / baseNum;
                long additionalSpace = leftSpace - num * baseNum;

                if (left > additionalSpace)
                {
                    min = (num - 1) / 2;
                    max = num / 2;
                }
                else
                {
                    min = num / 2;
                    max = (num + 1) / 2;
                }

                Console.WriteLine("Case #" + (i+1) + ": "+max+" "+min);
            }

            Console.Read();
        }
    }
}
