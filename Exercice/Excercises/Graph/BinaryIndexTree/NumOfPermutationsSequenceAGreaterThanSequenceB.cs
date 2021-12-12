﻿/*
You are given two sequences A and B of length N. 
Determine the number of different ways to permute the sequence A 
such that it is lexicographically smaller than the sequence B.
For example:
sequenceA: 1 2 3
sequenceB: 2 1 3

Only permutations (1, 2, 3) and (1, 3, 2) are lexicographically smaller than sequence B
result is 2
 */

namespace CSharpAlgo.Excercise.Excercises.Graph.BinaryIndexTree
{
    using CSharpAlgo.Graph.Tree;

    public class NumOfPermutationsSequenceAGreaterThanSequenceB
    {
        public const int mod = (int)(1e9 + 7);

        public static long GetNum(int[] sequenceA, int[] sequenceB)
        {
            int n = sequenceA.Length;

            int size = (int)(2 * 1e5 + 1);
            var cnt = new int[size];

            for (int i = 0; i < n; i++)
            {
                cnt[sequenceA[i]]++;
            }

            var f = new long[size];
            var c = new long[size];

            f[0] = c[0] = 1;

            for (int i = 1; i < size; i++)
            {
                f[i] = (f[i - 1] * i) % mod;
                // Modular multiplicative inverse and Fermat's little theorem
                c[i] = ModularExponentiation.ModularOfPow(f[i], mod - 2, mod);
            }

            long comb = f[n];

            for (int i = 1; i < size; ++i)
                comb = (comb * c[cnt[i]]) % mod;

            var bitree = new BinaryIndexedTree(size + 1);

            for (int i = 1; i < size; ++i)
                bitree.update(i, cnt[i]);

            long ans = 0;
            for (int i = 1; i <= n; ++i)
            {
                comb = (comb * ModularExponentiation.ModularOfPow(n - i + 1, mod - 2, mod)) % mod;
                ans = (ans + comb * bitree.query(sequenceB[i - 1] - 1)) % mod;
                comb = (comb * cnt[sequenceB[i - 1]]) % mod;
                --cnt[sequenceB[i - 1]];

                if (cnt[sequenceB[i - 1]] < 0)
                {
                    break;
                }

                bitree.update(sequenceB[i - 1], -1);
            }

            return ans;
        }

    }

    public class ModularExponentiation
    {
        // calculate pow(a, b)/mod
        public static long ModularOfPow(long a, long b, int mod)
        {
            long ans = 1;
            while (b > 0)
            {
                if ((b & 1) == 1)
                {
                    ans = (ans * a) % mod;
                }

                a = (a * a) % mod;
                b >>= 1;
            }

            return ans;
        }
    }

}
