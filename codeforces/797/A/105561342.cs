// detail: https://codeforces.com/contest/797/submission/105561342
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
        var nk = Console.ReadLine().Split().Select(int.Parse).ToArray();
        var factors = PrimeFactors(nk[0]).ToArray();
        if (factors.Length < nk[1])
        {
            Console.WriteLine(-1);
            return;
        }
        Console.WriteLine(string.Join(" ", factors.Take(nk[1] - 1).Append(factors.Skip(nk[1] - 1).Aggregate(1L, (x, y) => x * y))));
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
}
