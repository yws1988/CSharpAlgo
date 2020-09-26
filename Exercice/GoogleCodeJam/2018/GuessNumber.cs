using System;
using System.Collections.Generic;
using System.Linq;
namespace GoogleCodeJam
{
    class GuessNumber
    {
        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[] Ns = new int[t];
            int[][] prefs = new int[t][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = Convert.ToInt32(Console.ReadLine());
                prefs[i] = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();
               
                int D = prefs[i][0];
                int[] flas = prefs[i];
                HashSet<int> hash = new HashSet<int>();
            
                int k = 1;
                while (k < Ns[i])
                {
                    if (D == 0)
                    {
                        Console.WriteLine(-1);
                    }
                    else
                    {
                        for (int m = 1; m < flas.Length; m++)
                        {
                            if (hash.Contains(flas[m]))
                            {
                                if (m == flas.Length - 1)
                                {
                                    Console.WriteLine(-1);
                                }
                            }
                            else
                            {
                                hash.Add(flas[m]);
                                Console.WriteLine(flas[m]);
                                break;
                            }
                        }
                        
                    }
                    prefs[i] = Console.ReadLine().Split(' ').Select(s => Convert.ToInt32(s)).ToArray();

                    D = prefs[i][0];
                    flas = prefs[i];

                    k++;
                }
            }
        }
    }
}
