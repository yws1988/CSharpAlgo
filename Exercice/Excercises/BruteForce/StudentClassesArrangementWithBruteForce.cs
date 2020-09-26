namespace CSharpAlgo.Excercise.Excercises.BruteForce
{
    using System;
    using System.Linq;

    public class StudentClassesArrangementWithBruteForce
    {
        public static int N;
        public static Tuple<int,int>[] Ps;

        public static void Start()
        {
            N = int.Parse(Console.ReadLine());
            Ps = new Tuple<int, int>[N*2];
            for (int i = 0; i < N; i++)
            {
                var temp = Console.ReadLine().Split(' ').Select(int.Parse).ToArray();
                Ps[i * 2] = new Tuple<int, int>(temp[0], i);
                Ps[i * 2+1] = new Tuple<int, int>(temp[1], i);
            }

            bool[] vs = new bool[N];

            Array.Sort(Ps);
            Console.WriteLine(GetMax(vs, -1, 0));
        }

        public static int GetMax(bool[] vs, int t, int s)
        {
            if (s == 2 * N) return 0;
            int r = 0;

            if (!vs[Ps[s].Item2] && Ps[s].Item1 > t)
            {
                bool[] nVs = new bool[N];
                vs.CopyTo(nVs, 0);
                nVs[Ps[s].Item2] = true;
                r = GetMax(nVs, Ps[s].Item1+60, s+1) + 1;
            }

            return Math.Max(GetMax(vs, t, s + 1), r);
        }
    }


}
