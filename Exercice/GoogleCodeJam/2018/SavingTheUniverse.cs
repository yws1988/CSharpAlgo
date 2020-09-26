using System;
using System.Linq;

namespace GoogleCodeJam
{
    public class SavingTheUniverse
    {
        public static void Start()
        {
            int t = Convert.ToInt32(Console.ReadLine());

            long[] D = new long[t];
            string[] P = new string[t];

            for (int i = 0; i < t; i++)
            {
                var strs = Console.ReadLine().Split(' ');
                D[i] = Convert.ToInt64(strs[0]);
                P[i] = strs[1];
            }

            for (int i = 0; i < t; i++)
            {
                string str = P[i].TrimEnd('C');
                int[] nums = new int[str.Length];

                for (int j = 0, h = 0; j < str.Length; j++)
                {
                    if (str[j] == 'C')
                    {
                        h++;
                    }
                    else
                    {
                        nums[h]++;
                    }
                }

                long minSum = nums.Sum();
                if(D[i] < minSum)
                {
                    Output(i + 1, 0, false);
                }
                else
                {
                    long step = 0;
                    var curEntity = nums.Select((val, idx) => new {val=val, idx=idx}).Where(s => s.val!=0).LastOrDefault();
                    int curIndex = curEntity == null ? 0 : curEntity.idx;
      
                    long sum = (long)nums.Select((s, index) => s * Math.Pow(2, index)).Sum();
                    while (sum > D[i])
                    {
                        if (nums[curIndex] != 0)
                        {
                            nums[curIndex]--;
                            nums[curIndex-1]++;
                            sum =sum - (long)Math.Pow(2, curIndex-1);
                            step++;
                        }
                        else
                        {
                            curIndex--;
                        }
                    }

                    Output(i + 1, step, true);
                }
               
            }
            Console.Read();
        }

        public static void Output(int caseNum, long result, bool isPossible)
        {
            Console.Write("Case #" + caseNum + ": ");
            if (isPossible)
            {
                Console.Write(result);
            }
            else
            {
                Console.Write("IMPOSSIBLE");
            }
            Console.WriteLine();
        }
    }
}
