/*
 *  Catalan Number
 *  Count the number of expressions containing n pairs of parentheses which are correctly matched. 
 *  For n = 3, possible expressions are ((())), ()(()), ()()(), (())(), (()()).
 *  Catalan numbers for n = 0, 1, 2, 3, … are 1, 1, 2, 5, 14, 42, 132, 429, 1430, 4862
 */

namespace AlgorithmExcercise.DynamicProgramming.Math
{
    public class CatalanNumber
    {
        public static long GetNumberWithDpSolution(int n)
        {
            int[] catalan = new int[n + 2];

            // Initialize first two values in table 
            catalan[0] = catalan[1] = 1;

            for (int i = 2; i <= n; i++)
            {
                catalan[i] = 0;
                for (int j = 0; j < i; j++)
                    catalan[i] += catalan[j] * catalan[i - j - 1];
            }

            return catalan[n];
        }   

        //Binomial Coefficient
        //Catalan value = C(2n, n)/n+1
        public static long GetNumberWithBinomialCoefficient(int n)
        {
           return BinomialCoefficient.BinominalCoefficient(2 * n, n) / (n+1);
        }
    }
}
