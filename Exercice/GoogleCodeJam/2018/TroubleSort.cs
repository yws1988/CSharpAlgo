using System;
using System.Linq;

namespace GoogleCodeJam
{
    public class TroubleSort
    {
        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            int[] N = new int[t];
            int[][] P = new int[t][];

            for (int i = 0; i < t; i++)
            {
                var str1 = Console.ReadLine();
                N[i] = Convert.ToInt32(str1);
                var str2 = Console.ReadLine().Split(' ');
                P[i] = str2.Select(s => Convert.ToInt32(s)).ToArray();
            }

            for (int i = 0; i < t; i++)
            {
                int[] evenNums = P[i].Where((s, index) => index % 2 == 0).ToArray();
                int[] oddNums = P[i].Where((s, index) => index % 2 == 1).ToArray();
                Array.Sort(evenNums);
                Array.Sort(oddNums);
                int result = 0;
                bool isOk = true;
                for (int h = 0; h < evenNums.Length-1; h++)
                {
                    if(evenNums[h]>oddNums[h])
                    {
                        result = 2 * h;
                        isOk = false;
                        break;
                    }else if (oddNums[h] > evenNums[h + 1])
                    {
                        result = 2 * h + 1;
                        isOk = false;
                        break;
                    }
                }
                if (isOk&&evenNums.Length<=oddNums.Length)
                {
                    if (evenNums.Last()>oddNums[evenNums.Length-1])
                    {
                        result = 2 * (evenNums.Length - 1);
                        isOk = false;
                    }
                }
                Output(i + 1, result, isOk);
            }
        }

        public static void Output(int caseNum, int result, bool isOk)
        {
            Console.Write("Case #" + caseNum + ": ");
            if (!isOk)
            {
                Console.Write(result);
            }
            else
            {
                Console.Write("OK");
            }
            Console.WriteLine();
        }
    }
}
