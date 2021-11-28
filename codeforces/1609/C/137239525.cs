// detail: https://codeforces.com/contest/1609/submission/137239525
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using static System.Math;
public static class P
{
    static bool[] IsPrime;
    public static void Main()
    {

        Console.SetOut(new StreamWriter(Console.OpenStandardOutput()) { AutoFlush = false });
        IsPrime = new bool[(int)1e6 + 1];
        foreach (var item in Primes((int)1e6))
        {
            IsPrime[item] = true;
        }
        var t = int.Parse(Console.ReadLine());
        for (int i = 0; i < t; i++)
        {
            Solve();
        }
        Console.Out.Flush();
    }
    static void Solve()
    {
        var ne = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = ne[0];
        var e = ne[1];
        var a = Console.ReadLine().Split().Select(int.Parse).ToArray();
        long res = 0;
        for (int m = 0; m < e; m++)
        {
            bool hasPrime = false;
            long beforeDelim = 0;
            long afterDelim = 0;

            void Update()
            {
                if (hasPrime)
                {
                    res += (beforeDelim + 1) * (afterDelim + 1) - 1;
                }
            }

            for (int pos = m; pos < n; pos += e)
            {
                if (IsPrime[a[pos]])
                {
                    Update();
                    beforeDelim = afterDelim;
                    afterDelim = 0;
                    hasPrime = true;
                }
                else if (a[pos] == 1)
                {
                    afterDelim++;
                }
                else
                {
                    Update();
                    hasPrime = false;
                    beforeDelim = 0;
                    afterDelim = 0;
                }
            }
            Update();
        }
        Console.WriteLine(res);
    }

    public static IEnumerable<int> Primes(int n)
    {
        if (n < 2) yield break;
        yield return 2;
        ulong[] bitArray = new ulong[(n + 1) / 2 / 64 + 1];

        int[] smallPrimes = { 3, 5, 7, 11, 13, 17, 19, 23, 29, 31, 37, 41, 43, 47, 53, 59, 61 };
        foreach (var prime in smallPrimes)
        {
            if (n < prime) yield break;
            yield return prime;

            ulong[] mask = new ulong[prime];
            for (int j = (prime - 3) >> 1; j < (prime << 6); j += prime)
                mask[j >> 6] |= 1UL << j;

            int maskInd = 0;
            for (int i = 0; i < bitArray.Length; i++)
            {
                bitArray[i] |= mask[maskInd];
                if (++maskInd >= prime) maskInd = 0;
            }
        }

        int[] deBruijnIndex = { 0, 1, 59, 2, 60, 40, 54, 3, 61, 32, 49, 41, 55, 19, 35, 4, 62, 52, 30, 33, 50, 12, 14, 42, 56, 16, 27, 20, 36, 23, 44, 5, 63, 58, 39, 53, 31, 48, 18, 34, 51, 29, 11, 13, 15, 26, 22, 43, 57, 38, 47, 17, 28, 10, 25, 21, 37, 46, 9, 24, 45, 8, 7, 6 };
        int maxInd = n / 2;
        for (int i = 0; i < bitArray.Length; i++)
        {
            for (ulong bit = ~bitArray[i]; bit != 0; bit &= bit - 1)
            {
                int index = i << 6 | deBruijnIndex[((bit & (~bit + 1)) * 0x03F566ED27179461UL) >> 58];
                int prime = (index << 1) + 3;
                if (n < prime) yield break;
                yield return prime;
                for (int ind = index; ind <= maxInd; ind += prime)
                    bitArray[ind >> 6] |= 1UL << ind;
            }
        }
    }
}
