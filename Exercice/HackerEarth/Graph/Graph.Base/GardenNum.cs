namespace HackerEarth.Graph.Base
{
    using System;
    using System.Linq;
    using input = System.Console;

    public class GardenNum
    {
        static int n;
        static short[][] g;
        static long r;

        public static void Start()
        {
#if false
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\GardenNum.txt");
#endif
            n = int.Parse(input.ReadLine());

            g = new short[n][];

            for (int i = 0; i < n; i++)
            {
                g[i] = input.ReadLine().Split(new char[]{ ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(Int16.Parse).ToArray();
            }

            r=0;


            for (int i = 0; i < n - 1; ++i)
            {
                for (int j = i + 1; j < n; ++j)
                {
                    int t = 0;
                    for (int k = 0; k < n; k++)
                    {
                        t += g[i][k] & g[j][k];
                    }
                    r += t * (t - 1) / 2;
                }
            }

            Console.WriteLine(r/2);
        }
            
    }
}