using System;
using System.Linq;
using input = System.Console;

namespace CodeJam.Model
{
    public class MysteriousRoadSigns
    {
        public static void Start()
        {
#if true
            System.IO.StreamReader input = new System.IO.StreamReader(@"test\MysteriousRoadSigns.txt");
#endif

            int t = Convert.ToInt32(input.ReadLine());
            int[][] Ns = new int[t][];
            int[][][] nums = new int[t][][];

            for (int i = 0; i < t; i++)
            {
                Ns[i] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                int N = Ns[i][0];
                nums[i] = new int[N][];
                for (int h = 0; h < N; h++)
                {
                    nums[i][h] = input.ReadLine().Split(' ').Select(int.Parse).ToArray();
                }
            }

            for (int i = 0; i < t; i++)
            {
                Solve(Ns[i], nums[i], i+1);
            }

            Console.Read();
        }

        public static void Solve(int[] Ns, int[][] nums, int caseNum)
        {
            int N = Ns[0];
            int[][] calNs = new int[N][];
            for (int i = 0; i < N; i++)
            {
                calNs[i] = new int[2];
                calNs[i][0] = nums[i][0]+nums[i][1];
                calNs[i][1] = nums[i][0]-nums[i][2];
            }

            int max = 0;
            int numM = 0;
            for (int i = 0; i < N; i++)
            {
                if (N - i < max) break;

                int maxL = 1;
                int maxR = 1;

                int L = calNs[i][0];
                int R = int.MaxValue;

                for (int j = i+1; j < N; j++)
                {
                    
                    if (IsSame(calNs[j], ref L, ref R))
                    {
                        maxL++;
                    }
                    else
                    {
                        break;
                    }
                }

                L = int.MaxValue;
                R = calNs[i][1];

                for (int j = i+1; j < N; j++)
                {
                    if (IsSame(calNs[j], ref L, ref R))
                    {
                        maxR++;
                    }
                    else
                    {
                        break;
                    }
                }

                int temp = Math.Max(maxL, maxR);

                if(temp == max)
                {
                    numM++;
                }
                else if(temp>max)
                {
                    max = temp;
                    numM = 1;
                }
            }

            Output(caseNum, max, numM);
        }

        public static bool IsSame(int[] nums, ref int L, ref int R)
        {
            if (L != int.MaxValue && R!=int.MaxValue)
            {
                if (nums[0] == L || nums[1] == R)
                {
                    return true;
                }
                return false;
            }

            if (L == int.MaxValue)
            {
                if (nums[1] == R)
                {
                    return true;
                }
                else
                {
                    L = nums[0];
                    return true;
                }
            }

            if(R == int.MaxValue)
            {
                if (nums[0] == L)
                {
                    return true;
                }
                else
                {
                    R = nums[1];
                    return true;
                }
            }

            return false;
        }

        public static void Output(int caseNum, int max, int num)
        {
            Console.Write("Case #" + caseNum + ": " + max+" "+num);

            Console.WriteLine();
        }
    }
}
