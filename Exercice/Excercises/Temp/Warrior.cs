using System;
using System.Collections.Generic;
using System.Linq;

namespace CSharpContestProject
{
    class Warrior
    {
        public static int[][] tribus;
        public static int N;
        public static HashSet<int> eVals = new HashSet<int>();

        static void Start(string[] args)
        {
            N = int.Parse(Console.ReadLine());
            tribus = new int[N][];
            string line;
            int i = 0;
            while ((line = Console.ReadLine()) != null)
            {
                tribus[i] = line.Split(' ').Select(int.Parse).ToArray();
                i++;
            }
            int max = 0;
            
            for (int j = 0; j < tribus.Count(); j++)
            {
                if (eVals.Contains(j)) continue;

                HashSet<int> pVals = new HashSet<int>();

                int jVal=GetValueOfTribu(j, pVals);

                if (max < jVal)
                {
                    max = jVal;
                }
            }

            Console.WriteLine(max);

            Console.Read();

            // Vous pouvez aussi effectuer votre traitement ici après avoir lu toutes les données 
        }

        public static int GetValueOfTribu(int i, HashSet<int> pVals)
        {
            int cVal = tribus[i][0];
            for (int h = 1; h < tribus[i].Count(); h++)
            {
                if (!eVals.Contains(tribus[i][h])) eVals.Add(tribus[i][h]);
                if (!pVals.Contains(tribus[i][h]))
                {
                    pVals.Add(tribus[i][h]);
                    cVal += GetValueOfTribu(tribus[i][h], pVals);
                }
            }
            return cVal;
        }
    }
}