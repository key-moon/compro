// detail: https://codeforces.com/contest/1349/submission/79829241
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
    public static void Main()
    {
        var primes = Primes(200001).ToArray();
        int n = int.Parse(Console.ReadLine());
        var A = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] counts = new int[200001];
        int[] firsts = Enumerable.Repeat(int.MaxValue, 200001).ToArray();
        int[] seconds = Enumerable.Repeat(int.MaxValue, 200001).ToArray();
        foreach (var a in A)
        {
            foreach (var group in PrimeFactors(a).GroupBy(x => x))
            {
                var prime = group.Key;
                var count = group.Count();
                counts[prime]++;
                if (firsts[prime] > count) { seconds[prime] = firsts[prime]; firsts[prime] = count; }
                else if (seconds[prime] > count) { seconds[prime] = count; }
            }
        }
        long res = 1;
        for (int i = 0; i < firsts.Length; i++)
        {
            if (counts[i] < n - 1) continue;
            if (counts[i] == n - 1) res *= Power(i, firsts[i]);
            else res *= Power(i, seconds[i]);
        }
        Console.WriteLine(res);
    }


    static long Power(long n, long m)
    {
        long pow = n;
        long res = 1;
        while (m > 0)
        {
            if ((m & 1) == 1) res *= pow;
            pow *= pow;
            m >>= 1;
        }
        return res;
    }

    static IEnumerable<long> PrimeFactors(long n)
    {
        while ((n & 1) == 0)
        {
            n >>= 1;
            yield return 2;
        }
        for (long i = 3; i * i <= n; i += 2)
        {
            while (n % i == 0)
            {
                n /= i;
                yield return i;
            }
        }
        if (n != 1) yield return n;
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
