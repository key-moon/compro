// detail: https://atcoder.jp/contests/abc011/submissions/15257094
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
        int[] primes = Primes(1000).ToArray();
        (int, int)[][] factors = new (int, int)[1001][];
        for (int i = 1; i < factors.Length; i++)
        {
            List<(int, int)> fRes = new List<(int, int)>();
            int num = i;
            for (int j = 0; j < primes.Length; j++)
            {
                int count = 0;
                while (num % primes[j] == 0)
                {
                    count++;
                    num /= primes[j];
                }
                if (count == 0) continue;
                fRes.Add((j, count));
            }
            factors[i] = fRes.ToArray();
        }

        var nd = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var n = nd[0];
        var d = nd[1];
        var xy = Console.ReadLine().Split().Select(int.Parse).ToArray();
        if (xy[0] % d != 0 || xy[1] % d != 0)
        {
            Console.WriteLine(0);
            return;
        }
        var x = Abs(xy[0] / d);
        var y = Abs(xy[1] / d);
        if (n < x + y || (n - (x + y)) % 2 != 0)
        {
            Console.WriteLine(0);
            return;
        }
        var cancelled = (n - (x + y)) / 2;

        int[][] factorial = new int[1001][];
        factorial[0] = new int[primes.Length];

        for (int i = 1; i < factorial.Length; i++)
        {
            factorial[i] = factorial[i - 1].ToArray();
            foreach (var (primeidx, count) in factors[i])
            {
                factorial[i][primeidx] += count;
            }
        }

        double totalRes = 0;
        for (int xCancelled = 0; xCancelled <= cancelled; xCancelled++)
        {
            var res = new int[primes.Length];
            var yCancelled = cancelled - xCancelled;

            var xa = x + xCancelled;
            var ya = y + yCancelled;
            var xb = xCancelled;
            var yb = yCancelled;

            //n!/(xa!+ya!+xb!+yb!)
            for (int i = 0; i < factorial[n].Length; i++)
                res[i] += factorial[n][i];
            for (int i = 0; i < factorial[xa].Length; i++)
                res[i] -= factorial[xa][i];
            for (int i = 0; i < factorial[ya].Length; i++)
                res[i] -= factorial[ya][i];
            for (int i = 0; i < factorial[xb].Length; i++)
                res[i] -= factorial[xb][i];
            for (int i = 0; i < factorial[yb].Length; i++)
                res[i] -= factorial[yb][i];

            double remainDivideCount = 2 * n;
            double numRes = 1;
            for (int i = 0; i < res.Length; i++)
            {
                for (int j = 0; j < res[i]; j++)
                {
                    numRes *= primes[i];
                    while (1 < numRes && remainDivideCount != 0)
                    {
                        numRes /= 2;
                        remainDivideCount--;
                    }
                }
            }

            for (int i = 0; i < remainDivideCount; i++)
                numRes /= 2;
            totalRes += numRes;
        }

        
        Console.WriteLine(totalRes);
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