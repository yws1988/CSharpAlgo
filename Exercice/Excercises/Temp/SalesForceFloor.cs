using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

/*******
 * Read input from Console
 * Use Console.WriteLine to output your result.
 * Use:
 *       Utils.LocalPrint( variable); 
 * to display simple variables in a dedicated area.
 * 
 * Use:
 *      
		Utils.LocalPrintArray( collection)
 * to display collections in a dedicated area.
 * ***/

namespace CSharpContestProject
{
    class SalesForceFloor
    {
        static void Start(string[] args)
        {        
            int L = int.Parse(Console.ReadLine());
            int N = int.Parse(Console.ReadLine());

            List<int> teams = new List<int>();
            int total = 0;
            for (int i = 0; i < N; i++)
            {
                int l = int.Parse(Console.ReadLine());
                if (l == L)
                {
                    total++;
                }else if (teams.Any(s => s + l == L))
                {
                    total++;
                    teams.Remove(L-l);
                }
                else
                {
                    teams.Add(l);
                }
                
            }
            Console.WriteLine(total);
        }
    }
}